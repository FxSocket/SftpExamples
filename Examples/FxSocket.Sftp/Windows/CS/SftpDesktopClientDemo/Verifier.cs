using System;
using System.Collections;
using System.Text;
using FxSocket.Net;
using FxSocket.Security;

namespace FxSocketSamples
{
	public class Verifier
	{
		public static void ValidatingCertificate(object sender, SslCertificateValidationEventArgs e)
		{
			Verifier verifier = new Verifier();
			TlsCertificateAcceptance acceptResult = verifier.Verify(e.ServerName, e.CertificateChain);
			if (acceptResult == TlsCertificateAcceptance.Accept)
				e.Accept();
			else
				e.Reject(acceptResult);
		}

        public TlsCertificateAcceptance Verify(string commonName, SysCertificateChain certificateChain)
		{
			SysCertValidationResult res = certificateChain.Validate(commonName, 0);

			if (res.Valid)
				return TlsCertificateAcceptance.Accept;

			SysCertValidationStatus status = res.Status;

			SysCertValidationStatus[] values = (SysCertValidationStatus[])Enum.GetValues(typeof(SysCertValidationStatus));

			bool showAddIssuerCaToTrustedCaStore = false;
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < values.Length; i++)
			{
				if ((status & values[i]) == 0)
					continue;

				status ^= values[i];
				string problem;

				switch (values[i])
				{
					case SysCertValidationStatus.TimeNotValid:
						problem = "Server certificate has expired or is not valid yet.";
						break;
					case SysCertValidationStatus.Revoked:
						problem = "Server certificate has been revoked.";
						break;
					case SysCertValidationStatus.UnknownCa:
						problem = "Server certificate was issued by an unknown authority.";
						break;
					case SysCertValidationStatus.RootNotTrusted:
						problem = "Server certificate was issued by an untrusted authority.";
						if (certificateChain.RootCertificate != null)
							showAddIssuerCaToTrustedCaStore = true;
						break;
					case SysCertValidationStatus.IncompleteChain:
						problem = "Server certificate does not chain up to a trusted root authority.";
						break;
					case SysCertValidationStatus.Malformed:
						problem = "Server certificate is malformed.";
						break;
					case SysCertValidationStatus.CnNotMatch:
						problem = "Server hostname does not match the certificate.";
						break;
					case SysCertValidationStatus.UnknownError:
						problem = string.Format("Error {0:x} encountered while validating server's certificate.", res.ErrorCode);
						break;
					default:
						problem = values[i].ToString();
						break;
				}

				sb.AppendFormat("{0}\r\n", problem);
			}

			SysCertificate cert = certificateChain.LeafCertificate;

			string certFingerprint = BitConverter.ToString(cert.GetCertHash());

			VerifierForm certForm = new VerifierForm();
			certForm.Problem = sb.ToString();
			certForm.Hostname = cert.GetCommonName();
			certForm.Subject = cert.GetSubjectName();
			certForm.Issuer = cert.GetIssuerName();
			certForm.ShowAddIssuerToTrustedCaStoreButton = showAddIssuerCaToTrustedCaStore;
			certForm.ValidFrom = cert.GetEffectiveDate().ToString();
			certForm.ValidTo = cert.GetExpirationDate().ToString();

			certForm.ShowDialog();

			// add certificate of the issuer CA to truster authorities store
			if (certForm.AddIssuerCertificateAuthothorityToTrustedCaStore)
			{
                SysCertificateStore trustedCaStore = new SysCertificateStore(SysCertificateStoreName.Root);
                SysCertificate rootCertificate = certificateChain.RootCertificate;

				trustedCaStore.AddCertificate(rootCertificate);
			}

			if (certForm.Accepted)
			{
				return TlsCertificateAcceptance.Accept;
			}

			if ((res.Status & SysCertValidationStatus.TimeNotValid) != 0)
				return TlsCertificateAcceptance.Expired;
			if ((res.Status & SysCertValidationStatus.Revoked) != 0)
				return TlsCertificateAcceptance.Revoked;
			if ((res.Status & (SysCertValidationStatus.UnknownCa | SysCertValidationStatus.RootNotTrusted | SysCertValidationStatus.IncompleteChain)) != 0)
				return TlsCertificateAcceptance.UnknownAuthority;
			if ((res.Status & (SysCertValidationStatus.Malformed | SysCertValidationStatus.UnknownError)) != 0)
				return TlsCertificateAcceptance.Other;

			return TlsCertificateAcceptance.Bad;
		}

	}
}

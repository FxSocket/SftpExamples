using System;
using System.Collections;
using FxSocket.Net;
using FxSocket.Security;
using FxSocket.Samples.WinFormClient;

namespace FxSocketSamples
{
    public class RequestHandler : FxSocket.Net.IClientCertificateNeededHandler
	{
		private static Hashtable _chosenCertificates = new Hashtable();

        public SysCertificateChain Request(TlsSocket socket, DistinguishedName[] issuers)
		{
			string serverCertificateFingerprint = BitConverter.ToString(
				socket.ServerCertificate.LeafCertificate.GetCertHash());
			
			if (_chosenCertificates.Contains(serverCertificateFingerprint))
				return _chosenCertificates[serverCertificateFingerprint] as SysCertificateChain;

            SysCertificateStore my = new SysCertificateStore("MY");
            SysCertificate[] certs;

			if (issuers.Length > 0)
				certs = my.FindCertificates
					(
					issuers,
                    SysCertificateSearchFlags.IsTimeValid |
                    SysCertificateSearchFlags.HasPrivateKey |
                    SysCertificateSearchFlags.ClientAuthentication
					);
			else
				certs = my.FindCertificates
					(
                    SysCertificateSearchFlags.IsTimeValid |
					SysCertificateSearchFlags.HasPrivateKey |
					SysCertificateSearchFlags.ClientAuthentication
					);

			if (certs.Length == 0)
				return null;

			RequesetHandlerForm rhForm = new RequesetHandlerForm();
			rhForm.LoadData(certs);

			if (rhForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
			{
				SysCertificateChain chain = null;
				
				if (rhForm.Certificate != null)
					chain = SysCertificateChain.BuildFrom(rhForm.Certificate);

				// save chosen certificate for the server in static HashTable
				_chosenCertificates.Add(serverCertificateFingerprint, chain);

				return chain;
			}

			return null;
		}
	}
}

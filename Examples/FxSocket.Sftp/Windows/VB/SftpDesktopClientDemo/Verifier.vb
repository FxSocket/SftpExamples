Imports System.Collections
Imports System.Text
Imports FxSocket.Net
Imports FxSocket.Security

Namespace FxSocketSamples
	Public Class Verifier
		Public Shared Sub ValidatingCertificate(ByVal sender As Object, ByVal e As SslCertificateValidationEventArgs)
'INSTANT VB NOTE: The variable verifier was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
			Dim verifier_Renamed As New Verifier()
			Dim acceptResult As TlsCertificateAcceptance = verifier_Renamed.Verify(e.ServerName, e.CertificateChain)
			If acceptResult = TlsCertificateAcceptance.Accept Then
				e.Accept()
			Else
				e.Reject(acceptResult)
			End If
		End Sub

		Public Function Verify(ByVal commonName As String, ByVal certificateChain As SysCertificateChain) As TlsCertificateAcceptance
			Dim res As SysCertValidationResult = certificateChain.Validate(commonName, 0)

			If res.Valid Then
				Return TlsCertificateAcceptance.Accept
			End If

			Dim status As SysCertValidationStatus = res.Status

			Dim values() As SysCertValidationStatus = CType(System.Enum.GetValues(GetType(SysCertValidationStatus)), SysCertValidationStatus())

			Dim showAddIssuerCaToTrustedCaStore As Boolean = False
			Dim sb As New StringBuilder()
			For i As Integer = 0 To values.Length - 1
				If (status And values(i)) = 0 Then
					Continue For
				End If

				status = status Xor values(i)
				Dim problem As String

				Select Case values(i)
					Case SysCertValidationStatus.TimeNotValid
						problem = "Server certificate has expired or is not valid yet."
					Case SysCertValidationStatus.Revoked
						problem = "Server certificate has been revoked."
					Case SysCertValidationStatus.UnknownCa
						problem = "Server certificate was issued by an unknown authority."
					Case SysCertValidationStatus.RootNotTrusted
						problem = "Server certificate was issued by an untrusted authority."
						If certificateChain.RootCertificate IsNot Nothing Then
							showAddIssuerCaToTrustedCaStore = True
						End If
					Case SysCertValidationStatus.IncompleteChain
						problem = "Server certificate does not chain up to a trusted root authority."
					Case SysCertValidationStatus.Malformed
						problem = "Server certificate is malformed."
					Case SysCertValidationStatus.CnNotMatch
						problem = "Server hostname does not match the certificate."
					Case SysCertValidationStatus.UnknownError
						problem = String.Format("Error {0:x} encountered while validating server's certificate.", res.ErrorCode)
					Case Else
						problem = values(i).ToString()
				End Select

				sb.AppendFormat("{0}" & vbCrLf, problem)
			Next i

			Dim cert As SysCertificate = certificateChain.LeafCertificate

			Dim certFingerprint As String = BitConverter.ToString(cert.GetCertHash())

			Dim certForm As New VerifierForm()
			certForm.Problem = sb.ToString()
			certForm.Hostname = cert.GetCommonName()
			certForm.Subject = cert.GetSubjectName()
			certForm.Issuer = cert.GetIssuerName()
			certForm.ShowAddIssuerToTrustedCaStoreButton = showAddIssuerCaToTrustedCaStore
			certForm.ValidFrom = cert.GetEffectiveDate().ToString()
			certForm.ValidTo = cert.GetExpirationDate().ToString()

			certForm.ShowDialog()

			' add certificate of the issuer CA to truster authorities store
			If certForm.AddIssuerCertificateAuthothorityToTrustedCaStore Then
				Dim trustedCaStore As New SysCertificateStore(SysCertificateStoreName.Root)
				Dim rootCertificate As SysCertificate = certificateChain.RootCertificate

				trustedCaStore.AddCertificate(rootCertificate)
			End If

			If certForm.Accepted Then
				Return TlsCertificateAcceptance.Accept
			End If

			If (res.Status And SysCertValidationStatus.TimeNotValid) <> 0 Then
				Return TlsCertificateAcceptance.Expired
			End If
			If (res.Status And SysCertValidationStatus.Revoked) <> 0 Then
				Return TlsCertificateAcceptance.Revoked
			End If
			If (res.Status And (SysCertValidationStatus.UnknownCa Or SysCertValidationStatus.RootNotTrusted Or SysCertValidationStatus.IncompleteChain)) <> 0 Then
				Return TlsCertificateAcceptance.UnknownAuthority
			End If
			If (res.Status And (SysCertValidationStatus.Malformed Or SysCertValidationStatus.UnknownError)) <> 0 Then
				Return TlsCertificateAcceptance.Other
			End If

			Return TlsCertificateAcceptance.Bad
		End Function

	End Class
End Namespace

Imports System.Collections
Imports FxSocket.Net
Imports FxSocket.Security
Imports FxSocket.Samples.WinFormClient

Namespace FxSocketSamples
	Public Class RequestHandler
		Implements FxSocket.Net.IClientCertificateNeededHandler
		Private Shared _chosenCertificates As New Hashtable()

		Public Function Request(ByVal socket As TlsSocket, ByVal issuers() As DistinguishedName) As SysCertificateChain Implements FxSocket.Net.IClientCertificateNeededHandler.Request
			Dim serverCertificateFingerprint As String = BitConverter.ToString(socket.ServerCertificate.LeafCertificate.GetCertHash())

			If _chosenCertificates.Contains(serverCertificateFingerprint) Then
				Return TryCast(_chosenCertificates(serverCertificateFingerprint), SysCertificateChain)
			End If

			Dim my As New SysCertificateStore("MY")
			Dim certs() As SysCertificate

			If issuers.Length > 0 Then
				certs = my.FindCertificates(issuers, SysCertificateSearchFlags.IsTimeValid Or SysCertificateSearchFlags.HasPrivateKey Or SysCertificateSearchFlags.ClientAuthentication)
			Else
				certs = my.FindCertificates(SysCertificateSearchFlags.IsTimeValid Or SysCertificateSearchFlags.HasPrivateKey Or SysCertificateSearchFlags.ClientAuthentication)
			End If

			If certs.Length = 0 Then
				Return Nothing
			End If

			Dim rhForm As New RequesetHandlerForm()
			rhForm.LoadData(certs)

			If rhForm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Dim chain As SysCertificateChain = Nothing

				If rhForm.Certificate IsNot Nothing Then
					chain = SysCertificateChain.BuildFrom(rhForm.Certificate)
				End If

				' save chosen certificate for the server in static HashTable
				_chosenCertificates.Add(serverCertificateFingerprint, chain)

				Return chain
			End If

			Return Nothing
		End Function
	End Class
End Namespace

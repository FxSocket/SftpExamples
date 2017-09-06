Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports FxSocket.IO
Imports FxSocket.Net

Namespace FxSocketSamples
	Friend Class Program
		<STAThread> _
		Shared Sub Main(ByVal args() As String)
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New MainForm())
		End Sub
	End Class
End Namespace
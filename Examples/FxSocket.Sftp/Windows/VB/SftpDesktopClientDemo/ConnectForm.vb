Imports System.ComponentModel
Imports System.Text
Imports FxSocket.Net

Namespace FxSocketSamples
	Partial Public Class ConnectForm
		Inherits Form
		Public Sub New()
			InitializeComponent()


			Server = CStr(Common.GetKey("Server", ""))
			Port = Common.GetKey("Port", 21)

			UserName = CStr(Common.GetKey("User", ""))
			Password = CStr(Common.GetKey("Pass", ""))
			UseUtf8Encoding = Common.GetKey("Utf8", False)

			ClientKey = CStr(Common.GetKey("Cert", ""))

			ProxyHost = CStr(Common.GetKey("ProxyHost", ""))
			ProxyPort = Common.GetKey("ProxyPort", 1080)
			ProxyType = CType(Common.GetKey("ProxyType", 0), NetProxyType)
			ProxyAuthnMethod = CType(Common.GetKey("ProxyAuthnMethod", 0), ProxyAuthenticationType)
			ProxyUser = CStr(Common.GetKey("ProxyUser", ""))
			ProxyPassword = CStr(Common.GetKey("ProxyPassword", ""))
			ProxyDomain = CStr(Common.GetKey("ProxyDomain", ""))
		End Sub

		Public Property Server() As String
			Get
				Return tbServer.Text
			End Get
			Set(ByVal value As String)
				tbServer.Text = value
			End Set
		End Property

		Public Property Port() As Integer
			Get
				Return CInt(Fix(tbPort.Value))
			End Get
			Set(ByVal value As Integer)
				tbPort.Value = value
			End Set
		End Property

		Public Property UserName() As String
			Get
				Return tbUserName.Text
			End Get
			Set(ByVal value As String)
				tbUserName.Text = value
			End Set
		End Property

		Public Property Password() As String
			Get
				Return tbPassword.Text
			End Get
			Set(ByVal value As String)
				tbPassword.Text = value
			End Set
		End Property

		Public Property UseUtf8Encoding() As Boolean
			Get
				Return cbUtf8Encoding.Checked
			End Get
			Set(ByVal value As Boolean)
				cbUtf8Encoding.Checked = value
			End Set
		End Property

		Public Property Version4() As Boolean
			Get
				Return cbSftpv4.Checked
			End Get
			Set(ByVal value As Boolean)
				cbSftpv4.Checked = value
			End Set
		End Property

		#Region "Security"

		Public Property ClientKey() As String
			Get
				Return tbCert.Text
			End Get
			Set(ByVal value As String)
				tbCert.Text = value
			End Set
		End Property

		#End Region

		#Region "Proxy"

		Public Property ProxyHost() As String
			Get
				Return tbProxyHost.Text
			End Get
			Set(ByVal value As String)
				tbProxyHost.Text = value
			End Set
		End Property

		Public Property ProxyPort() As Integer
			Get
				Return CInt(Fix(tbProxyPort.Value))
			End Get
			Set(ByVal value As Integer)
				tbProxyPort.Value = value
			End Set
		End Property

		Public Property ProxyUser() As String
			Get
				Return tbProxyUser.Text
			End Get
			Set(ByVal value As String)
				tbProxyUser.Text = value
			End Set
		End Property

		Public Property ProxyPassword() As String
			Get
				Return tbProxyPassword.Text
			End Get
			Set(ByVal value As String)
				tbProxyPassword.Text = value
			End Set
		End Property

		Public Property ProxyDomain() As String
			Get
				Return tbProxyDomain.Text
			End Get
			Set(ByVal value As String)
				tbProxyDomain.Text = value
			End Set
		End Property

		Public Property ProxyType() As NetProxyType
			Get
				Return CType(cbxProxyType.SelectedIndex, NetProxyType)
			End Get
			Set(ByVal value As NetProxyType)
				cbxProxyType.SelectedIndex = CInt(value)
			End Set
		End Property

		Public Property ProxyAuthnMethod() As ProxyAuthenticationType
			Get
				Return CType(cbxProxyMethod.SelectedIndex, ProxyAuthenticationType)
			End Get
			Set(ByVal value As ProxyAuthenticationType)
				cbxProxyMethod.SelectedIndex = CInt(value)
			End Set
		End Property

		#End Region

		Private Sub connectBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles connectBtn.Click
			Common.SetKey("Server", Server)
			Common.SetKey("Port", Port)

			Common.SetKey("User", UserName)
			Common.SetKey("Pass", Password)
			Common.SetKey("Utf8", UseUtf8Encoding)
			Common.SetKey("v4", Version4)

			Common.SetKey("Cert", ClientKey)

			Common.SetKey("ProxyHost", ProxyHost)
			Common.SetKey("ProxyPort", ProxyPort)
			Common.SetKey("ProxyType", ProxyType)
			Common.SetKey("ProxyAuthnMethod", ProxyAuthnMethod)
			Common.SetKey("ProxyUser", ProxyUser)
			Common.SetKey("ProxyPassword", ProxyPassword)
			Common.SetKey("ProxyDomain", ProxyDomain)
		End Sub

		Private Sub certBrowseBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btCertBrowse.Click
			Try
				Dim dlg As New OpenFileDialog()
				dlg.Title = "Select a private key file"
				dlg.FileName = tbCert.Text
				dlg.Filter = "All files|*.*"
				dlg.FilterIndex = 1
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					tbCert.Text = dlg.FileName
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error")
			End Try
		End Sub
	End Class
End Namespace

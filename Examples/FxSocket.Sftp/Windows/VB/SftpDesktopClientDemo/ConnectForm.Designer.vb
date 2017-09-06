Namespace FxSocketSamples
	Partial Public Class ConnectForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.cbUtf8Encoding = New System.Windows.Forms.CheckBox()
			Me.tbUserName = New System.Windows.Forms.TextBox()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.lblFtpPassword = New System.Windows.Forms.Label()
			Me.lblPort = New System.Windows.Forms.Label()
			Me.lblServer = New System.Windows.Forms.Label()
			Me.lblFtpUserName = New System.Windows.Forms.Label()
			Me.lblCert = New System.Windows.Forms.Label()
			Me.btCertBrowse = New System.Windows.Forms.Button()
			Me.tbCert = New System.Windows.Forms.TextBox()
			Me.grConnection = New System.Windows.Forms.GroupBox()
			Me.cbSftpv4 = New System.Windows.Forms.CheckBox()
			Me.label13 = New System.Windows.Forms.Label()
			Me.tbPort = New System.Windows.Forms.NumericUpDown()
			Me.tbServer = New System.Windows.Forms.TextBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.tbProxyPort = New System.Windows.Forms.NumericUpDown()
			Me.tbProxyDomain = New System.Windows.Forms.TextBox()
			Me.lblDomain = New System.Windows.Forms.Label()
			Me.lblMethod = New System.Windows.Forms.Label()
			Me.cbxProxyMethod = New System.Windows.Forms.ComboBox()
			Me.lblProxyPort = New System.Windows.Forms.Label()
			Me.tbProxyHost = New System.Windows.Forms.TextBox()
			Me.lblProxyServer = New System.Windows.Forms.Label()
			Me.cbxProxyType = New System.Windows.Forms.ComboBox()
			Me.tbProxyPassword = New System.Windows.Forms.TextBox()
			Me.lblPassword = New System.Windows.Forms.Label()
			Me.tbProxyUser = New System.Windows.Forms.TextBox()
			Me.lblUserName = New System.Windows.Forms.Label()
			Me.lblType = New System.Windows.Forms.Label()
			Me.connectBtn = New System.Windows.Forms.Button()
			Me.cancelBtn = New System.Windows.Forms.Button()
			Me.grConnection.SuspendLayout()
			CType(Me.tbPort, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			CType(Me.tbProxyPort, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' cbUtf8Encoding
			' 
			Me.cbUtf8Encoding.AutoSize = True
			Me.cbUtf8Encoding.Location = New System.Drawing.Point(193, 147)
			Me.cbUtf8Encoding.Name = "cbUtf8Encoding"
			Me.cbUtf8Encoding.Size = New System.Drawing.Size(94, 17)
			Me.cbUtf8Encoding.TabIndex = 6
			Me.cbUtf8Encoding.Text = "Utf8 Encoding"
			' 
			' tbUserName
			' 
			Me.tbUserName.Location = New System.Drawing.Point(84, 48)
			Me.tbUserName.Name = "tbUserName"
			Me.tbUserName.Size = New System.Drawing.Size(123, 20)
			Me.tbUserName.TabIndex = 4
			' 
			' tbPassword
			' 
			Me.tbPassword.Location = New System.Drawing.Point(84, 73)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(123, 20)
			Me.tbPassword.TabIndex = 5
			' 
			' lblFtpPassword
			' 
			Me.lblFtpPassword.Location = New System.Drawing.Point(11, 76)
			Me.lblFtpPassword.Name = "lblFtpPassword"
			Me.lblFtpPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblFtpPassword.TabIndex = 66
			Me.lblFtpPassword.Text = "Password:"
			' 
			' lblPort
			' 
			Me.lblPort.Location = New System.Drawing.Point(221, 23)
			Me.lblPort.Name = "lblPort"
			Me.lblPort.Size = New System.Drawing.Size(37, 13)
			Me.lblPort.TabIndex = 64
			Me.lblPort.Text = "Port:"
			' 
			' lblServer
			' 
			Me.lblServer.Location = New System.Drawing.Point(11, 23)
			Me.lblServer.Name = "lblServer"
			Me.lblServer.Size = New System.Drawing.Size(59, 13)
			Me.lblServer.TabIndex = 63
			Me.lblServer.Text = "Server:"
			' 
			' lblFtpUserName
			' 
			Me.lblFtpUserName.Location = New System.Drawing.Point(11, 50)
			Me.lblFtpUserName.Name = "lblFtpUserName"
			Me.lblFtpUserName.Size = New System.Drawing.Size(63, 13)
			Me.lblFtpUserName.TabIndex = 65
			Me.lblFtpUserName.Text = "User Name:"
			' 
			' lblCert
			' 
			Me.lblCert.AutoSize = True
			Me.lblCert.Location = New System.Drawing.Point(11, 123)
			Me.lblCert.Name = "lblCert"
			Me.lblCert.Size = New System.Drawing.Size(63, 13)
			Me.lblCert.TabIndex = 67
			Me.lblCert.Text = "Private key:"
			' 
			' btCertBrowse
			' 
			Me.btCertBrowse.Location = New System.Drawing.Point(465, 119)
			Me.btCertBrowse.Name = "btCertBrowse"
			Me.btCertBrowse.Size = New System.Drawing.Size(26, 20)
			Me.btCertBrowse.TabIndex = 10
			Me.btCertBrowse.Text = "..."
'			Me.btCertBrowse.Click += New System.EventHandler(Me.certBrowseBtn_Click)
			' 
			' tbCert
			' 
			Me.tbCert.Location = New System.Drawing.Point(84, 120)
			Me.tbCert.Name = "tbCert"
			Me.tbCert.Size = New System.Drawing.Size(368, 20)
			Me.tbCert.TabIndex = 9
			' 
			' grConnection
			' 
			Me.grConnection.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.grConnection.Controls.Add(Me.cbSftpv4)
			Me.grConnection.Controls.Add(Me.label13)
			Me.grConnection.Controls.Add(Me.tbPort)
			Me.grConnection.Controls.Add(Me.tbServer)
			Me.grConnection.Controls.Add(Me.cbUtf8Encoding)
			Me.grConnection.Controls.Add(Me.tbCert)
			Me.grConnection.Controls.Add(Me.btCertBrowse)
			Me.grConnection.Controls.Add(Me.tbUserName)
			Me.grConnection.Controls.Add(Me.tbPassword)
			Me.grConnection.Controls.Add(Me.lblCert)
			Me.grConnection.Controls.Add(Me.lblFtpPassword)
			Me.grConnection.Controls.Add(Me.lblFtpUserName)
			Me.grConnection.Controls.Add(Me.lblServer)
			Me.grConnection.Controls.Add(Me.lblPort)
			Me.grConnection.Location = New System.Drawing.Point(12, 8)
			Me.grConnection.Name = "grConnection"
			Me.grConnection.Size = New System.Drawing.Size(577, 218)
			Me.grConnection.TabIndex = 68
			Me.grConnection.TabStop = False
			Me.grConnection.Text = "Connection"
			' 
			' cbSftpv4
			' 
			Me.cbSftpv4.AutoSize = True
			Me.cbSftpv4.Checked = True
			Me.cbSftpv4.CheckState = System.Windows.Forms.CheckState.Checked
			Me.cbSftpv4.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cbSftpv4.Location = New System.Drawing.Point(85, 147)
			Me.cbSftpv4.Name = "cbSftpv4"
			Me.cbSftpv4.Size = New System.Drawing.Size(102, 18)
			Me.cbSftpv4.TabIndex = 20
			Me.cbSftpv4.Text = "Allow SFTP v4"
			' 
			' label13
			' 
			Me.label13.AutoSize = True
			Me.label13.Location = New System.Drawing.Point(11, 149)
			Me.label13.Name = "label13"
			Me.label13.Size = New System.Drawing.Size(46, 13)
			Me.label13.TabIndex = 68
			Me.label13.Text = "Options:"
			' 
			' tbPort
			' 
			Me.tbPort.Location = New System.Drawing.Point(264, 20)
			Me.tbPort.Maximum = New Decimal(New Integer() { 1000000, 0, 0, 0})
			Me.tbPort.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.tbPort.Name = "tbPort"
			Me.tbPort.Size = New System.Drawing.Size(89, 20)
			Me.tbPort.TabIndex = 2
			Me.tbPort.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' tbServer
			' 
			Me.tbServer.Location = New System.Drawing.Point(84, 21)
			Me.tbServer.Name = "tbServer"
			Me.tbServer.Size = New System.Drawing.Size(123, 20)
			Me.tbServer.TabIndex = 1
			' 
			' groupBox1
			' 
			Me.groupBox1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.groupBox1.Controls.Add(Me.tbProxyPort)
			Me.groupBox1.Controls.Add(Me.tbProxyDomain)
			Me.groupBox1.Controls.Add(Me.lblDomain)
			Me.groupBox1.Controls.Add(Me.lblMethod)
			Me.groupBox1.Controls.Add(Me.cbxProxyMethod)
			Me.groupBox1.Controls.Add(Me.lblProxyPort)
			Me.groupBox1.Controls.Add(Me.tbProxyHost)
			Me.groupBox1.Controls.Add(Me.lblProxyServer)
			Me.groupBox1.Controls.Add(Me.cbxProxyType)
			Me.groupBox1.Controls.Add(Me.tbProxyPassword)
			Me.groupBox1.Controls.Add(Me.lblPassword)
			Me.groupBox1.Controls.Add(Me.tbProxyUser)
			Me.groupBox1.Controls.Add(Me.lblUserName)
			Me.groupBox1.Controls.Add(Me.lblType)
			Me.groupBox1.Location = New System.Drawing.Point(13, 231)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(576, 126)
			Me.groupBox1.TabIndex = 69
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Proxy"
			' 
			' tbProxyPort
			' 
			Me.tbProxyPort.Location = New System.Drawing.Point(319, 17)
			Me.tbProxyPort.Maximum = New Decimal(New Integer() { 1000000, 0, 0, 0})
			Me.tbProxyPort.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.tbProxyPort.Name = "tbProxyPort"
			Me.tbProxyPort.Size = New System.Drawing.Size(89, 20)
			Me.tbProxyPort.TabIndex = 31
			Me.tbProxyPort.Value = New Decimal(New Integer() { 1, 0, 0, 0})
			' 
			' tbProxyDomain
			' 
			Me.tbProxyDomain.Enabled = False
			Me.tbProxyDomain.Location = New System.Drawing.Point(83, 91)
			Me.tbProxyDomain.Name = "tbProxyDomain"
			Me.tbProxyDomain.Size = New System.Drawing.Size(126, 20)
			Me.tbProxyDomain.TabIndex = 36
			' 
			' lblDomain
			' 
			Me.lblDomain.Location = New System.Drawing.Point(10, 93)
			Me.lblDomain.Name = "lblDomain"
			Me.lblDomain.Size = New System.Drawing.Size(46, 13)
			Me.lblDomain.TabIndex = 45
			Me.lblDomain.Text = "Domain:"
			' 
			' lblMethod
			' 
			Me.lblMethod.Location = New System.Drawing.Point(236, 69)
			Me.lblMethod.Name = "lblMethod"
			Me.lblMethod.Size = New System.Drawing.Size(80, 13)
			Me.lblMethod.TabIndex = 44
			Me.lblMethod.Text = "Authn Method:"
			' 
			' cbxProxyMethod
			' 
			Me.cbxProxyMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxProxyMethod.Enabled = False
			Me.cbxProxyMethod.FormattingEnabled = True
			Me.cbxProxyMethod.Items.AddRange(New Object() { "Basic", "Ntlm"})
			Me.cbxProxyMethod.Location = New System.Drawing.Point(319, 67)
			Me.cbxProxyMethod.Name = "cbxProxyMethod"
			Me.cbxProxyMethod.Size = New System.Drawing.Size(104, 21)
			Me.cbxProxyMethod.TabIndex = 35
			' 
			' lblProxyPort
			' 
			Me.lblProxyPort.Location = New System.Drawing.Point(236, 21)
			Me.lblProxyPort.Name = "lblProxyPort"
			Me.lblProxyPort.Size = New System.Drawing.Size(92, 13)
			Me.lblProxyPort.TabIndex = 42
			Me.lblProxyPort.Text = "Port:"
			' 
			' tbProxyHost
			' 
			Me.tbProxyHost.Location = New System.Drawing.Point(83, 19)
			Me.tbProxyHost.Name = "tbProxyHost"
			Me.tbProxyHost.Size = New System.Drawing.Size(126, 20)
			Me.tbProxyHost.TabIndex = 30
			' 
			' lblProxyServer
			' 
			Me.lblProxyServer.Location = New System.Drawing.Point(10, 21)
			Me.lblProxyServer.Name = "lblProxyServer"
			Me.lblProxyServer.Size = New System.Drawing.Size(70, 13)
			Me.lblProxyServer.TabIndex = 41
			Me.lblProxyServer.Text = "Host:"
			' 
			' cbxProxyType
			' 
			Me.cbxProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbxProxyType.FormattingEnabled = True
			Me.cbxProxyType.Items.AddRange(New Object() { "Never", "Socks4", "Socks4A", "Socks5", "HttpConnect", "SITE Site", "USER user@site", "OPEN site"})
			Me.cbxProxyType.Location = New System.Drawing.Point(319, 43)
			Me.cbxProxyType.Name = "cbxProxyType"
			Me.cbxProxyType.Size = New System.Drawing.Size(104, 21)
			Me.cbxProxyType.TabIndex = 33
			' 
			' tbProxyPassword
			' 
			Me.tbProxyPassword.Enabled = False
			Me.tbProxyPassword.Location = New System.Drawing.Point(83, 67)
			Me.tbProxyPassword.Name = "tbProxyPassword"
			Me.tbProxyPassword.PasswordChar = "*"c
			Me.tbProxyPassword.Size = New System.Drawing.Size(126, 20)
			Me.tbProxyPassword.TabIndex = 34
			' 
			' lblPassword
			' 
			Me.lblPassword.Location = New System.Drawing.Point(10, 69)
			Me.lblPassword.Name = "lblPassword"
			Me.lblPassword.Size = New System.Drawing.Size(56, 13)
			Me.lblPassword.TabIndex = 40
			Me.lblPassword.Text = "Password:"
			' 
			' tbProxyUser
			' 
			Me.tbProxyUser.Location = New System.Drawing.Point(83, 43)
			Me.tbProxyUser.Name = "tbProxyUser"
			Me.tbProxyUser.Size = New System.Drawing.Size(126, 20)
			Me.tbProxyUser.TabIndex = 32
			' 
			' lblUserName
			' 
			Me.lblUserName.Location = New System.Drawing.Point(10, 45)
			Me.lblUserName.Name = "lblUserName"
			Me.lblUserName.Size = New System.Drawing.Size(63, 13)
			Me.lblUserName.TabIndex = 39
			Me.lblUserName.Text = "Proxy User:"
			' 
			' lblType
			' 
			Me.lblType.Location = New System.Drawing.Point(236, 45)
			Me.lblType.Name = "lblType"
			Me.lblType.Size = New System.Drawing.Size(97, 13)
			Me.lblType.TabIndex = 43
			Me.lblType.Text = "Proxy type:"
			' 
			' connectBtn
			' 
			Me.connectBtn.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.connectBtn.Location = New System.Drawing.Point(433, 360)
			Me.connectBtn.Name = "connectBtn"
			Me.connectBtn.Size = New System.Drawing.Size(75, 23)
			Me.connectBtn.TabIndex = 70
			Me.connectBtn.Text = "Connect"
			Me.connectBtn.UseVisualStyleBackColor = True
'			Me.connectBtn.Click += New System.EventHandler(Me.connectBtn_Click)
			' 
			' cancelBtn
			' 
			Me.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.cancelBtn.Location = New System.Drawing.Point(514, 360)
			Me.cancelBtn.Name = "cancelBtn"
			Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
			Me.cancelBtn.TabIndex = 71
			Me.cancelBtn.Text = "Cancel"
			Me.cancelBtn.UseVisualStyleBackColor = True
			' 
			' ConnectForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(601, 395)
			Me.Controls.Add(Me.cancelBtn)
			Me.Controls.Add(Me.connectBtn)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.grConnection)
			Me.Name = "ConnectForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Connect to Server"
			Me.grConnection.ResumeLayout(False)
			Me.grConnection.PerformLayout()
			CType(Me.tbPort, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			CType(Me.tbProxyPort, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private cbUtf8Encoding As System.Windows.Forms.CheckBox
		Private tbUserName As System.Windows.Forms.TextBox
		Private tbPassword As System.Windows.Forms.TextBox
		Private lblFtpPassword As System.Windows.Forms.Label
		Private lblPort As System.Windows.Forms.Label
		Private lblServer As System.Windows.Forms.Label
		Private lblFtpUserName As System.Windows.Forms.Label
		Private lblCert As System.Windows.Forms.Label
		Private WithEvents btCertBrowse As System.Windows.Forms.Button
		Private tbCert As System.Windows.Forms.TextBox
		Private grConnection As System.Windows.Forms.GroupBox
		Private tbServer As System.Windows.Forms.TextBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private tbProxyDomain As System.Windows.Forms.TextBox
		Private lblDomain As System.Windows.Forms.Label
		Private lblMethod As System.Windows.Forms.Label
		Private cbxProxyMethod As System.Windows.Forms.ComboBox
		Private lblProxyPort As System.Windows.Forms.Label
		Private tbProxyHost As System.Windows.Forms.TextBox
		Private lblProxyServer As System.Windows.Forms.Label
		Private cbxProxyType As System.Windows.Forms.ComboBox
		Private tbProxyPassword As System.Windows.Forms.TextBox
		Private lblPassword As System.Windows.Forms.Label
		Private tbProxyUser As System.Windows.Forms.TextBox
		Private lblUserName As System.Windows.Forms.Label
		Private lblType As System.Windows.Forms.Label
		Private WithEvents connectBtn As System.Windows.Forms.Button
		Private cancelBtn As System.Windows.Forms.Button
		Private tbPort As System.Windows.Forms.NumericUpDown
		Private tbProxyPort As System.Windows.Forms.NumericUpDown
		Private cbSftpv4 As System.Windows.Forms.CheckBox
		Private label13 As System.Windows.Forms.Label
	End Class
End Namespace
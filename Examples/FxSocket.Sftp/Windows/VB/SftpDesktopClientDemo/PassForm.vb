Imports System.Collections
Imports System.ComponentModel

Namespace FxSocketSamples
	''' <summary>
	''' Summary description for PassphraseDialog.
	''' </summary>
	Public Class PassForm
		Inherits System.Windows.Forms.Form
		Private lblPrompt As System.Windows.Forms.Label
		Private btnCancel As System.Windows.Forms.Button
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private tbPassphrase As System.Windows.Forms.TextBox
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public ReadOnly Property Passphrase() As String
			Get
				Return tbPassphrase.Text
			End Get
		End Property

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal prompt As String)
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			If prompt IsNot Nothing Then
				lblPrompt.Text = prompt
			End If
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.lblPrompt = New System.Windows.Forms.Label()
			Me.tbPassphrase = New System.Windows.Forms.TextBox()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' lblPrompt
			' 
			Me.lblPrompt.Location = New System.Drawing.Point(12, 8)
			Me.lblPrompt.Name = "lblPrompt"
			Me.lblPrompt.Size = New System.Drawing.Size(383, 32)
			Me.lblPrompt.TabIndex = 0
			Me.lblPrompt.Text = "Passphrase for the key file:"
			Me.lblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' tbPassphrase
			' 
			Me.tbPassphrase.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbPassphrase.Location = New System.Drawing.Point(11, 43)
			Me.tbPassphrase.Name = "tbPassphrase"
			Me.tbPassphrase.PasswordChar = "*"c
			Me.tbPassphrase.Size = New System.Drawing.Size(384, 20)
			Me.tbPassphrase.TabIndex = 1
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnCancel.Location = New System.Drawing.Point(320, 75)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 2
			Me.btnCancel.Text = "&Cancel"
			' 
			' btnOk
			' 
			Me.btnOk.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnOk.Location = New System.Drawing.Point(240, 75)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 3
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' PassphraseDialog
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(407, 105)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbPassphrase)
			Me.Controls.Add(Me.lblPrompt)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "PassForm"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Passphrase"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace

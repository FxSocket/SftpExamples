Imports System.Collections
Imports System.ComponentModel
Imports FxSocket.Security

Namespace FxSocket.Samples.WinFormClient
	''' <summary>
	''' Summary description for RequesetHandlerForm.
	''' </summary>
	Public Class RequesetHandlerForm
		Inherits System.Windows.Forms.Form
		Private btnCancel As System.Windows.Forms.Button
		Private WithEvents btnNoCertificate As System.Windows.Forms.Button
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Private WithEvents cbCertList As System.Windows.Forms.ComboBox
		Private label6 As System.Windows.Forms.Label
		Private lblValidTo As System.Windows.Forms.Label
		Private lblValidFrom As System.Windows.Forms.Label
		Private lblIssuer As System.Windows.Forms.Label
		Private lblSubject As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label

		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private _certs() As SysCertificate
		Private _selectedCertificate As SysCertificate

		Public ReadOnly Property Certificate() As SysCertificate
			Get
				Return _selectedCertificate
			End Get
		End Property

		Public Sub New()
			InitializeComponent()
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

		Public Sub LoadData(ByVal certs() As SysCertificate)
			_certs = certs

			For i As Integer = 0 To certs.Length - 1
				cbCertList.Items.Add(certs(i).GetSubjectName())
			Next i

			If certs.Length > 0 Then
				cbCertList.SelectedIndex = 0

				lblSubject.Text = certs(0).GetSubjectName()
				lblIssuer.Text = certs(0).GetIssuerName()
				lblValidFrom.Text = certs(0).GetEffectiveDate().ToString()
				lblValidTo.Text = certs(0).GetExpirationDate().ToString()
			End If
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.cbCertList = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.lblValidTo = New System.Windows.Forms.Label()
			Me.lblValidFrom = New System.Windows.Forms.Label()
			Me.lblIssuer = New System.Windows.Forms.Label()
			Me.lblSubject = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.btnNoCertificate = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' btnCancel
			' 
			Me.btnCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnCancel.Location = New System.Drawing.Point(336, 216)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 1
			Me.btnCancel.Text = "&Cancel"
			' 
			' btnOk
			' 
			Me.btnOk.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnOk.Location = New System.Drawing.Point(160, 216)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 0
			Me.btnOk.Text = "&OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' cbCertList
			' 
			Me.cbCertList.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cbCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbCertList.Location = New System.Drawing.Point(104, 8)
			Me.cbCertList.Name = "cbCertList"
			Me.cbCertList.Size = New System.Drawing.Size(304, 21)
			Me.cbCertList.TabIndex = 2
'			Me.cbCertList.SelectedIndexChanged += New System.EventHandler(Me.cbCertList_SelectedIndexChanged)
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(96, 23)
			Me.label1.TabIndex = 3
			Me.label1.Text = "Certificate:"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			' 
			' label6
			' 
			Me.label6.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(238)))
			Me.label6.Location = New System.Drawing.Point(8, 8)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(216, 23)
			Me.label6.TabIndex = 11
			Me.label6.Text = "Certificate details:"
			' 
			' lblValidTo
			' 
			Me.lblValidTo.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblValidTo.Location = New System.Drawing.Point(80, 136)
			Me.lblValidTo.Name = "lblValidTo"
			Me.lblValidTo.Size = New System.Drawing.Size(224, 23)
			Me.lblValidTo.TabIndex = 10
			' 
			' lblValidFrom
			' 
			Me.lblValidFrom.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblValidFrom.Location = New System.Drawing.Point(80, 112)
			Me.lblValidFrom.Name = "lblValidFrom"
			Me.lblValidFrom.Size = New System.Drawing.Size(224, 23)
			Me.lblValidFrom.TabIndex = 9
			' 
			' lblIssuer
			' 
			Me.lblIssuer.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblIssuer.Location = New System.Drawing.Point(80, 72)
			Me.lblIssuer.Name = "lblIssuer"
			Me.lblIssuer.Size = New System.Drawing.Size(312, 32)
			Me.lblIssuer.TabIndex = 8
			' 
			' lblSubject
			' 
			Me.lblSubject.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblSubject.Location = New System.Drawing.Point(80, 32)
			Me.lblSubject.Name = "lblSubject"
			Me.lblSubject.Size = New System.Drawing.Size(312, 32)
			Me.lblSubject.TabIndex = 7
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 136)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(72, 23)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Valid to:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 112)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(72, 23)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Valid from:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 72)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(72, 23)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Issuer:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 32)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 23)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Subject:"
			' 
			' btnNoCertificate
			' 
			Me.btnNoCertificate.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnNoCertificate.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnNoCertificate.Location = New System.Drawing.Point(240, 216)
			Me.btnNoCertificate.Name = "btnNoCertificate"
			Me.btnNoCertificate.Size = New System.Drawing.Size(88, 23)
			Me.btnNoCertificate.TabIndex = 5
			Me.btnNoCertificate.Text = "&No Certificate"
'			Me.btnNoCertificate.Click += New System.EventHandler(Me.btnNoCertificate_Click)
			' 
			' RequesetHandlerForm
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(418, 248)
			Me.ControlBox = False
			Me.Controls.Add(Me.btnNoCertificate)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.cbCertList)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.lblValidTo)
			Me.Controls.Add(Me.lblValidFrom)
			Me.Controls.Add(Me.lblIssuer)
			Me.Controls.Add(Me.lblSubject)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "RequesetHandlerForm"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Select certificate"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub cbCertList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCertList.SelectedIndexChanged
			If cbCertList.SelectedIndex <> -1 Then
				Dim selIndex As Integer = cbCertList.SelectedIndex

				lblSubject.Text = _certs(selIndex).GetSubjectName()
				lblIssuer.Text = _certs(selIndex).GetIssuerName()
				lblValidFrom.Text = _certs(selIndex).GetEffectiveDate().ToString()
				lblValidTo.Text = _certs(selIndex).GetExpirationDate().ToString()
			End If
		End Sub

		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
			If cbCertList.SelectedIndex <> -1 Then
				_selectedCertificate = _certs(cbCertList.SelectedIndex)
			Else
				_selectedCertificate = Nothing
			End If

			Me.Close()
		End Sub

		Private Sub btnNoCertificate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNoCertificate.Click
			_selectedCertificate = Nothing
			Me.Close()
		End Sub
	End Class
End Namespace

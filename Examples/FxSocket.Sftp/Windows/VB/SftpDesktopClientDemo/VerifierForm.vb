Imports System.Collections
Imports System.ComponentModel

Namespace FxSocketSamples
	''' <summary>
	''' Summary description for Verifier.
	''' </summary>
	Public Class VerifierForm
		Inherits System.Windows.Forms.Form
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing
		Private WithEvents btnReject As System.Windows.Forms.Button
		Private WithEvents btnAccept As System.Windows.Forms.Button
		Private WithEvents btnOkAndTrust As System.Windows.Forms.Button

		Private _accepted As Boolean = False
		Private lblHostname As Label
		Private label8 As Label
		Private label6 As Label
		Private lblValidTo As Label
		Private lblValidFrom As Label
		Private lblIssuer As Label
		Private lblSubject As Label
		Private lblProblem As Label
		Private panel2 As Panel
		Private label5 As Label
		Private label4 As Label
		Private label3 As Label
		Private label2 As Label
		Private label1 As Label
		Private _addIssuerCertificateAuthothorityToTrustedCaStore As Boolean = False

		Public WriteOnly Property Hostname() As String
			Set(ByVal value As String)
				lblHostname.Text = value
			End Set
		End Property

		Public WriteOnly Property Subject() As String
			Set(ByVal value As String)
				lblSubject.Text = value
			End Set
		End Property

		Public WriteOnly Property Issuer() As String
			Set(ByVal value As String)
				lblIssuer.Text = value
			End Set
		End Property

		Public WriteOnly Property ValidFrom() As String
			Set(ByVal value As String)
				lblValidFrom.Text = value
			End Set
		End Property

		Public WriteOnly Property ValidTo() As String
			Set(ByVal value As String)
				lblValidTo.Text = value
			End Set
		End Property

		Public WriteOnly Property Problem() As String
			Set(ByVal value As String)
				lblProblem.Text = value
			End Set
		End Property

		Public ReadOnly Property Accepted() As Boolean
			Get
				Return _accepted
			End Get
		End Property

		Public ReadOnly Property AddIssuerCertificateAuthothorityToTrustedCaStore() As Boolean
			Get
				Return _addIssuerCertificateAuthothorityToTrustedCaStore
			End Get
		End Property

		Public Property ShowAddIssuerToTrustedCaStoreButton() As Boolean
			Get
				Return btnOkAndTrust.Visible
			End Get
			Set(ByVal value As Boolean)
				btnOkAndTrust.Visible = value
			End Set
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

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.btnReject = New System.Windows.Forms.Button()
			Me.btnAccept = New System.Windows.Forms.Button()
			Me.btnOkAndTrust = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.panel2 = New System.Windows.Forms.Panel()
			Me.lblProblem = New System.Windows.Forms.Label()
			Me.lblSubject = New System.Windows.Forms.Label()
			Me.lblIssuer = New System.Windows.Forms.Label()
			Me.lblValidFrom = New System.Windows.Forms.Label()
			Me.lblValidTo = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.lblHostname = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' btnReject
			' 
			Me.btnReject.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnReject.Location = New System.Drawing.Point(336, 329)
			Me.btnReject.Name = "btnReject"
			Me.btnReject.Size = New System.Drawing.Size(72, 23)
			Me.btnReject.TabIndex = 2
			Me.btnReject.Text = "Reject"
'			Me.btnReject.Click += New System.EventHandler(Me.btnReject_Click)
			' 
			' btnAccept
			' 
			Me.btnAccept.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnAccept.Location = New System.Drawing.Point(99, 329)
			Me.btnAccept.Name = "btnAccept"
			Me.btnAccept.Size = New System.Drawing.Size(72, 23)
			Me.btnAccept.TabIndex = 1
			Me.btnAccept.Text = "Accept"
'			Me.btnAccept.Click += New System.EventHandler(Me.btnAccept_Click)
			' 
			' btnOkAndTrust
			' 
			Me.btnOkAndTrust.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btnOkAndTrust.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnOkAndTrust.Location = New System.Drawing.Point(177, 329)
			Me.btnOkAndTrust.Name = "btnOkAndTrust"
			Me.btnOkAndTrust.Size = New System.Drawing.Size(153, 23)
			Me.btnOkAndTrust.TabIndex = 5
			Me.btnOkAndTrust.Text = "Always Trust this Authority"
			Me.btnOkAndTrust.Visible = False
'			Me.btnOkAndTrust.Click += New System.EventHandler(Me.btnOkAndTrust_Click)
			' 
			' label1
			' 
			Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(238)))
			Me.label1.Location = New System.Drawing.Point(8, 8)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(256, 23)
			Me.label1.TabIndex = 0
			Me.label1.Text = "CERTIFICATE INFORMATION:"
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 56)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(72, 23)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Subject:"
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 104)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(72, 23)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Issuer:"
			' 
			' label4
			' 
			Me.label4.Location = New System.Drawing.Point(8, 152)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(72, 23)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Valid from:"
			' 
			' label5
			' 
			Me.label5.Location = New System.Drawing.Point(8, 176)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(72, 23)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Valid to:"
			' 
			' panel2
			' 
			Me.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark
			Me.panel2.Location = New System.Drawing.Point(8, 200)
			Me.panel2.Name = "panel2"
			Me.panel2.Size = New System.Drawing.Size(384, 3)
			Me.panel2.TabIndex = 5
			' 
			' lblProblem
			' 
			Me.lblProblem.ForeColor = System.Drawing.Color.Red
			Me.lblProblem.Location = New System.Drawing.Point(8, 216)
			Me.lblProblem.Name = "lblProblem"
			Me.lblProblem.Size = New System.Drawing.Size(384, 72)
			Me.lblProblem.TabIndex = 6
			' 
			' lblSubject
			' 
			Me.lblSubject.Location = New System.Drawing.Point(80, 56)
			Me.lblSubject.Name = "lblSubject"
			Me.lblSubject.Size = New System.Drawing.Size(312, 40)
			Me.lblSubject.TabIndex = 7
			' 
			' lblIssuer
			' 
			Me.lblIssuer.Location = New System.Drawing.Point(80, 104)
			Me.lblIssuer.Name = "lblIssuer"
			Me.lblIssuer.Size = New System.Drawing.Size(312, 40)
			Me.lblIssuer.TabIndex = 8
			' 
			' lblValidFrom
			' 
			Me.lblValidFrom.Location = New System.Drawing.Point(80, 152)
			Me.lblValidFrom.Name = "lblValidFrom"
			Me.lblValidFrom.Size = New System.Drawing.Size(224, 23)
			Me.lblValidFrom.TabIndex = 9
			' 
			' lblValidTo
			' 
			Me.lblValidTo.Location = New System.Drawing.Point(80, 176)
			Me.lblValidTo.Name = "lblValidTo"
			Me.lblValidTo.Size = New System.Drawing.Size(224, 23)
			Me.lblValidTo.TabIndex = 10
			' 
			' label6
			' 
			Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(238)))
			Me.label6.Location = New System.Drawing.Point(8, 8)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(216, 23)
			Me.label6.TabIndex = 11
			Me.label6.Text = "Certificate details:"
			' 
			' label8
			' 
			Me.label8.Location = New System.Drawing.Point(8, 32)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(72, 23)
			Me.label8.TabIndex = 12
			Me.label8.Text = "Hostname:"
			' 
			' lblHostname
			' 
			Me.lblHostname.Location = New System.Drawing.Point(80, 32)
			Me.lblHostname.Name = "lblHostname"
			Me.lblHostname.Size = New System.Drawing.Size(312, 16)
			Me.lblHostname.TabIndex = 13
			' 
			' VerifierForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(418, 364)
			Me.ControlBox = False
			Me.Controls.Add(Me.btnOkAndTrust)
			Me.Controls.Add(Me.btnAccept)
			Me.Controls.Add(Me.btnReject)
			Me.Controls.Add(Me.lblHostname)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.lblValidTo)
			Me.Controls.Add(Me.lblValidFrom)
			Me.Controls.Add(Me.lblIssuer)
			Me.Controls.Add(Me.lblSubject)
			Me.Controls.Add(Me.lblProblem)
			Me.Controls.Add(Me.panel2)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.Name = "VerifierForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Certificate"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub btnAccept_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccept.Click
			_accepted = True
			Me.Close()
		End Sub

		Private Sub btnReject_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReject.Click
			Me.Close()
		End Sub

		Private Sub btnOkAndTrust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOkAndTrust.Click
			_accepted = True
			_addIssuerCertificateAuthothorityToTrustedCaStore = True

			Me.Close()
		End Sub

	End Class
End Namespace

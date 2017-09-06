Namespace FxSocketSamples
	Partial Public Class NewNameForm
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
			Me.lbl = New System.Windows.Forms.Label()
			Me.txtNewName = New System.Windows.Forms.TextBox()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' lbl
			' 
			Me.lbl.Location = New System.Drawing.Point(14, 12)
			Me.lbl.Name = "lbl"
			Me.lbl.Size = New System.Drawing.Size(71, 16)
			Me.lbl.TabIndex = 12
			Me.lbl.Text = "New Name:"
			' 
			' txtNewName
			' 
			Me.txtNewName.Location = New System.Drawing.Point(96, 12)
			Me.txtNewName.Name = "txtNewName"
			Me.txtNewName.Size = New System.Drawing.Size(248, 20)
			Me.txtNewName.TabIndex = 13
			' 
			' btnOk
			' 
			Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnOk.Location = New System.Drawing.Point(189, 38)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 14
			Me.btnOk.Text = "&OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.btnCancel.Location = New System.Drawing.Point(269, 38)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 15
			Me.btnCancel.Text = "&Cancel"
			' 
			' NewNameForm
			' 
			Me.AcceptButton = Me.btnOk
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(352, 69)
			Me.Controls.Add(Me.lbl)
			Me.Controls.Add(Me.txtNewName)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.btnCancel)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "NewNameForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private lbl As System.Windows.Forms.Label
		Private txtNewName As System.Windows.Forms.TextBox
		Private btnOk As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
	End Class
End Namespace
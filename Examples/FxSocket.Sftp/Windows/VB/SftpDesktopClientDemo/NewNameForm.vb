Imports System.ComponentModel
Imports System.Text

Namespace FxSocketSamples
	Partial Public Class NewNameForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal title As String)
			Me.New()
			Me.Text = title
		End Sub

		''' <summary>
		''' Gets the new name.
		''' </summary>
		Public Property NewName() As String
			Get
				Return txtNewName.Text
			End Get
			Set(ByVal value As String)
				txtNewName.Text = value
			End Set
		End Property
	End Class
End Namespace

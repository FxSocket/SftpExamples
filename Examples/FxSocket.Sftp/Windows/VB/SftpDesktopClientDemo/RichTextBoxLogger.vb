Imports FxSocket

Namespace FxSocketSamples
	''' <summary>
	''' Implementation of FxSocket.ILogger which logs to specified RichTextBox.
	''' </summary>
	Public Class RichTextBoxLogger
		Inherits FxSocket.BaseVerboseLogger
		' colors
		Friend Shared ReadOnly COLORRESPONSE As Color = Color.Black ' SFTP response color
		Friend Shared ReadOnly COLORCOMMAND As Color = Color.DarkGreen ' SFTP command color
		Friend Shared ReadOnly COLORERROR As Color = Color.Red ' color of error messages
		Friend Shared ReadOnly COLORINFO As Color = Color.Blue ' info color
		Friend Shared ReadOnly COLORSSH As Color = Color.BlueViolet ' color of SSH comunication
		Friend Shared ReadOnly COLORTLS As Color = Color.BlueViolet ' color of TLS comunication

		Private _textbox As RichTextBox
		Private _maxCharsCount As Integer

		Public Sub New(ByVal textbox As RichTextBox, ByVal maxCharsCount As Integer, ByVal level As LogLevel)
			_textbox = textbox
			_maxCharsCount = maxCharsCount
			Me.Level = level
		End Sub

		Public Overrides Sub Write(ByVal level As LogLevel, ByVal objectType As Type, ByVal objectId As Integer, ByVal area As String, ByVal message As String)
			If level < Me.Level Then
				Return
			End If

			Dim color As Color = COLORINFO

			If level >= LogLevel.Error Then
				color = COLORERROR
			Else
				Select Case area.ToUpper()
					Case "COMMAND"
						color = COLORCOMMAND
					Case "RESPONSE"
						color = COLORRESPONSE
					Case "SSH"
						color = COLORSSH
					Case "TLS"
						color = COLORTLS
				End Select
			End If

			message = String.Format("{0:HH:mm:ss.fff} {1} {2}: {3}" & vbCrLf, Date.Now, level.ToString(), area, message)

			Try
				If Not _textbox.IsDisposed Then
					_textbox.Invoke(New WriteLogHandler(AddressOf WriteLog), New Object() { message, color })
				End If
			Catch e1 As ObjectDisposedException
			End Try
		End Sub

		Private Delegate Sub WriteLogHandler(ByVal message As String, ByVal color As Color)

		Private Sub WriteLog(ByVal message As String, ByVal color As Color)
			EnsureTextSpace(message.Length)

			_textbox.Focus()
			_textbox.SelectionColor = color
			_textbox.AppendText(message)
		End Sub

		Private Sub EnsureTextSpace(ByVal length As Integer)
			If _textbox.TextLength + length < _maxCharsCount Then
				Return
			End If

			Dim spaceLeft As Integer = _maxCharsCount - length

			If spaceLeft <= 0 Then
				_textbox.Clear()
				Return
			End If

			Dim plainText As String = _textbox.Text

			' find the end of line
			Dim start As Integer = plainText.IndexOf(ControlChars.Lf, plainText.Length - spaceLeft)
			If start >= 0 AndAlso start + 1 < plainText.Length Then
				_textbox.SelectionStart = 0
				_textbox.SelectionLength = start + 1

				' setting the SelectedText property is available only when ReadOnly = false
				Dim ro As Boolean = _textbox.ReadOnly
				_textbox.ReadOnly = False
				_textbox.SelectedText = ""
				_textbox.ReadOnly = ro

				_textbox.SelectionStart = _textbox.TextLength
				_textbox.SelectionLength = 0
			Else
				_textbox.Clear()
			End If
		End Sub
	End Class
End Namespace

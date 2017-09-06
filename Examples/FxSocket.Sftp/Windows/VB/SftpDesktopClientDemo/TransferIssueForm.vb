Imports System.IO
Imports System.Collections
Imports System.ComponentModel
Imports FxSocket.IO
Imports FxSocket.FileSystem
Imports FxSocket.Net

Namespace FxSocketSamples
	''' <summary>
	''' Problem handling form.
	''' </summary>
	Public Class TransferIssueForm
		Inherits System.Windows.Forms.Form
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Private lblMessage As System.Windows.Forms.Label
		Private WithEvents btnSkip As System.Windows.Forms.RadioButton
		Private WithEvents btnRename As System.Windows.Forms.RadioButton
		Private btnOverwrite As System.Windows.Forms.RadioButton
		Private btnOverwriteOlder As System.Windows.Forms.RadioButton
		Private btnOverwriteDiffSize As System.Windows.Forms.RadioButton
		Private btnFollowLink As System.Windows.Forms.RadioButton
		Private btnResume As System.Windows.Forms.RadioButton

		' event arguments
		Private _arguments As IssueEventArgs

		' list of problem types the user chose to skip
		Private ReadOnly _skipProblemTypes As New Hashtable()

		' true if the user chose to overwrite all existing files
		Private _overwriteCondition As FileOverwriteCondition

		' true if the user chose to overwrite all older files
		Private btnOverwriteDiffChecksum As RadioButton

		' true if the user chose to overwrite all files with a different size
		Private WithEvents okBtn As Button
		Private WithEvents retryBtn As Button
		Private WithEvents cancelBtn As Button
		Private rememberAction As CheckBox

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()
		End Sub

		''' <summary>
		''' Initialize the form for using it again in new batch transfer.
		''' </summary>
		''' <remarks>
		''' Clears the user's chosen default actions.
		''' </remarks>
		Public Sub Initialize()
			_skipProblemTypes.Clear()
		End Sub

		''' <summary>
		''' Shows the form as a modal dialog box.
		''' The form's buttons are shown according to possible actions taken from the given event argument.
		''' </summary>
		''' <param name="e">Event argument describing the type of a problem.</param>
		Public Sub ShowModal(ByVal form As Control, ByVal e As IssueEventArgs)
			If e Is Nothing Then
				Throw New ArgumentNullException("e")
			End If

			' if the user chose to skip this problem type, skip it
			If _skipProblemTypes.ContainsKey(e.IssueType) Then
				If e.IssueType = TransferIssueType.FileExists Then
					e.Overwrite(_overwriteCondition)
				Else
					e.Skip()
				End If
				Return
			End If

			' if the problem is FileExists check, whether the user have chosen any default action already
			If e.IssueType = TransferIssueType.FileExists Then
				' format the text according to action in progress (Downloading or Uploading)
				Dim messageFormat As String = "Overwrite file: {0}" & vbLf & vbTab & "{1} Bytes, {2}" & vbLf & vbLf & "with file: {3}" & vbLf & vbTab & "{4} Bytes, {5}"
				If e.Action = FileTransferType.Downloading Then
					lblMessage.Text = String.Format(messageFormat, e.LocalPath, e.LocalItem.Length, e.LocalItem.LastWriteTime, e.RemotePath, e.RemoteItem.Length, e.RemoteItem.LastWriteTime)
				Else
					lblMessage.Text = String.Format(messageFormat, e.RemotePath, e.RemoteItem.Length, e.RemoteItem.LastWriteTime, e.LocalPath, e.LocalItem.Length, e.LocalItem.LastWriteTime)
				End If

				lblMessage.TextAlign = ContentAlignment.MiddleLeft
				Me.Text = "Target file already exists"
			Else
				lblMessage.Text = e.Exception.Message
				lblMessage.TextAlign = ContentAlignment.MiddleCenter
			End If

			' store the event arguments for later use at button click handler
			_arguments = e

			' only enable buttons that represent a possible action
			cancelBtn.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Cancel)
			btnSkip.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Skip)
			retryBtn.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Retry)
			btnRename.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Rename)
			btnOverwrite.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite)
			btnOverwriteOlder.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite)
			btnOverwriteDiffSize.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite)
			btnOverwriteDiffChecksum.Enabled = e.IsOverwriteConditionPossible(FileOverwriteCondition.ChecksumDiffers)
			btnFollowLink.Enabled = e.IsReactionPossible(FileTransferIssueReaction.FollowLink)
			btnResume.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Resume)

			' select default action button
			SetDefaultActionButton(e)

			ShowDialog(form)
		End Sub

		''' <summary>
		''' Selects the button according to default action.
		''' </summary>
		''' <param name="action">Default action.</param>
		Private Sub SetDefaultActionButton(ByVal e As IssueEventArgs)
			Select Case e.Reaction
				Case FileTransferIssueReaction.Cancel
					cancelBtn.Select()
				Case FileTransferIssueReaction.Fail
					cancelBtn.Select()
				Case FileTransferIssueReaction.Skip
					btnSkip.Select()
				Case FileTransferIssueReaction.Retry
					retryBtn.Select()
				Case FileTransferIssueReaction.Rename
					btnRename.Select()
				Case FileTransferIssueReaction.FollowLink
					btnFollowLink.Select()
				Case FileTransferIssueReaction.Resume
					btnResume.Select()
				Case FileTransferIssueReaction.Overwrite
					Select Case e.OverwriteCondition
						Case FileOverwriteCondition.None
							btnOverwrite.Select()
						Case FileOverwriteCondition.Older
							btnOverwriteOlder.Select()
						Case FileOverwriteCondition.SizeDiffers
							btnOverwriteDiffSize.Select()
						Case FileOverwriteCondition.ChecksumDiffers
							btnOverwriteDiffChecksum.Select()
					End Select
			End Select
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
			Me.btnSkip = New System.Windows.Forms.RadioButton()
			Me.btnRename = New System.Windows.Forms.RadioButton()
			Me.btnOverwrite = New System.Windows.Forms.RadioButton()
			Me.btnOverwriteOlder = New System.Windows.Forms.RadioButton()
			Me.btnOverwriteDiffSize = New System.Windows.Forms.RadioButton()
			Me.btnFollowLink = New System.Windows.Forms.RadioButton()
			Me.lblMessage = New System.Windows.Forms.Label()
			Me.btnResume = New System.Windows.Forms.RadioButton()
			Me.btnOverwriteDiffChecksum = New System.Windows.Forms.RadioButton()
			Me.okBtn = New System.Windows.Forms.Button()
			Me.retryBtn = New System.Windows.Forms.Button()
			Me.cancelBtn = New System.Windows.Forms.Button()
			Me.rememberAction = New System.Windows.Forms.CheckBox()
			Me.SuspendLayout()
			' 
			' btnSkip
			' 
			Me.btnSkip.Location = New System.Drawing.Point(271, 160)
			Me.btnSkip.Name = "btnSkip"
			Me.btnSkip.Size = New System.Drawing.Size(179, 24)
			Me.btnSkip.TabIndex = 7
			Me.btnSkip.Text = "&Skip"
'			Me.btnSkip.Click += New System.EventHandler(Me.btnSkip_Click)
			' 
			' btnRename
			' 
			Me.btnRename.Location = New System.Drawing.Point(271, 130)
			Me.btnRename.Name = "btnRename"
			Me.btnRename.Size = New System.Drawing.Size(157, 24)
			Me.btnRename.TabIndex = 6
			Me.btnRename.Text = "&Rename..."
'			Me.btnRename.Click += New System.EventHandler(Me.btnRename_Click)
			' 
			' btnOverwrite
			' 
			Me.btnOverwrite.Location = New System.Drawing.Point(12, 100)
			Me.btnOverwrite.Name = "btnOverwrite"
			Me.btnOverwrite.Size = New System.Drawing.Size(157, 24)
			Me.btnOverwrite.TabIndex = 1
			Me.btnOverwrite.Text = "&Overwrite"
			' 
			' btnOverwriteOlder
			' 
			Me.btnOverwriteOlder.Location = New System.Drawing.Point(12, 130)
			Me.btnOverwriteOlder.Name = "btnOverwriteOlder"
			Me.btnOverwriteOlder.Size = New System.Drawing.Size(157, 24)
			Me.btnOverwriteOlder.TabIndex = 2
			Me.btnOverwriteOlder.Text = "Overwrite Older File"
			' 
			' btnOverwriteDiffSize
			' 
			Me.btnOverwriteDiffSize.Location = New System.Drawing.Point(11, 160)
			Me.btnOverwriteDiffSize.Name = "btnOverwriteDiffSize"
			Me.btnOverwriteDiffSize.Size = New System.Drawing.Size(157, 24)
			Me.btnOverwriteDiffSize.TabIndex = 3
			Me.btnOverwriteDiffSize.Text = "Overwrite &If Size Differs"
			' 
			' btnFollowLink
			' 
			Me.btnFollowLink.Location = New System.Drawing.Point(271, 190)
			Me.btnFollowLink.Name = "btnFollowLink"
			Me.btnFollowLink.Size = New System.Drawing.Size(157, 24)
			Me.btnFollowLink.TabIndex = 8
			Me.btnFollowLink.Text = "Follow &Link"
			' 
			' lblMessage
			' 
			Me.lblMessage.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lblMessage.Location = New System.Drawing.Point(8, 8)
			Me.lblMessage.Name = "lblMessage"
			Me.lblMessage.Size = New System.Drawing.Size(580, 89)
			Me.lblMessage.TabIndex = 11
			Me.lblMessage.Text = "Message"
			Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' btnResume
			' 
			Me.btnResume.Location = New System.Drawing.Point(271, 100)
			Me.btnResume.Name = "btnResume"
			Me.btnResume.Size = New System.Drawing.Size(179, 24)
			Me.btnResume.TabIndex = 5
			Me.btnResume.Text = "Resume"
			' 
			' btnOverwriteDiffChecksum
			' 
			Me.btnOverwriteDiffChecksum.Location = New System.Drawing.Point(11, 190)
			Me.btnOverwriteDiffChecksum.Name = "btnOverwriteDiffChecksum"
			Me.btnOverwriteDiffChecksum.Size = New System.Drawing.Size(179, 24)
			Me.btnOverwriteDiffChecksum.TabIndex = 4
			Me.btnOverwriteDiffChecksum.Text = "Overwrite If Checksum Differs"
			' 
			' okBtn
			' 
			Me.okBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.okBtn.Location = New System.Drawing.Point(349, 264)
			Me.okBtn.Name = "okBtn"
			Me.okBtn.Size = New System.Drawing.Size(75, 23)
			Me.okBtn.TabIndex = 31
			Me.okBtn.Text = "OK"
			Me.okBtn.UseVisualStyleBackColor = True
'			Me.okBtn.Click += New System.EventHandler(Me.okBtn_Click)
			' 
			' retryBtn
			' 
			Me.retryBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.retryBtn.Location = New System.Drawing.Point(430, 264)
			Me.retryBtn.Name = "retryBtn"
			Me.retryBtn.Size = New System.Drawing.Size(75, 23)
			Me.retryBtn.TabIndex = 32
			Me.retryBtn.Text = "Retry"
			Me.retryBtn.UseVisualStyleBackColor = True
'			Me.retryBtn.Click += New System.EventHandler(Me.btnRetry_Click)
			' 
			' cancelBtn
			' 
			Me.cancelBtn.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.cancelBtn.Location = New System.Drawing.Point(511, 264)
			Me.cancelBtn.Name = "cancelBtn"
			Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
			Me.cancelBtn.TabIndex = 33
			Me.cancelBtn.Text = "Cancel"
			Me.cancelBtn.UseVisualStyleBackColor = True
'			Me.cancelBtn.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' rememberAction
			' 
			Me.rememberAction.AutoSize = True
			Me.rememberAction.Location = New System.Drawing.Point(11, 230)
			Me.rememberAction.Name = "rememberAction"
			Me.rememberAction.Size = New System.Drawing.Size(141, 17)
			Me.rememberAction.TabIndex = 20
			Me.rememberAction.Text = "Use this action next time"
			Me.rememberAction.UseVisualStyleBackColor = True
			' 
			' TransferIssueForm
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(598, 299)
			Me.Controls.Add(Me.rememberAction)
			Me.Controls.Add(Me.cancelBtn)
			Me.Controls.Add(Me.retryBtn)
			Me.Controls.Add(Me.okBtn)
			Me.Controls.Add(Me.btnOverwrite)
			Me.Controls.Add(Me.btnOverwriteOlder)
			Me.Controls.Add(Me.btnOverwriteDiffChecksum)
			Me.Controls.Add(Me.btnResume)
			Me.Controls.Add(Me.lblMessage)
			Me.Controls.Add(Me.btnFollowLink)
			Me.Controls.Add(Me.btnOverwriteDiffSize)
			Me.Controls.Add(Me.btnRename)
			Me.Controls.Add(Me.btnSkip)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "TransferIssueForm"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Transfer Problem Detected"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub
		#End Region

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelBtn.Click
			_arguments.Cancel()
			Close()
		End Sub

		Private Sub btnSkip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSkip.Click
			_arguments.Skip()
			Close()
		End Sub

		Private Sub btnRetry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles retryBtn.Click
			_arguments.Retry()
			Close()
		End Sub

		Private Sub btnRename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRename.Click
			' initialize the renaming form
			Dim formNewName As New NewNameForm()

			' set the current file name
			Dim oldName As String = Path.GetFileName(_arguments.LocalPath)
			formNewName.NewName = oldName

			' show the form
			Dim result As DialogResult = formNewName.ShowDialog(Me)

			' get the new name
			Dim newName As String = formNewName.NewName

			' check whether the user clicked on OK and insert something nonempty and something else
			If result <> System.Windows.Forms.DialogResult.OK OrElse newName.Length = 0 OrElse newName = oldName Then
				Return
			End If

			' set the appropriate action and new name to the event arguments
			_arguments.Rename(newName)
			Close()
		End Sub

		Private Sub DoAction()
			If btnSkip.Checked Then
				_arguments.Skip()
			ElseIf btnOverwrite.Checked Then
				_arguments.Overwrite()
				_overwriteCondition = FileOverwriteCondition.None
			ElseIf btnOverwriteOlder.Checked Then
				_arguments.Overwrite(FileOverwriteCondition.Older)
				_overwriteCondition = FileOverwriteCondition.Older
			ElseIf btnOverwriteDiffSize.Checked Then
				_arguments.Overwrite(FileOverwriteCondition.SizeDiffers)
				_overwriteCondition = FileOverwriteCondition.SizeDiffers
			ElseIf btnOverwriteDiffChecksum.Checked Then
				_arguments.Overwrite(FileOverwriteCondition.ChecksumDiffers)
				_overwriteCondition = FileOverwriteCondition.ChecksumDiffers
			ElseIf btnFollowLink.Checked Then
				_arguments.FollowLink()
			ElseIf btnResume.Checked Then
				_arguments.Resume()
			End If

			Close()
		End Sub

		Private Sub okBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles okBtn.Click
			If rememberAction.Checked Then
				' add the problem to the table of automatically skipped problems
				_skipProblemTypes.Add(_arguments.IssueType, Nothing)
			End If

			DoAction()
		End Sub
	End Class
End Namespace

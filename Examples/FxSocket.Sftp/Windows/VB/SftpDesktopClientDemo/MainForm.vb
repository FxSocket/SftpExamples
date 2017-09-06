Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports FxSocket
Imports FxSocket.FileSystem
#If Not NETFX20 Then
Imports FxSocket.Legacy
#End If
Imports FxSocket.Net

Namespace FxSocketSamples
	Partial Public Class MainForm
		Inherits Form
		#Region "Private Fields"

		Private _initialized As Boolean
		Private _busy As Boolean
		Private _ftp As Sftp
		Private _startTime As Date
		Private _rootServerDir As String
		Private _serverListSelected As Boolean
		Private _problemForm As TransferIssueForm ' informs the user about problems while transferring data

		#End Region

		Public Sub New()
			FxSocket.Licensing.Key = FxSocket.Examples.TrialKey.Key
			CheckForIllegalCrossThreadCalls = False

			InitializeComponent()

			_problemForm = New TransferIssueForm()


'			#Region "Local"

			Dim path As String = Path.GetFullPath(".")
			tbxLocalFolder.Text = path
			lvLocal.ListViewItemSorter = New ListViewColumnSorter()
			PopulateLocalList(path)
			PopulateLocalDriverList(path.Substring(0, 3))

'			#End Region

'			#Region "Server"

			lvServer.ListViewItemSorter = New ListViewColumnSorter()
			cbTransferMode.SelectedIndex = 0
			SetConnectedState(False)

'			#End Region

			_initialized = True
		End Sub

		Private Sub miQuit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miQuit.Click
			Me.Close()
		End Sub

		#Region "Local List"

		Private ReadOnly Property IsLocalListSelected() As Boolean
			Get
				Return lvLocal.Focused
			End Get
		End Property

		Private Sub PopulateLocalDriverList(ByVal selectedDrive As String)
			Dim drives() As String = Directory.GetLogicalDrives()

			' populate the drives' list and select one
			For c As Integer = 0 To drives.Length - 1
				Dim drive As String = drives(c)

				cbDrives.Items.Add(drive)
				If String.CompareOrdinal(drive, selectedDrive) = 0 Then
					cbDrives.SelectedIndex = c
				End If
			Next c
		End Sub

		Private Sub PopulateLocalList(ByVal path As String)
			Dim directory As New DirectoryInfo(path)

			Dim dirList() As DirectoryInfo = directory.GetDirectories()
			Dim fileList() As FileInfo = directory.GetFiles()

			Dim dirs As Integer = 0
			Dim files As Integer = 0
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Long = 0

			' Clear the local list
			lvLocal.Items.Clear()

			' directory up
			If path.Length > 3 Then
				Dim item As New ListViewItem("..", 1)
				item.Tag = New ListItemInfo(Path.GetDirectoryName(path), True, True, False, False)
				lvLocal.Items.Add(item)
				dirs += 1
			End If

			' Populate directories
			For c As Integer = 0 To dirList.Length - 1
				Dim row(3) As String
				Dim dirInfo As DirectoryInfo = dirList(c)

				row(0) = dirInfo.Name ' Name
				row(1) = "" ' Ext
				row(2) = "" ' Size

				' Last Write Time
				Try
					row(3) = Common.FormatTime(dirList(c).LastWriteTime)
				Catch
					row(3) = ""
				End Try

				Dim item As New ListViewItem(row, 1 + c)
				item.ImageIndex = 1
				item.Tag = New ListItemInfo(dirInfo.FullName, False, True, False, False)
				lvLocal.Items.Add(item)
				dirs += 1
			Next c

			' Populate files
			For c As Integer = 0 To fileList.Length - 1
				Dim fileInfo As FileInfo = fileList(c)

				Dim row(3) As String
				row(0) = Path.GetFileNameWithoutExtension(fileInfo.Name) ' Name
				row(1) = Path.GetExtension(fileInfo.Name) ' Ext
				row(2) = Common.BytesToString(fileInfo.Length)
				row(3) = Common.FormatTime(fileInfo.LastWriteTime)

				Dim item As New ListViewItem(row, 1 + dirs + files)
				item.ImageIndex = 0
				item.Tag = New ListItemInfo(fileInfo.FullName, False, False, True, False)
				lvLocal.Items.Add(item)
				size_Renamed += fileInfo.Length
				files += 1
			Next c

			' Update stats
			UpdateListStats(lbLocalStats, dirs, files, size_Renamed)
		End Sub

		Private Sub UpdateListStats(ByVal llb As Label, ByVal dirs As Integer, ByVal files As Integer, ByVal totalBytes As Long)
			llb.Text = String.Format("{0} folder(s), {1} file(s) in {2}", dirs, files, Common.BytesToString(totalBytes))
		End Sub

		Private Sub UpdateLocalList(ByVal newPath As String)
			Try
				newPath = Path.GetFullPath(newPath)
				PopulateLocalList(newPath)
				tbxLocalFolder.Text = newPath
			Catch ex As Exception
				Log(ex)
			End Try
		End Sub

		Private Sub UpdateServerList(ByVal newPath As String)
			Try
				PopulateServerList(newPath)
				tbxServerFolder.Text = newPath
			Catch ex As Exception
				Log(ex)
			End Try
		End Sub

		#Region "Event Handlers"

		Private Sub cbDrives_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbDrives.SelectedIndexChanged
			If _initialized Then
				UpdateLocalList(cbDrives.SelectedItem.ToString())
			End If
		End Sub

		Private Sub lvLocal_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvLocal.DoubleClick
			Dim dirName As String = CType(lvLocal.SelectedItems(0).Tag, ListItemInfo).FullPath

			UpdateLocalList(dirName)
		End Sub

		Private Sub tbxLocalFolder_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles tbxLocalFolder.KeyDown
			If (Not e.Control) AndAlso (Not e.Alt) AndAlso (Not e.Shift) AndAlso e.KeyCode = Keys.Enter Then
				UpdateLocalList(tbxLocalFolder.Text)
			End If
		End Sub

		Private Function GetSelectedItems(ByVal lv As ListView) As List(Of ListItemInfo)
			Dim selectedItems As New List(Of ListItemInfo)()
			For Each item As ListViewItem In lv.SelectedItems
				' Dont count ".." up dir
				If String.CompareOrdinal(item.Text, "..") = 0 Then
					Continue For
				End If

				selectedItems.Add(CType(item.Tag, ListItemInfo))
			Next item

			Return selectedItems
		End Function

		Private Sub ListViewSelectIndexChanged(ByVal lv As ListView)
			Dim selectedItems As List(Of ListItemInfo) = GetSelectedItems(lv)

			miCreateFolder.Enabled = True
			btNewFolder.Enabled = miCreateFolder.Enabled

			btDelete.Enabled = selectedItems.Count > 0
			miMove.Enabled = btDelete.Enabled
			miDelete.Enabled = miMove.Enabled
			miCopy.Enabled = miDelete.Enabled

			btMove.Enabled = selectedItems.Count > 0 AndAlso _ftp IsNot Nothing
			btCopy.Enabled = btMove.Enabled

			If selectedItems.Count = 1 Then
				Dim info As ListItemInfo = selectedItems(0)
				btEdit.Enabled = info.IsFile
				btView.Enabled = btEdit.Enabled
				miEdit.Enabled = btView.Enabled
				miView.Enabled = miEdit.Enabled
			Else ' No files or directories selected or more than one item selected
				btEdit.Enabled = False
				btView.Enabled = btEdit.Enabled
				miEdit.Enabled = btView.Enabled
				miView.Enabled = miEdit.Enabled
			End If
		End Sub

		Private Sub lvLocal_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lvLocal.SelectedIndexChanged
			_serverListSelected = False
			ListViewSelectIndexChanged(lvLocal)
		End Sub

		#End Region

		#End Region

		#Region "Server"

		''' <summary>
		''' show transfer status: files, bytes, time, speed
		''' </summary>
		Private Sub ShowTransferStats(ByVal bytesTransferred As Long, ByVal filesTransferred As Integer)
			' unknown bytes transferred
			If bytesTransferred = 0 Then
				Return
			End If

			' files and bytes transferred
			Dim outstring As String
			If filesTransferred > 1 Then
				If bytesTransferred > 1 Then
					outstring = String.Format("{0} file{1} ({2} byte{3}) transferred in", filesTransferred, ("s"), bytesTransferred, ("s"))
				Else
					outstring = String.Format("{0} file{1} ({2} byte{3}) transferred in", filesTransferred, ("s"), bytesTransferred, (Nothing))
				End If
			Else
				If bytesTransferred > 1 Then
					outstring = String.Format("{0} file{1} ({2} byte{3}) transferred in", filesTransferred, (Nothing), bytesTransferred, ("s"))
				Else
					outstring = String.Format("{0} file{1} ({2} byte{3}) transferred in", filesTransferred, (Nothing), bytesTransferred, (Nothing))
				End If
			End If

			' time spent
			Dim ts As TimeSpan = Date.Now.Subtract(_startTime)

			' speed
			If ts.TotalSeconds > 1 Then
				If ts.Days > 0 Then
					If ts.Days > 1 Then
						outstring &= (" " & ts.Days & " day" & ("s"))
					Else
						outstring &= (" " & ts.Days & " day" & (Nothing))
					End If
				Else
					outstring &= (Nothing)
				End If
				If ts.Hours > 0 Then
					If ts.Hours > 1 Then
						outstring &= (" " & ts.Hours & " hour" & ("s"))
					Else
						outstring &= (" " & ts.Hours & " hour" & (Nothing))
					End If
				Else
					outstring &= (Nothing)
				End If
				If ts.Minutes > 0 Then
					If ts.Minutes > 1 Then
						outstring &= (" " & ts.Minutes & " min" & ("s"))
					Else
						outstring &= (" " & ts.Minutes & " min" & (Nothing))
					End If
				Else
					outstring &= (Nothing)
				End If
				If ts.Seconds > 0 Then
					If ts.Seconds > 1 Then
						outstring &= (" " & ts.Seconds & " sec" & ("s"))
					Else
						outstring &= (" " & ts.Seconds & " sec" & (Nothing))
					End If
				Else
					outstring &= (Nothing)
				End If
			Else
				outstring &= " " & ts.TotalSeconds & " sec"
			End If

			Dim speed As Double = bytesTransferred / ts.TotalSeconds
			If speed < 1 Then
				outstring &= String.Format(" at {0:F3} B/s", speed)
			ElseIf speed < 1024 Then
				outstring &= String.Format(" at {0:F0} B/s", speed)
			Else
				outstring &= String.Format(" at {0:F0} KB/s", speed / 1024)
			End If


			Log("> " & outstring, RichTextBoxLogger.COLORCOMMAND)
		End Sub

		Private Sub SetConnectedState(ByVal connected As Boolean)
			cbModeZ.Enabled = connected
			numSpeedLimit.Enabled = cbModeZ.Enabled
			cbTransferMode.Enabled = numSpeedLimit.Enabled
			If connected Then
				miConnect.Text = "Disconnect"
				btConnect.Text = miConnect.Text
			Else
				miConnect.Text = "Connect..."
				btConnect.Text = miConnect.Text
			End If
			miCopy.Enabled = connected
			btCopy.Enabled = miCopy.Enabled
			tbxServerFolder.Enabled = connected
			tbxLog.Enabled = connected

			If Not connected Then
				tbxServerFolder.Text = ""
				lvServer.Items.Clear()
				lbServerStats.Text = "Not Connected"
			End If
		End Sub

		Private Sub ShowProgressBar(ByVal show As Boolean)
			progressBar.Visible = show
			lbProgress.Visible = progressBar.Visible
			btRefresh.Visible = Not show
			btDelete.Visible = btRefresh.Visible
			btNewFolder.Visible = btDelete.Visible
			btMove.Visible = btNewFolder.Visible
			btCopy.Visible = btMove.Visible
			btView.Visible = btCopy.Visible

			If show Then
				_startTime = Date.Now
			End If
		End Sub

		Private Sub PopulateServerList(ByVal path As String)
			Dim items As SftpItemCollection = _ftp.GetList()

			Dim dirs As Integer = 0
			Dim files As Integer = 0
'INSTANT VB NOTE: The variable size was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim size_Renamed As Long = 0

			' Clear the local list
			lvServer.Items.Clear()

			' directory up
			If path.Length > _rootServerDir.Length Then
				Dim item As New ListViewItem("..", 1)
				Dim n As Integer = path.LastIndexOf("/"c)
				If n > 0 Then
					item.Tag = New ListItemInfo(path.Substring(0, n), True, True, False, False)
				Else
					item.Tag = New ListItemInfo("/", True, True, False, False)
				End If
				lvServer.Items.Add(item)
				dirs += 1
			End If

			' Populate files and directories
			For c As Integer = 0 To items.Count - 1
				Dim row(4) As String
				Dim dirInfo As SftpItem = items(c)

				If dirInfo.Name = "." OrElse dirInfo.Name = ".." Then
					Continue For
				End If

				row(0) = Path.GetFileNameWithoutExtension(dirInfo.Name) ' Name
				row(1) = Path.GetExtension(dirInfo.Name) ' Ext
				row(2) = Common.BytesToString(dirInfo.Length) ' Size
				row(3) = Common.FormatTime(dirInfo.LastWriteTime) ' Last Write Time
				If dirInfo.Permissions IsNot Nothing Then
					row(4) = dirInfo.Permissions.ToString()
				End If

				Dim item As New ListViewItem(row, 1 + c)
				item.Tag = New ListItemInfo(path.TrimEnd("/"c, "\"c) & "/" & dirInfo.Name, False, dirInfo.IsDirectory, dirInfo.IsFile, dirInfo.IsLink)
				If dirInfo.IsDirectory Then
					item.ImageIndex = 1
					dirs += 1
				ElseIf dirInfo.IsFile Then
					item.ImageIndex = 0
					files += 1
					size_Renamed += dirInfo.Length
				End If
				'else if (dirInfo.IsLink)
				'{
				'    item.ImageIndex = 2;
				'}
				lvServer.Items.Add(item)
			Next c

			' Update stats
			UpdateListStats(lbServerStats, dirs, files, size_Renamed)
		End Sub

		#Region "Event Handlers"

		Private Sub btConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btConnect.Click
			If _busy Then
				Return
			End If

			If _ftp IsNot Nothing Then
				_ftp.Disconnect()
				_ftp.Dispose()
				_ftp = Nothing

				SetConnectedState(False)
				Return
			End If

			Dim dlg As New ConnectForm()
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				_ftp = New Sftp()

				_ftp.LogWriter = New RichTextBoxLogger(tbxLog, tbxLog.MaxLength, LogLevel.Info)
				' set event handlers
				AddHandler _ftp.StateChanged, AddressOf OnStateChanged
				AddHandler _ftp.Scanning, AddressOf OnScanning
				AddHandler _ftp.TransferProgressChanged, AddressOf OnTransferProgress
				AddHandler _ftp.DeleteProgressChanged, AddressOf OnDeleteProgress
				AddHandler _ftp.FileTransferIssue, AddressOf OnFileTransferIssue
				_ftp.Settings.DisableSftp4 = Not dlg.Version4

				Try
					_ftp.BeginConnect(dlg.Server, dlg.Port, AddressOf OnConnectFinish, dlg)
				Catch ex As Exception
					Log(ex)
					SetConnectedState(False)
				End Try
			End If
		End Sub

		Private Sub OnConnectFinish(ByVal asyncResult As IAsyncResult)
			Try
				_ftp.EndConnect(asyncResult)

				Dim dlg As ConnectForm = CType(asyncResult.AsyncState, ConnectForm)

				If Not _ftp.IsAuthenticated Then
					_ftp.Login(dlg.UserName, dlg.Password)
				End If

				_rootServerDir = _ftp.GetCurrentDirectory()
				tbxServerFolder.Text = _rootServerDir

				PopulateServerList(_rootServerDir)

				SetConnectedState(True)
			Catch ex As Exception
				Log(ex)
				SetConnectedState(False)
				Return
			End Try
		End Sub

		''' <summary>
		''' event displaying ftp state
		''' </summary>
		Private Sub OnStateChanged(ByVal sender As Object, ByVal e As SftpStateChangedEventArgs)
			Select Case e.NewState
				Case SftpState.Disconnected, SftpState.Disposed
					SetConnectedState(False)
				Case SftpState.Ready
			End Select
		End Sub

		''' <summary>
		''' handles the displaying traversing event
		''' </summary>
		Private Sub OnScanning(ByVal sender As Object, ByVal e As SftpDirectoryScanningEventArgs)
			If e.Action = FileTransferType.Listing Then
				Return
			End If

			Dim strBatchInfo As String
			If e.FilesTotal > 1 Then
				strBatchInfo = String.Format("({0} file{1} traversed)    ", e.FilesTotal, ("s"))
			Else
				strBatchInfo = String.Format("({0} file{1} traversed)    ", e.FilesTotal, (Nothing))
			End If

			Select Case e.TraversingState
				Case DirectoryScanningState.DirectoryRetrieved
					strBatchInfo &= "Directory retrieved."
				Case DirectoryScanningState.DirectoryRetrieving
					strBatchInfo &= "Retrieving directory..."
				Case DirectoryScanningState.HierarchyRetrieved
					If e.BytesTotal > 1 Then
						If e.FilesTotal > 1 Then
							strBatchInfo &= String.Format("Hierarchy retrieved ({0} byte{1} in {2} file{3}).", e.BytesTotal, ("s"), e.FilesTotal, ("s"))
						Else
							strBatchInfo &= String.Format("Hierarchy retrieved ({0} byte{1} in {2} file{3}).", e.BytesTotal, ("s"), e.FilesTotal, (Nothing))
						End If
					Else
						If e.FilesTotal > 1 Then
							strBatchInfo &= String.Format("Hierarchy retrieved ({0} byte{1} in {2} file{3}).", e.BytesTotal, (Nothing), e.FilesTotal, ("s"))
						Else
							strBatchInfo &= String.Format("Hierarchy retrieved ({0} byte{1} in {2} file{3}).", e.BytesTotal, (Nothing), e.FilesTotal, (Nothing))
						End If
					End If
				Case DirectoryScanningState.HierarchyRetrieving
					strBatchInfo &= "Retrieving hierarchy..."
			End Select

			lbProgress.Text = strBatchInfo
		End Sub

		''' <summary>
		''' handles the transfer progress changed event
		''' </summary>
		Private Sub OnTransferProgress(ByVal sender As Object, ByVal e As SftpFileTransferProgressEventArgs)
			Dim info As String
			If e.FilesProcessed > 1 Then
				info = String.Format("({0} / {1} file{2} processed)    ", e.FilesProcessed, e.FilesTotal, ("s"))
			Else
				info = String.Format("({0} / {1} file{2} processed)    ", e.FilesProcessed, e.FilesTotal, (Nothing))
			End If

			SetProgressValue(Convert.ToInt32(e.ProgressPercentage))

			Select Case e.TransferState
				Case FileTransferProgressState.DataBlockProcessed
					AddHandler info, AddressOf Common.BytesToString
				Case FileTransferProgressState.DirectoryProcessing
					info &= "Processing directory..."
				Case FileTransferProgressState.FileTransferring
					info &= "Transferring file..."
				Case FileTransferProgressState.FileTransferred
					info &= "File transferred."
				Case FileTransferProgressState.TransferCompleted
					info &= "Transfer completed."
					ShowTransferStats(e.BytesTransferred, e.FilesTransferred)
			End Select

			lbProgress.Text = info
		End Sub

		Private Sub SetProgressValue(ByVal value As Integer)
			' workaround for progress bar smoothing
			If value = 100 Then
				progressBar.Maximum = 101
				progressBar.Value = 101
				progressBar.Maximum = 100
				System.Threading.Thread.Sleep(200)
			Else
				progressBar.Value = value
			End If
		End Sub

		''' <summary>
		''' handles the delete progress changed event
		''' </summary>
		Private Sub OnDeleteProgress(ByVal sender As Object, ByVal e As SftpDeleteProgressEventArgs)
			Dim strDeleteInfo As String
			If e.FilesProcessed > 1 Then
				strDeleteInfo = String.Format("({0} / {1} file{2} deleted)    ", e.FilesProcessed, e.FilesTotal, ("s"))
			Else
				strDeleteInfo = String.Format("({0} / {1} file{2} deleted)    ", e.FilesProcessed, e.FilesTotal, (Nothing))
			End If

			Select Case e.DeleteState
				Case DeleteProgressState.DeleteCompleted
					strDeleteInfo &= "Delete completed."
				Case DeleteProgressState.DirectoryDeleted
					strDeleteInfo &= "Directory deleted."
				Case DeleteProgressState.DirectoryProcessing
					strDeleteInfo &= "Processing directory..."
				Case DeleteProgressState.FileDeleted
					strDeleteInfo &= "File deleted."
				Case DeleteProgressState.FileDeleting
					strDeleteInfo &= "Deleting file..."
			End Select

			lbProgress.Text = strDeleteInfo
		End Sub

		''' <summary>
		''' handles the batch transfer problem detected event
		''' </summary>
		Private Sub OnFileTransferIssue(ByVal sender As Object, ByVal e As SftpIssueEventArgs)
			_problemForm.ShowModal(Me, e)
		End Sub

		Private Sub miConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miConnect.Click
			btConnect_Click(Nothing, e)
		End Sub

		Private Sub miDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miCopy.Click
			btCopy_Click(Nothing, Nothing)
		End Sub

		#End Region

		#End Region

		#Region "Diagnostics"

		Private Sub Log(ByVal ex As Exception)
			MessageBox.Show(Me, ex.Message, "Error")
		End Sub

		Private Sub Log(ByVal message As String, ByVal color As Color)

		End Sub

		#End Region

		Private Sub miCreateFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miCreateFolder.Click
			btNewFolder_Click(Nothing, Nothing)
		End Sub

		Private Sub miDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miDelete.Click
			btDelete_Click(Nothing, Nothing)
		End Sub

		Private Sub moveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miMove.Click
			btMove_Click(Nothing, Nothing)
		End Sub

		Private Sub miRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miRefresh.Click
			btRefresh_Click(Nothing, Nothing)
		End Sub

		Private Sub viewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miView.Click
			btView_Click(Nothing, Nothing)
		End Sub

		Private Sub editToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles miEdit.Click
			btEdit_Click(Nothing, Nothing)
		End Sub

		Private Sub lvServer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lvServer.SelectedIndexChanged
			_serverListSelected = True
			ListViewSelectIndexChanged(lvServer)
		End Sub

		Private Sub lvLocal_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvLocal.KeyDown
			If (Not e.Control) AndAlso (Not e.Alt) AndAlso (Not e.Shift) Then
				Select Case e.KeyCode
					Case Keys.Enter
						lvLocal_DoubleClick(Nothing, Nothing)

					Case Keys.Delete
						btDelete_Click(Nothing, Nothing)
				End Select
			End If
		End Sub

		Private Sub lvServer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles lvServer.KeyDown
			If (Not e.Control) AndAlso (Not e.Alt) AndAlso (Not e.Shift) Then
				Select Case e.KeyCode
					Case Keys.Enter
						lvServer_DoubleClick(Nothing, Nothing)

					Case Keys.Delete
						btDelete_Click(Nothing, Nothing)
				End Select
			End If
		End Sub

		Private Sub lvServer_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lvServer.DoubleClick
			Dim dirName As String = CType(lvServer.SelectedItems(0).Tag, ListItemInfo).FullPath

			Try
				_ftp.ChangeDirectory(dirName)
				UpdateServerList(dirName)
			Catch ex As Exception
				Log(ex)
			End Try
		End Sub

		Private Sub btView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btView.Click
			Try
				If _serverListSelected Then
					Dim items As List(Of ListItemInfo) = GetSelectedItems(lvServer)
					If items.Count > 0 Then
						Dim tmpFile As String = Path.GetTempFileName() & "-" & Path.GetFileName(items(0).FullPath)
						_ftp.GetFile(items(0).FullPath, tmpFile)

						Process.Start("notepad", tmpFile)
					End If
				Else
					Dim items As List(Of ListItemInfo) = GetSelectedItems(lvLocal)
					If items.Count > 0 Then
						Process.Start("notepad", items(0).FullPath)
					End If
				End If
			Catch ex As Exception
				Log(ex)
			End Try
		End Sub

		Private Sub btEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btEdit.Click
			' Should be implemented by developer
		End Sub

		Private Sub btCopy_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btCopy.Click
			Try
				If _serverListSelected Then
					Dim items As List(Of ListItemInfo) = GetSelectedItems(lvServer)
					If items.Count > 0 Then
						ShowProgressBar(True)
						For Each item As ListItemInfo In items
							_ftp.Download(item.FullPath, tbxLocalFolder.Text, SearchMode.Recursive, FileCopyType.Copy, OverwriteMode.ThrowException)
						Next item

						UpdateLocalList(tbxLocalFolder.Text)
					End If
				Else
					Dim items As List(Of ListItemInfo) = GetSelectedItems(lvLocal)
					If items.Count > 0 Then
						ShowProgressBar(True)
						For Each item As ListItemInfo In items
							_ftp.Upload(item.FullPath, tbxServerFolder.Text, SearchMode.Recursive, FileCopyType.Copy, OverwriteMode.ThrowException)
						Next item

						UpdateServerList(tbxServerFolder.Text)
					End If
				End If
			Catch ex As Exception
				Log(ex)
			Finally
				ShowProgressBar(False)
			End Try
		End Sub

		Private Sub btMove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btMove.Click

		End Sub

		Private Sub btNewFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btNewFolder.Click
			Dim dlg As New NewNameForm("New Folder")
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					If _serverListSelected Then
						_ftp.CreateDirectory(dlg.NewName)
						UpdateServerList(tbxServerFolder.Text.TrimEnd("/"c, "\"c) & "/" & dlg.NewName)
					Else
						Directory.CreateDirectory(Path.Combine(tbxLocalFolder.Text, dlg.NewName))
						UpdateLocalList(tbxLocalFolder.Text)
					End If
				Catch ex As Exception
					Log(ex)
				End Try
			End If
		End Sub

		Private Sub btDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btDelete.Click
			Dim selectedItems As List(Of ListItemInfo)
			If _serverListSelected Then
				selectedItems = GetSelectedItems(lvServer)
			Else
				selectedItems = GetSelectedItems(lvLocal)
			End If
			If MessageBox.Show(Me, String.Format("Do you really want to delete {0}",IIf(selectedItems.Count = 1, Path.GetFileName(selectedItems(0).FullPath), (selectedItems.Count & " items"))), "Delete", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
				Try
					' Delete selected items
					For Each item As ListItemInfo In selectedItems
						If _serverListSelected Then
							_ftp.Delete(item.FullPath, SearchMode.Recursive)
						Else
							If item.IsFile Then
								File.Delete(item.FullPath)
							Else
								Directory.Delete(item.FullPath, True)
							End If
						End If
					Next item

					' Refresh the server or local list
					If _serverListSelected Then
						UpdateServerList(tbxServerFolder.Text)
					Else
						UpdateLocalList(tbxLocalFolder.Text)
					End If
				Catch ex As Exception
					Log(ex)
				End Try
			End If
		End Sub

		Private Sub btRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btRefresh.Click
			UpdateLocalList(tbxLocalFolder.Text)
			If tbxServerFolder.Enabled Then
				UpdateServerList(tbxServerFolder.Text)
			End If
		End Sub

		Private Sub cbTransferMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbTransferMode.SelectedIndexChanged
			If _ftp Is Nothing Then
				Return
			End If

			Select Case cbTransferMode.SelectedIndex
				Case 0 ' Binary
					_ftp.TransferType = SftpTransferType.Binary

				Case 1 ' Text
					_ftp.TransferType = SftpTransferType.Ascii
			End Select
		End Sub

		Private Sub cbModeZ_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbModeZ.CheckedChanged
			If _ftp Is Nothing Then
				Return
			End If

			_ftp.Settings.SshParameters.Compression = cbModeZ.Checked
		End Sub

		Private Sub numSpeedLimit_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numSpeedLimit.ValueChanged
			_ftp.MaxUploadSpeed = CInt(Fix(numSpeedLimit.Value))
			_ftp.MaxDownloadSpeed = _ftp.MaxUploadSpeed
		End Sub
	End Class

	Friend Class ListItemInfo
		Public FullPath As String
		Public IsUpper As Boolean
		Public IsDirectory As Boolean
		Public IsFile As Boolean
		Public IsLink As Boolean
		Public Size As Long
		Public Time As Date

		Public Sub New(ByVal fullPath As String, ByVal isUpper As Boolean, ByVal isDirectory As Boolean, ByVal isFile As Boolean, ByVal isLink As Boolean)
			Me.FullPath = fullPath
			Me.IsUpper = isUpper
			Me.IsDirectory = isDirectory
			Me.IsFile = isFile
			Me.IsLink = isLink
		End Sub
	End Class
End Namespace
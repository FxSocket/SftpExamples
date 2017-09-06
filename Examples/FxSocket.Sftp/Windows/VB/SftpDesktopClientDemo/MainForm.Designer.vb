Namespace FxSocketSamples
	Partial Public Class MainForm
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.pnCommands = New System.Windows.Forms.Panel()
			Me.progressBar = New System.Windows.Forms.ProgressBar()
			Me.lbProgress = New System.Windows.Forms.Label()
			Me.btRefresh = New System.Windows.Forms.Button()
			Me.btDelete = New System.Windows.Forms.Button()
			Me.btNewFolder = New System.Windows.Forms.Button()
			Me.btMove = New System.Windows.Forms.Button()
			Me.btCopy = New System.Windows.Forms.Button()
			Me.grSep = New System.Windows.Forms.GroupBox()
			Me.btEdit = New System.Windows.Forms.Button()
			Me.btView = New System.Windows.Forms.Button()
			Me.menuStrip = New System.Windows.Forms.MenuStrip()
			Me.miFiles = New System.Windows.Forms.ToolStripMenuItem()
			Me.miCreateFolder = New System.Windows.Forms.ToolStripMenuItem()
			Me.miCopy = New System.Windows.Forms.ToolStripMenuItem()
			Me.miDelete = New System.Windows.Forms.ToolStripMenuItem()
			Me.miMove = New System.Windows.Forms.ToolStripMenuItem()
			Me.miRefresh = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
			Me.miView = New System.Windows.Forms.ToolStripMenuItem()
			Me.miEdit = New System.Windows.Forms.ToolStripMenuItem()
			Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
			Me.miQuit = New System.Windows.Forms.ToolStripMenuItem()
			Me.miConnect = New System.Windows.Forms.ToolStripMenuItem()
			Me.spcViews = New System.Windows.Forms.SplitContainer()
			Me.lblServerType = New System.Windows.Forms.Label()
			Me.tbxServerFolder = New System.Windows.Forms.TextBox()
			Me.lbServerStats = New System.Windows.Forms.Label()
			Me.lvServer = New System.Windows.Forms.ListView()
			Me.chServerName = New System.Windows.Forms.ColumnHeader()
			Me.chServerExt = New System.Windows.Forms.ColumnHeader()
			Me.chServerSize = New System.Windows.Forms.ColumnHeader()
			Me.chServerDate = New System.Windows.Forms.ColumnHeader()
			Me.chServerPermissions = New System.Windows.Forms.ColumnHeader()
			Me.fileListImageList = New System.Windows.Forms.ImageList(Me.components)
			Me.cbDrives = New System.Windows.Forms.ComboBox()
			Me.lbLocalStats = New System.Windows.Forms.Label()
			Me.lvLocal = New System.Windows.Forms.ListView()
			Me.chLocalName = New System.Windows.Forms.ColumnHeader()
			Me.chLocalExt = New System.Windows.Forms.ColumnHeader()
			Me.chLocalSize = New System.Windows.Forms.ColumnHeader()
			Me.chLocalTime = New System.Windows.Forms.ColumnHeader()
			Me.tbxLocalFolder = New System.Windows.Forms.TextBox()
			Me.pnLog = New System.Windows.Forms.Panel()
			Me.cbModeZ = New System.Windows.Forms.CheckBox()
			Me.label4 = New System.Windows.Forms.Label()
			Me.numSpeedLimit = New System.Windows.Forms.NumericUpDown()
			Me.lbSpeedLimit = New System.Windows.Forms.Label()
			Me.tbxLog = New System.Windows.Forms.RichTextBox()
			Me.btConnect = New System.Windows.Forms.Button()
			Me.cbTransferMode = New System.Windows.Forms.ComboBox()
			Me.lbTransferMode = New System.Windows.Forms.Label()
			Me.lbServerType = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.pnCommands.SuspendLayout()
			Me.menuStrip.SuspendLayout()
			Me.spcViews.Panel1.SuspendLayout()
			Me.spcViews.Panel2.SuspendLayout()
			Me.spcViews.SuspendLayout()
			Me.pnLog.SuspendLayout()
			CType(Me.numSpeedLimit, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pnCommands
			' 
			Me.pnCommands.Controls.Add(Me.progressBar)
			Me.pnCommands.Controls.Add(Me.lbProgress)
			Me.pnCommands.Controls.Add(Me.btRefresh)
			Me.pnCommands.Controls.Add(Me.btDelete)
			Me.pnCommands.Controls.Add(Me.btNewFolder)
			Me.pnCommands.Controls.Add(Me.btMove)
			Me.pnCommands.Controls.Add(Me.btCopy)
			Me.pnCommands.Controls.Add(Me.grSep)
			Me.pnCommands.Controls.Add(Me.btEdit)
			Me.pnCommands.Controls.Add(Me.btView)
			Me.pnCommands.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.pnCommands.Location = New System.Drawing.Point(0, 450)
			Me.pnCommands.Name = "pnCommands"
			Me.pnCommands.Size = New System.Drawing.Size(823, 39)
			Me.pnCommands.TabIndex = 0
			' 
			' progressBar
			' 
			Me.progressBar.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.progressBar.Location = New System.Drawing.Point(562, 8)
			Me.progressBar.Name = "progressBar"
			Me.progressBar.Size = New System.Drawing.Size(254, 23)
			Me.progressBar.TabIndex = 17
			Me.progressBar.Visible = False
			' 
			' lbProgress
			' 
			Me.lbProgress.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.lbProgress.AutoSize = True
			Me.lbProgress.Location = New System.Drawing.Point(6, 13)
			Me.lbProgress.Name = "lbProgress"
			Me.lbProgress.Size = New System.Drawing.Size(48, 13)
			Me.lbProgress.TabIndex = 16
			Me.lbProgress.Text = "Progress"
			Me.lbProgress.Visible = False
			' 
			' btRefresh
			' 
			Me.btRefresh.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btRefresh.Location = New System.Drawing.Point(717, 8)
			Me.btRefresh.Name = "btRefresh"
			Me.btRefresh.Size = New System.Drawing.Size(99, 23)
			Me.btRefresh.TabIndex = 7
			Me.btRefresh.Text = "F12 - Refresh"
			Me.btRefresh.UseVisualStyleBackColor = True
'			Me.btRefresh.Click += New System.EventHandler(Me.btRefresh_Click)
			' 
			' btDelete
			' 
			Me.btDelete.Enabled = False
			Me.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btDelete.Location = New System.Drawing.Point(432, 8)
			Me.btDelete.Name = "btDelete"
			Me.btDelete.Size = New System.Drawing.Size(99, 23)
			Me.btDelete.TabIndex = 6
			Me.btDelete.Text = "F8 - Delete"
			Me.btDelete.UseVisualStyleBackColor = True
'			Me.btDelete.Click += New System.EventHandler(Me.btDelete_Click)
			' 
			' btNewFolder
			' 
			Me.btNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btNewFolder.Location = New System.Drawing.Point(327, 8)
			Me.btNewFolder.Name = "btNewFolder"
			Me.btNewFolder.Size = New System.Drawing.Size(99, 23)
			Me.btNewFolder.TabIndex = 5
			Me.btNewFolder.Text = "F7 - New Folder"
			Me.btNewFolder.UseVisualStyleBackColor = True
'			Me.btNewFolder.Click += New System.EventHandler(Me.btNewFolder_Click)
			' 
			' btMove
			' 
			Me.btMove.Enabled = False
			Me.btMove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btMove.Location = New System.Drawing.Point(222, 8)
			Me.btMove.Name = "btMove"
			Me.btMove.Size = New System.Drawing.Size(99, 23)
			Me.btMove.TabIndex = 4
			Me.btMove.Text = "F6 - Move"
			Me.btMove.UseVisualStyleBackColor = True
'			Me.btMove.Click += New System.EventHandler(Me.btMove_Click)
			' 
			' btCopy
			' 
			Me.btCopy.Enabled = False
			Me.btCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btCopy.Location = New System.Drawing.Point(117, 8)
			Me.btCopy.Name = "btCopy"
			Me.btCopy.Size = New System.Drawing.Size(99, 23)
			Me.btCopy.TabIndex = 3
			Me.btCopy.Text = "F5 - Upload"
			Me.btCopy.UseVisualStyleBackColor = True
'			Me.btCopy.Click += New System.EventHandler(Me.btCopy_Click)
			' 
			' grSep
			' 
			Me.grSep.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.grSep.Location = New System.Drawing.Point(0, 0)
			Me.grSep.Name = "grSep"
			Me.grSep.Size = New System.Drawing.Size(826, 2)
			Me.grSep.TabIndex = 2
			Me.grSep.TabStop = False
			' 
			' btEdit
			' 
			Me.btEdit.Enabled = False
			Me.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btEdit.Location = New System.Drawing.Point(117, 8)
			Me.btEdit.Name = "btEdit"
			Me.btEdit.Size = New System.Drawing.Size(99, 23)
			Me.btEdit.TabIndex = 1
			Me.btEdit.Text = "F4 - Edit"
			Me.btEdit.UseVisualStyleBackColor = True
			Me.btEdit.Visible = False
'			Me.btEdit.Click += New System.EventHandler(Me.btEdit_Click)
			' 
			' btView
			' 
			Me.btView.Enabled = False
			Me.btView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.btView.Location = New System.Drawing.Point(8, 8)
			Me.btView.Name = "btView"
			Me.btView.Size = New System.Drawing.Size(99, 23)
			Me.btView.TabIndex = 0
			Me.btView.Text = "F3 - View"
			Me.btView.UseVisualStyleBackColor = True
'			Me.btView.Click += New System.EventHandler(Me.btView_Click)
			' 
			' menuStrip
			' 
			Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() { Me.miFiles, Me.miConnect})
			Me.menuStrip.Location = New System.Drawing.Point(0, 0)
			Me.menuStrip.Name = "menuStrip"
			Me.menuStrip.Size = New System.Drawing.Size(823, 24)
			Me.menuStrip.TabIndex = 1
			' 
			' miFiles
			' 
			Me.miFiles.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() { Me.miCreateFolder, Me.miCopy, Me.miDelete, Me.miMove, Me.miRefresh, Me.toolStripSeparator2, Me.miView, Me.miEdit, Me.toolStripSeparator1, Me.miQuit})
			Me.miFiles.Name = "miFiles"
			Me.miFiles.Size = New System.Drawing.Size(42, 20)
			Me.miFiles.Text = "Files"
			' 
			' miCreateFolder
			' 
			Me.miCreateFolder.Name = "miCreateFolder"
			Me.miCreateFolder.ShortcutKeys = System.Windows.Forms.Keys.F7
			Me.miCreateFolder.Size = New System.Drawing.Size(162, 22)
			Me.miCreateFolder.Text = "New Folder..."
'			Me.miCreateFolder.Click += New System.EventHandler(Me.miCreateFolder_Click)
			' 
			' miCopy
			' 
			Me.miCopy.Name = "miCopy"
			Me.miCopy.Size = New System.Drawing.Size(162, 22)
			Me.miCopy.Text = "Download"
'			Me.miCopy.Click += New System.EventHandler(Me.miDownload_Click)
			' 
			' miDelete
			' 
			Me.miDelete.Name = "miDelete"
			Me.miDelete.ShortcutKeys = System.Windows.Forms.Keys.F8
			Me.miDelete.Size = New System.Drawing.Size(162, 22)
			Me.miDelete.Text = "Delete..."
'			Me.miDelete.Click += New System.EventHandler(Me.miDelete_Click)
			' 
			' miMove
			' 
			Me.miMove.Name = "miMove"
			Me.miMove.ShortcutKeys = System.Windows.Forms.Keys.F6
			Me.miMove.Size = New System.Drawing.Size(162, 22)
			Me.miMove.Text = "Move..."
'			Me.miMove.Click += New System.EventHandler(Me.moveToolStripMenuItem_Click)
			' 
			' miRefresh
			' 
			Me.miRefresh.Name = "miRefresh"
			Me.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F12
			Me.miRefresh.Size = New System.Drawing.Size(162, 22)
			Me.miRefresh.Text = "Refresh"
'			Me.miRefresh.Click += New System.EventHandler(Me.miRefresh_Click)
			' 
			' toolStripSeparator2
			' 
			Me.toolStripSeparator2.Name = "toolStripSeparator2"
			Me.toolStripSeparator2.Size = New System.Drawing.Size(159, 6)
			' 
			' miView
			' 
			Me.miView.Name = "miView"
			Me.miView.ShortcutKeys = System.Windows.Forms.Keys.F3
			Me.miView.Size = New System.Drawing.Size(162, 22)
			Me.miView.Text = "View..."
'			Me.miView.Click += New System.EventHandler(Me.viewToolStripMenuItem_Click)
			' 
			' miEdit
			' 
			Me.miEdit.Name = "miEdit"
			Me.miEdit.ShortcutKeys = System.Windows.Forms.Keys.F4
			Me.miEdit.Size = New System.Drawing.Size(162, 22)
			Me.miEdit.Text = "Edit..."
'			Me.miEdit.Click += New System.EventHandler(Me.editToolStripMenuItem_Click)
			' 
			' toolStripSeparator1
			' 
			Me.toolStripSeparator1.Name = "toolStripSeparator1"
			Me.toolStripSeparator1.Size = New System.Drawing.Size(159, 6)
			' 
			' miQuit
			' 
			Me.miQuit.Name = "miQuit"
			Me.miQuit.ShortcutKeys = (CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys))
			Me.miQuit.Size = New System.Drawing.Size(162, 22)
			Me.miQuit.Text = "Quit"
'			Me.miQuit.Click += New System.EventHandler(Me.miQuit_Click)
			' 
			' miConnect
			' 
			Me.miConnect.Name = "miConnect"
			Me.miConnect.Size = New System.Drawing.Size(73, 20)
			Me.miConnect.Text = "Connect..."
'			Me.miConnect.Click += New System.EventHandler(Me.miConnect_Click)
			' 
			' spcViews
			' 
			Me.spcViews.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.spcViews.Location = New System.Drawing.Point(0, 100)
			Me.spcViews.Name = "spcViews"
			' 
			' spcViews.Panel1
			' 
			Me.spcViews.Panel1.Controls.Add(Me.lblServerType)
			Me.spcViews.Panel1.Controls.Add(Me.tbxServerFolder)
			Me.spcViews.Panel1.Controls.Add(Me.lbServerStats)
			Me.spcViews.Panel1.Controls.Add(Me.lvServer)
			' 
			' spcViews.Panel2
			' 
			Me.spcViews.Panel2.Controls.Add(Me.cbDrives)
			Me.spcViews.Panel2.Controls.Add(Me.lbLocalStats)
			Me.spcViews.Panel2.Controls.Add(Me.lvLocal)
			Me.spcViews.Panel2.Controls.Add(Me.tbxLocalFolder)
			Me.spcViews.Size = New System.Drawing.Size(823, 351)
			Me.spcViews.SplitterDistance = 419
			Me.spcViews.TabIndex = 2
			' 
			' lblServerType
			' 
			Me.lblServerType.AutoSize = True
			Me.lblServerType.Location = New System.Drawing.Point(5, 6)
			Me.lblServerType.Name = "lblServerType"
			Me.lblServerType.Size = New System.Drawing.Size(70, 13)
			Me.lblServerType.TabIndex = 15
			Me.lblServerType.Text = "Server Folder"
			' 
			' tbxServerFolder
			' 
			Me.tbxServerFolder.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbxServerFolder.Location = New System.Drawing.Point(85, 3)
			Me.tbxServerFolder.Name = "tbxServerFolder"
			Me.tbxServerFolder.Size = New System.Drawing.Size(333, 20)
			Me.tbxServerFolder.TabIndex = 14
			' 
			' lbServerStats
			' 
			Me.lbServerStats.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.lbServerStats.AutoSize = True
			Me.lbServerStats.Location = New System.Drawing.Point(3, 331)
			Me.lbServerStats.Name = "lbServerStats"
			Me.lbServerStats.Size = New System.Drawing.Size(79, 13)
			Me.lbServerStats.TabIndex = 13
			Me.lbServerStats.Text = "Not Connected"
			' 
			' lvServer
			' 
			Me.lvServer.AllowDrop = True
			Me.lvServer.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lvServer.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.chServerName, Me.chServerExt, Me.chServerSize, Me.chServerDate, Me.chServerPermissions})
			Me.lvServer.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lvServer.FullRowSelect = True
			Me.lvServer.LabelEdit = True
			Me.lvServer.Location = New System.Drawing.Point(4, 28)
			Me.lvServer.Name = "lvServer"
			Me.lvServer.Size = New System.Drawing.Size(414, 298)
			Me.lvServer.SmallImageList = Me.fileListImageList
			Me.lvServer.TabIndex = 12
			Me.lvServer.UseCompatibleStateImageBehavior = False
			Me.lvServer.View = System.Windows.Forms.View.Details
'			Me.lvServer.SelectedIndexChanged += New System.EventHandler(Me.lvServer_SelectedIndexChanged)
'			Me.lvServer.DoubleClick += New System.EventHandler(Me.lvServer_DoubleClick)
'			Me.lvServer.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.lvServer_KeyDown)
			' 
			' chServerName
			' 
			Me.chServerName.Text = "Name"
			Me.chServerName.Width = 200
			' 
			' chServerExt
			' 
			Me.chServerExt.Text = "Ext"
			' 
			' chServerSize
			' 
			Me.chServerSize.Text = "Size"
			Me.chServerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			Me.chServerSize.Width = 100
			' 
			' chServerDate
			' 
			Me.chServerDate.Text = "Date"
			Me.chServerDate.Width = 150
			' 
			' chServerPermissions
			' 
			Me.chServerPermissions.Text = "Permissions"
			Me.chServerPermissions.Width = 100
			' 
			' fileListImageList
			' 
			Me.fileListImageList.ImageStream = (CType(resources.GetObject("fileListImageList.ImageStream"), System.Windows.Forms.ImageListStreamer))
			Me.fileListImageList.TransparentColor = System.Drawing.Color.Transparent
			Me.fileListImageList.Images.SetKeyName(0, "file-icon.png")
			Me.fileListImageList.Images.SetKeyName(1, "folder-icon.png")
			' 
			' cbDrives
			' 
			Me.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbDrives.FormattingEnabled = True
			Me.cbDrives.Location = New System.Drawing.Point(1, 3)
			Me.cbDrives.Name = "cbDrives"
			Me.cbDrives.Size = New System.Drawing.Size(78, 21)
			Me.cbDrives.TabIndex = 28
'			Me.cbDrives.SelectedIndexChanged += New System.EventHandler(Me.cbDrives_SelectedIndexChanged)
			' 
			' lbLocalStats
			' 
			Me.lbLocalStats.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.lbLocalStats.AutoSize = True
			Me.lbLocalStats.Location = New System.Drawing.Point(5, 331)
			Me.lbLocalStats.Name = "lbLocalStats"
			Me.lbLocalStats.Size = New System.Drawing.Size(45, 13)
			Me.lbLocalStats.TabIndex = 16
			Me.lbLocalStats.Text = "No Files"
			' 
			' lvLocal
			' 
			Me.lvLocal.AllowDrop = True
			Me.lvLocal.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.lvLocal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() { Me.chLocalName, Me.chLocalExt, Me.chLocalSize, Me.chLocalTime})
			Me.lvLocal.Font = New System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lvLocal.FullRowSelect = True
			Me.lvLocal.LabelEdit = True
			Me.lvLocal.Location = New System.Drawing.Point(1, 28)
			Me.lvLocal.Name = "lvLocal"
			Me.lvLocal.Size = New System.Drawing.Size(394, 298)
			Me.lvLocal.SmallImageList = Me.fileListImageList
			Me.lvLocal.TabIndex = 18
			Me.lvLocal.UseCompatibleStateImageBehavior = False
			Me.lvLocal.View = System.Windows.Forms.View.Details
'			Me.lvLocal.SelectedIndexChanged += New System.EventHandler(Me.lvLocal_SelectedIndexChanged)
'			Me.lvLocal.DoubleClick += New System.EventHandler(Me.lvLocal_DoubleClick)
'			Me.lvLocal.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.lvLocal_KeyDown)
			' 
			' chLocalName
			' 
			Me.chLocalName.Text = "Name"
			Me.chLocalName.Width = 200
			' 
			' chLocalExt
			' 
			Me.chLocalExt.Text = "Ext"
			' 
			' chLocalSize
			' 
			Me.chLocalSize.Text = "Size"
			Me.chLocalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
			Me.chLocalSize.Width = 100
			' 
			' chLocalTime
			' 
			Me.chLocalTime.Text = "Date"
			Me.chLocalTime.Width = 150
			' 
			' tbxLocalFolder
			' 
			Me.tbxLocalFolder.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbxLocalFolder.Location = New System.Drawing.Point(85, 3)
			Me.tbxLocalFolder.Name = "tbxLocalFolder"
			Me.tbxLocalFolder.Size = New System.Drawing.Size(310, 20)
			Me.tbxLocalFolder.TabIndex = 16
'			Me.tbxLocalFolder.KeyDown += New System.Windows.Forms.KeyEventHandler(Me.tbxLocalFolder_KeyDown)
			' 
			' pnLog
			' 
			Me.pnLog.Controls.Add(Me.cbModeZ)
			Me.pnLog.Controls.Add(Me.label4)
			Me.pnLog.Controls.Add(Me.numSpeedLimit)
			Me.pnLog.Controls.Add(Me.lbSpeedLimit)
			Me.pnLog.Controls.Add(Me.tbxLog)
			Me.pnLog.Controls.Add(Me.btConnect)
			Me.pnLog.Controls.Add(Me.cbTransferMode)
			Me.pnLog.Controls.Add(Me.lbTransferMode)
			Me.pnLog.Controls.Add(Me.lbServerType)
			Me.pnLog.Controls.Add(Me.groupBox2)
			Me.pnLog.Dock = System.Windows.Forms.DockStyle.Top
			Me.pnLog.Location = New System.Drawing.Point(0, 24)
			Me.pnLog.Name = "pnLog"
			Me.pnLog.Size = New System.Drawing.Size(823, 76)
			Me.pnLog.TabIndex = 3
			' 
			' cbModeZ
			' 
			Me.cbModeZ.AutoSize = True
			Me.cbModeZ.Enabled = False
			Me.cbModeZ.Location = New System.Drawing.Point(100, 54)
			Me.cbModeZ.Name = "cbModeZ"
			Me.cbModeZ.Size = New System.Drawing.Size(86, 17)
			Me.cbModeZ.TabIndex = 27
			Me.cbModeZ.Text = "Compression"
			Me.cbModeZ.UseVisualStyleBackColor = True
'			Me.cbModeZ.CheckedChanged += New System.EventHandler(Me.cbModeZ_CheckedChanged)
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(259, 36)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(102, 13)
			Me.label4.TabIndex = 26
			Me.label4.Text = "(Kbs)  0 for unlimited"
			' 
			' numSpeedLimit
			' 
			Me.numSpeedLimit.Enabled = False
			Me.numSpeedLimit.Location = New System.Drawing.Point(175, 33)
			Me.numSpeedLimit.Name = "numSpeedLimit"
			Me.numSpeedLimit.Size = New System.Drawing.Size(82, 20)
			Me.numSpeedLimit.TabIndex = 25
'			Me.numSpeedLimit.ValueChanged += New System.EventHandler(Me.numSpeedLimit_ValueChanged)
			' 
			' lbSpeedLimit
			' 
			Me.lbSpeedLimit.AutoSize = True
			Me.lbSpeedLimit.Location = New System.Drawing.Point(97, 35)
			Me.lbSpeedLimit.Name = "lbSpeedLimit"
			Me.lbSpeedLimit.Size = New System.Drawing.Size(65, 13)
			Me.lbSpeedLimit.TabIndex = 24
			Me.lbSpeedLimit.Text = "Speed Limit:"
			' 
			' tbxLog
			' 
			Me.tbxLog.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.tbxLog.BackColor = System.Drawing.Color.White
			Me.tbxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.tbxLog.Cursor = System.Windows.Forms.Cursors.IBeam
			Me.tbxLog.Font = New System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.tbxLog.ForeColor = System.Drawing.Color.Silver
			Me.tbxLog.Location = New System.Drawing.Point(409, 7)
			Me.tbxLog.MaxLength = 50000
			Me.tbxLog.Name = "tbxLog"
			Me.tbxLog.ReadOnly = True
			Me.tbxLog.RightToLeft = System.Windows.Forms.RightToLeft.No
			Me.tbxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
			Me.tbxLog.Size = New System.Drawing.Size(409, 66)
			Me.tbxLog.TabIndex = 23
			Me.tbxLog.Text = ""
			' 
			' btConnect
			' 
			Me.btConnect.Location = New System.Drawing.Point(328, 7)
			Me.btConnect.Name = "btConnect"
			Me.btConnect.Size = New System.Drawing.Size(75, 23)
			Me.btConnect.TabIndex = 19
			Me.btConnect.Text = "Disconnect"
			Me.btConnect.UseVisualStyleBackColor = True
'			Me.btConnect.Click += New System.EventHandler(Me.btConnect_Click)
			' 
			' cbTransferMode
			' 
			Me.cbTransferMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cbTransferMode.Enabled = False
			Me.cbTransferMode.FormattingEnabled = True
			Me.cbTransferMode.Items.AddRange(New Object() { "Binary (archives, doc, zip, etc.)", "Text (plain text, htm, etc.)"})
			Me.cbTransferMode.Location = New System.Drawing.Point(175, 8)
			Me.cbTransferMode.Name = "cbTransferMode"
			Me.cbTransferMode.Size = New System.Drawing.Size(145, 21)
			Me.cbTransferMode.TabIndex = 18
'			Me.cbTransferMode.SelectedIndexChanged += New System.EventHandler(Me.cbTransferMode_SelectedIndexChanged)
			' 
			' lbTransferMode
			' 
			Me.lbTransferMode.AutoSize = True
			Me.lbTransferMode.Location = New System.Drawing.Point(95, 11)
			Me.lbTransferMode.Name = "lbTransferMode"
			Me.lbTransferMode.Size = New System.Drawing.Size(75, 13)
			Me.lbTransferMode.TabIndex = 17
			Me.lbTransferMode.Text = "Transfer mode"
			' 
			' lbServerType
			' 
			Me.lbServerType.AutoSize = True
			Me.lbServerType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.lbServerType.Location = New System.Drawing.Point(11, 11)
			Me.lbServerType.Name = "lbServerType"
			Me.lbServerType.Size = New System.Drawing.Size(38, 13)
			Me.lbServerType.TabIndex = 16
			Me.lbServerType.Text = "SFTP"
			' 
			' groupBox2
			' 
			Me.groupBox2.Location = New System.Drawing.Point(0, 0)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(895, 2)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(823, 489)
			Me.Controls.Add(Me.pnCommands)
			Me.Controls.Add(Me.pnLog)
			Me.Controls.Add(Me.menuStrip)
			Me.Controls.Add(Me.spcViews)
			Me.MainMenuStrip = Me.menuStrip
			Me.Name = "MainForm"
			Me.Text = "FxSocket File Transfer WinForms Client"
			Me.pnCommands.ResumeLayout(False)
			Me.pnCommands.PerformLayout()
			Me.menuStrip.ResumeLayout(False)
			Me.menuStrip.PerformLayout()
			Me.spcViews.Panel1.ResumeLayout(False)
			Me.spcViews.Panel1.PerformLayout()
			Me.spcViews.Panel2.ResumeLayout(False)
			Me.spcViews.Panel2.PerformLayout()
			Me.spcViews.ResumeLayout(False)
			Me.pnLog.ResumeLayout(False)
			Me.pnLog.PerformLayout()
			CType(Me.numSpeedLimit, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private pnCommands As System.Windows.Forms.Panel
		Private WithEvents btEdit As System.Windows.Forms.Button
		Private WithEvents btView As System.Windows.Forms.Button
		Private menuStrip As System.Windows.Forms.MenuStrip
		Private WithEvents miConnect As System.Windows.Forms.ToolStripMenuItem
		Private miFiles As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents miQuit As System.Windows.Forms.ToolStripMenuItem
		Private spcViews As System.Windows.Forms.SplitContainer
		Public WithEvents lvServer As System.Windows.Forms.ListView
		Private chServerName As System.Windows.Forms.ColumnHeader
		Private chServerSize As System.Windows.Forms.ColumnHeader
		Private chServerDate As System.Windows.Forms.ColumnHeader
		Private chServerPermissions As System.Windows.Forms.ColumnHeader
		Private chServerExt As System.Windows.Forms.ColumnHeader
		Private tbxServerFolder As System.Windows.Forms.TextBox
		Private lbServerStats As System.Windows.Forms.Label
		Private lblServerType As System.Windows.Forms.Label
		Public WithEvents lvLocal As System.Windows.Forms.ListView
		Private chLocalName As System.Windows.Forms.ColumnHeader
		Private chLocalExt As System.Windows.Forms.ColumnHeader
		Private chLocalSize As System.Windows.Forms.ColumnHeader
		Private chLocalTime As System.Windows.Forms.ColumnHeader
		Private WithEvents tbxLocalFolder As System.Windows.Forms.TextBox
		Private grSep As System.Windows.Forms.GroupBox
		Private pnLog As System.Windows.Forms.Panel
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private WithEvents btConnect As System.Windows.Forms.Button
		Private WithEvents cbTransferMode As System.Windows.Forms.ComboBox
		Private lbTransferMode As System.Windows.Forms.Label
		Private lbServerType As System.Windows.Forms.Label
		Public tbxLog As System.Windows.Forms.RichTextBox
		Private lbLocalStats As System.Windows.Forms.Label
		Private WithEvents miCopy As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents miDelete As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents miCreateFolder As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents miRefresh As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents cbModeZ As System.Windows.Forms.CheckBox
		Private label4 As System.Windows.Forms.Label
		Private WithEvents numSpeedLimit As System.Windows.Forms.NumericUpDown
		Private lbSpeedLimit As System.Windows.Forms.Label
		Private WithEvents btCopy As System.Windows.Forms.Button
		Private WithEvents btDelete As System.Windows.Forms.Button
		Private WithEvents btNewFolder As System.Windows.Forms.Button
		Private WithEvents btMove As System.Windows.Forms.Button
		Private WithEvents btRefresh As System.Windows.Forms.Button
		Private WithEvents miMove As System.Windows.Forms.ToolStripMenuItem
		Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
		Private WithEvents miView As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents miEdit As System.Windows.Forms.ToolStripMenuItem
		Private WithEvents cbDrives As System.Windows.Forms.ComboBox
		Private fileListImageList As System.Windows.Forms.ImageList
		Private progressBar As System.Windows.Forms.ProgressBar
		Private lbProgress As System.Windows.Forms.Label

	End Class
End Namespace
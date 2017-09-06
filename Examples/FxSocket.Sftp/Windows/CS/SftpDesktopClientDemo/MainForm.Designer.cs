namespace FxSocketSamples
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnCommands = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btNewFolder = new System.Windows.Forms.Button();
            this.btMove = new System.Windows.Forms.Button();
            this.btCopy = new System.Windows.Forms.Button();
            this.grSep = new System.Windows.Forms.GroupBox();
            this.btEdit = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.miFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.miCreateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.miMove = new System.Windows.Forms.ToolStripMenuItem();
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.miConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.spcViews = new System.Windows.Forms.SplitContainer();
            this.lblServerType = new System.Windows.Forms.Label();
            this.tbxServerFolder = new System.Windows.Forms.TextBox();
            this.lbServerStats = new System.Windows.Forms.Label();
            this.lvServer = new System.Windows.Forms.ListView();
            this.chServerName = new System.Windows.Forms.ColumnHeader();
            this.chServerExt = new System.Windows.Forms.ColumnHeader();
            this.chServerSize = new System.Windows.Forms.ColumnHeader();
            this.chServerDate = new System.Windows.Forms.ColumnHeader();
            this.chServerPermissions = new System.Windows.Forms.ColumnHeader();
            this.fileListImageList = new System.Windows.Forms.ImageList(this.components);
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.lbLocalStats = new System.Windows.Forms.Label();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.chLocalName = new System.Windows.Forms.ColumnHeader();
            this.chLocalExt = new System.Windows.Forms.ColumnHeader();
            this.chLocalSize = new System.Windows.Forms.ColumnHeader();
            this.chLocalTime = new System.Windows.Forms.ColumnHeader();
            this.tbxLocalFolder = new System.Windows.Forms.TextBox();
            this.pnLog = new System.Windows.Forms.Panel();
            this.cbModeZ = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numSpeedLimit = new System.Windows.Forms.NumericUpDown();
            this.lbSpeedLimit = new System.Windows.Forms.Label();
            this.tbxLog = new System.Windows.Forms.RichTextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.cbTransferMode = new System.Windows.Forms.ComboBox();
            this.lbTransferMode = new System.Windows.Forms.Label();
            this.lbServerType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnCommands.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.spcViews.Panel1.SuspendLayout();
            this.spcViews.Panel2.SuspendLayout();
            this.spcViews.SuspendLayout();
            this.pnLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnCommands
            // 
            this.pnCommands.Controls.Add(this.progressBar);
            this.pnCommands.Controls.Add(this.lbProgress);
            this.pnCommands.Controls.Add(this.btRefresh);
            this.pnCommands.Controls.Add(this.btDelete);
            this.pnCommands.Controls.Add(this.btNewFolder);
            this.pnCommands.Controls.Add(this.btMove);
            this.pnCommands.Controls.Add(this.btCopy);
            this.pnCommands.Controls.Add(this.grSep);
            this.pnCommands.Controls.Add(this.btEdit);
            this.pnCommands.Controls.Add(this.btView);
            this.pnCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCommands.Location = new System.Drawing.Point(0, 450);
            this.pnCommands.Name = "pnCommands";
            this.pnCommands.Size = new System.Drawing.Size(823, 39);
            this.pnCommands.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(562, 8);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(254, 23);
            this.progressBar.TabIndex = 17;
            this.progressBar.Visible = false;
            // 
            // lbProgress
            // 
            this.lbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbProgress.AutoSize = true;
            this.lbProgress.Location = new System.Drawing.Point(6, 13);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(48, 13);
            this.lbProgress.TabIndex = 16;
            this.lbProgress.Text = "Progress";
            this.lbProgress.Visible = false;
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRefresh.Location = new System.Drawing.Point(717, 8);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(99, 23);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.Text = "F12 - Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btDelete
            // 
            this.btDelete.Enabled = false;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelete.Location = new System.Drawing.Point(432, 8);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(99, 23);
            this.btDelete.TabIndex = 6;
            this.btDelete.Text = "F8 - Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btNewFolder
            // 
            this.btNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btNewFolder.Location = new System.Drawing.Point(327, 8);
            this.btNewFolder.Name = "btNewFolder";
            this.btNewFolder.Size = new System.Drawing.Size(99, 23);
            this.btNewFolder.TabIndex = 5;
            this.btNewFolder.Text = "F7 - New Folder";
            this.btNewFolder.UseVisualStyleBackColor = true;
            this.btNewFolder.Click += new System.EventHandler(this.btNewFolder_Click);
            // 
            // btMove
            // 
            this.btMove.Enabled = false;
            this.btMove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btMove.Location = new System.Drawing.Point(222, 8);
            this.btMove.Name = "btMove";
            this.btMove.Size = new System.Drawing.Size(99, 23);
            this.btMove.TabIndex = 4;
            this.btMove.Text = "F6 - Move";
            this.btMove.UseVisualStyleBackColor = true;
            this.btMove.Click += new System.EventHandler(this.btMove_Click);
            // 
            // btCopy
            // 
            this.btCopy.Enabled = false;
            this.btCopy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCopy.Location = new System.Drawing.Point(117, 8);
            this.btCopy.Name = "btCopy";
            this.btCopy.Size = new System.Drawing.Size(99, 23);
            this.btCopy.TabIndex = 3;
            this.btCopy.Text = "F5 - Upload";
            this.btCopy.UseVisualStyleBackColor = true;
            this.btCopy.Click += new System.EventHandler(this.btCopy_Click);
            // 
            // grSep
            // 
            this.grSep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grSep.Location = new System.Drawing.Point(0, 0);
            this.grSep.Name = "grSep";
            this.grSep.Size = new System.Drawing.Size(826, 2);
            this.grSep.TabIndex = 2;
            this.grSep.TabStop = false;
            // 
            // btEdit
            // 
            this.btEdit.Enabled = false;
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btEdit.Location = new System.Drawing.Point(117, 8);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(99, 23);
            this.btEdit.TabIndex = 1;
            this.btEdit.Text = "F4 - Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Visible = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btView
            // 
            this.btView.Enabled = false;
            this.btView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btView.Location = new System.Drawing.Point(8, 8);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(99, 23);
            this.btView.TabIndex = 0;
            this.btView.Text = "F3 - View";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFiles,
            this.miConnect});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(823, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // miFiles
            // 
            this.miFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateFolder,
            this.miCopy,
            this.miDelete,
            this.miMove,
            this.miRefresh,
            this.toolStripSeparator2,
            this.miView,
            this.miEdit,
            this.toolStripSeparator1,
            this.miQuit});
            this.miFiles.Name = "miFiles";
            this.miFiles.Size = new System.Drawing.Size(42, 20);
            this.miFiles.Text = "Files";
            // 
            // miCreateFolder
            // 
            this.miCreateFolder.Name = "miCreateFolder";
            this.miCreateFolder.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.miCreateFolder.Size = new System.Drawing.Size(162, 22);
            this.miCreateFolder.Text = "New Folder...";
            this.miCreateFolder.Click += new System.EventHandler(this.miCreateFolder_Click);
            // 
            // miCopy
            // 
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(162, 22);
            this.miCopy.Text = "Download";
            this.miCopy.Click += new System.EventHandler(this.miDownload_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.miDelete.Size = new System.Drawing.Size(162, 22);
            this.miDelete.Text = "Delete...";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // miMove
            // 
            this.miMove.Name = "miMove";
            this.miMove.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.miMove.Size = new System.Drawing.Size(162, 22);
            this.miMove.Text = "Move...";
            this.miMove.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.miRefresh.Size = new System.Drawing.Size(162, 22);
            this.miRefresh.Text = "Refresh";
            this.miRefresh.Click += new System.EventHandler(this.miRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // miView
            // 
            this.miView.Name = "miView";
            this.miView.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.miView.Size = new System.Drawing.Size(162, 22);
            this.miView.Text = "View...";
            this.miView.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // miEdit
            // 
            this.miEdit.Name = "miEdit";
            this.miEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.miEdit.Size = new System.Drawing.Size(162, 22);
            this.miEdit.Text = "Edit...";
            this.miEdit.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // miQuit
            // 
            this.miQuit.Name = "miQuit";
            this.miQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.miQuit.Size = new System.Drawing.Size(162, 22);
            this.miQuit.Text = "Quit";
            this.miQuit.Click += new System.EventHandler(this.miQuit_Click);
            // 
            // miConnect
            // 
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(73, 20);
            this.miConnect.Text = "Connect...";
            this.miConnect.Click += new System.EventHandler(this.miConnect_Click);
            // 
            // spcViews
            // 
            this.spcViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcViews.Location = new System.Drawing.Point(0, 100);
            this.spcViews.Name = "spcViews";
            // 
            // spcViews.Panel1
            // 
            this.spcViews.Panel1.Controls.Add(this.lblServerType);
            this.spcViews.Panel1.Controls.Add(this.tbxServerFolder);
            this.spcViews.Panel1.Controls.Add(this.lbServerStats);
            this.spcViews.Panel1.Controls.Add(this.lvServer);
            // 
            // spcViews.Panel2
            // 
            this.spcViews.Panel2.Controls.Add(this.cbDrives);
            this.spcViews.Panel2.Controls.Add(this.lbLocalStats);
            this.spcViews.Panel2.Controls.Add(this.lvLocal);
            this.spcViews.Panel2.Controls.Add(this.tbxLocalFolder);
            this.spcViews.Size = new System.Drawing.Size(823, 351);
            this.spcViews.SplitterDistance = 419;
            this.spcViews.TabIndex = 2;
            // 
            // lblServerType
            // 
            this.lblServerType.AutoSize = true;
            this.lblServerType.Location = new System.Drawing.Point(5, 6);
            this.lblServerType.Name = "lblServerType";
            this.lblServerType.Size = new System.Drawing.Size(70, 13);
            this.lblServerType.TabIndex = 15;
            this.lblServerType.Text = "Server Folder";
            // 
            // tbxServerFolder
            // 
            this.tbxServerFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxServerFolder.Location = new System.Drawing.Point(85, 3);
            this.tbxServerFolder.Name = "tbxServerFolder";
            this.tbxServerFolder.Size = new System.Drawing.Size(333, 20);
            this.tbxServerFolder.TabIndex = 14;
            // 
            // lbServerStats
            // 
            this.lbServerStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbServerStats.AutoSize = true;
            this.lbServerStats.Location = new System.Drawing.Point(3, 331);
            this.lbServerStats.Name = "lbServerStats";
            this.lbServerStats.Size = new System.Drawing.Size(79, 13);
            this.lbServerStats.TabIndex = 13;
            this.lbServerStats.Text = "Not Connected";
            // 
            // lvServer
            // 
            this.lvServer.AllowDrop = true;
            this.lvServer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvServer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chServerName,
            this.chServerExt,
            this.chServerSize,
            this.chServerDate,
            this.chServerPermissions});
            this.lvServer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvServer.FullRowSelect = true;
            this.lvServer.LabelEdit = true;
            this.lvServer.Location = new System.Drawing.Point(4, 28);
            this.lvServer.Name = "lvServer";
            this.lvServer.Size = new System.Drawing.Size(414, 298);
            this.lvServer.SmallImageList = this.fileListImageList;
            this.lvServer.TabIndex = 12;
            this.lvServer.UseCompatibleStateImageBehavior = false;
            this.lvServer.View = System.Windows.Forms.View.Details;
            this.lvServer.SelectedIndexChanged += new System.EventHandler(this.lvServer_SelectedIndexChanged);
            this.lvServer.DoubleClick += new System.EventHandler(this.lvServer_DoubleClick);
            this.lvServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvServer_KeyDown);
            // 
            // chServerName
            // 
            this.chServerName.Text = "Name";
            this.chServerName.Width = 200;
            // 
            // chServerExt
            // 
            this.chServerExt.Text = "Ext";
            // 
            // chServerSize
            // 
            this.chServerSize.Text = "Size";
            this.chServerSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chServerSize.Width = 100;
            // 
            // chServerDate
            // 
            this.chServerDate.Text = "Date";
            this.chServerDate.Width = 150;
            // 
            // chServerPermissions
            // 
            this.chServerPermissions.Text = "Permissions";
            this.chServerPermissions.Width = 100;
            // 
            // fileListImageList
            // 
            this.fileListImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileListImageList.ImageStream")));
            this.fileListImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileListImageList.Images.SetKeyName(0, "file-icon.png");
            this.fileListImageList.Images.SetKeyName(1, "folder-icon.png");
            // 
            // cbDrives
            // 
            this.cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(1, 3);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(78, 21);
            this.cbDrives.TabIndex = 28;
            this.cbDrives.SelectedIndexChanged += new System.EventHandler(this.cbDrives_SelectedIndexChanged);
            // 
            // lbLocalStats
            // 
            this.lbLocalStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLocalStats.AutoSize = true;
            this.lbLocalStats.Location = new System.Drawing.Point(5, 331);
            this.lbLocalStats.Name = "lbLocalStats";
            this.lbLocalStats.Size = new System.Drawing.Size(45, 13);
            this.lbLocalStats.TabIndex = 16;
            this.lbLocalStats.Text = "No Files";
            // 
            // lvLocal
            // 
            this.lvLocal.AllowDrop = true;
            this.lvLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLocalName,
            this.chLocalExt,
            this.chLocalSize,
            this.chLocalTime});
            this.lvLocal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.LabelEdit = true;
            this.lvLocal.Location = new System.Drawing.Point(1, 28);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(394, 298);
            this.lvLocal.SmallImageList = this.fileListImageList;
            this.lvLocal.TabIndex = 18;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
            this.lvLocal.SelectedIndexChanged += new System.EventHandler(this.lvLocal_SelectedIndexChanged);
            this.lvLocal.DoubleClick += new System.EventHandler(this.lvLocal_DoubleClick);
            this.lvLocal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvLocal_KeyDown);
            // 
            // chLocalName
            // 
            this.chLocalName.Text = "Name";
            this.chLocalName.Width = 200;
            // 
            // chLocalExt
            // 
            this.chLocalExt.Text = "Ext";
            // 
            // chLocalSize
            // 
            this.chLocalSize.Text = "Size";
            this.chLocalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chLocalSize.Width = 100;
            // 
            // chLocalTime
            // 
            this.chLocalTime.Text = "Date";
            this.chLocalTime.Width = 150;
            // 
            // tbxLocalFolder
            // 
            this.tbxLocalFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLocalFolder.Location = new System.Drawing.Point(85, 3);
            this.tbxLocalFolder.Name = "tbxLocalFolder";
            this.tbxLocalFolder.Size = new System.Drawing.Size(310, 20);
            this.tbxLocalFolder.TabIndex = 16;
            this.tbxLocalFolder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxLocalFolder_KeyDown);
            // 
            // pnLog
            // 
            this.pnLog.Controls.Add(this.cbModeZ);
            this.pnLog.Controls.Add(this.label4);
            this.pnLog.Controls.Add(this.numSpeedLimit);
            this.pnLog.Controls.Add(this.lbSpeedLimit);
            this.pnLog.Controls.Add(this.tbxLog);
            this.pnLog.Controls.Add(this.btConnect);
            this.pnLog.Controls.Add(this.cbTransferMode);
            this.pnLog.Controls.Add(this.lbTransferMode);
            this.pnLog.Controls.Add(this.lbServerType);
            this.pnLog.Controls.Add(this.groupBox2);
            this.pnLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLog.Location = new System.Drawing.Point(0, 24);
            this.pnLog.Name = "pnLog";
            this.pnLog.Size = new System.Drawing.Size(823, 76);
            this.pnLog.TabIndex = 3;
            // 
            // cbModeZ
            // 
            this.cbModeZ.AutoSize = true;
            this.cbModeZ.Enabled = false;
            this.cbModeZ.Location = new System.Drawing.Point(100, 54);
            this.cbModeZ.Name = "cbModeZ";
            this.cbModeZ.Size = new System.Drawing.Size(86, 17);
            this.cbModeZ.TabIndex = 27;
            this.cbModeZ.Text = "Compression";
            this.cbModeZ.UseVisualStyleBackColor = true;
            this.cbModeZ.CheckedChanged += new System.EventHandler(this.cbModeZ_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "(Kbs)  0 for unlimited";
            // 
            // numSpeedLimit
            // 
            this.numSpeedLimit.Enabled = false;
            this.numSpeedLimit.Location = new System.Drawing.Point(175, 33);
            this.numSpeedLimit.Name = "numSpeedLimit";
            this.numSpeedLimit.Size = new System.Drawing.Size(82, 20);
            this.numSpeedLimit.TabIndex = 25;
            this.numSpeedLimit.ValueChanged += new System.EventHandler(this.numSpeedLimit_ValueChanged);
            // 
            // lbSpeedLimit
            // 
            this.lbSpeedLimit.AutoSize = true;
            this.lbSpeedLimit.Location = new System.Drawing.Point(97, 35);
            this.lbSpeedLimit.Name = "lbSpeedLimit";
            this.lbSpeedLimit.Size = new System.Drawing.Size(65, 13);
            this.lbSpeedLimit.TabIndex = 24;
            this.lbSpeedLimit.Text = "Speed Limit:";
            // 
            // tbxLog
            // 
            this.tbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLog.BackColor = System.Drawing.Color.White;
            this.tbxLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLog.ForeColor = System.Drawing.Color.Silver;
            this.tbxLog.Location = new System.Drawing.Point(409, 7);
            this.tbxLog.MaxLength = 50000;
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ReadOnly = true;
            this.tbxLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbxLog.Size = new System.Drawing.Size(409, 66);
            this.tbxLog.TabIndex = 23;
            this.tbxLog.Text = "";
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(328, 7);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(75, 23);
            this.btConnect.TabIndex = 19;
            this.btConnect.Text = "Disconnect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // cbTransferMode
            // 
            this.cbTransferMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransferMode.Enabled = false;
            this.cbTransferMode.FormattingEnabled = true;
            this.cbTransferMode.Items.AddRange(new object[] {
            "Binary (archives, doc, zip, etc.)",
            "Text (plain text, htm, etc.)"});
            this.cbTransferMode.Location = new System.Drawing.Point(175, 8);
            this.cbTransferMode.Name = "cbTransferMode";
            this.cbTransferMode.Size = new System.Drawing.Size(145, 21);
            this.cbTransferMode.TabIndex = 18;
            this.cbTransferMode.SelectedIndexChanged += new System.EventHandler(this.cbTransferMode_SelectedIndexChanged);
            // 
            // lbTransferMode
            // 
            this.lbTransferMode.AutoSize = true;
            this.lbTransferMode.Location = new System.Drawing.Point(95, 11);
            this.lbTransferMode.Name = "lbTransferMode";
            this.lbTransferMode.Size = new System.Drawing.Size(75, 13);
            this.lbTransferMode.TabIndex = 17;
            this.lbTransferMode.Text = "Transfer mode";
            // 
            // lbServerType
            // 
            this.lbServerType.AutoSize = true;
            this.lbServerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbServerType.Location = new System.Drawing.Point(11, 11);
            this.lbServerType.Name = "lbServerType";
            this.lbServerType.Size = new System.Drawing.Size(38, 13);
            this.lbServerType.TabIndex = 16;
            this.lbServerType.Text = "SFTP";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(895, 2);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 489);
            this.Controls.Add(this.pnCommands);
            this.Controls.Add(this.pnLog);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.spcViews);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "FxSocket File Transfer WinForms Client";
            this.pnCommands.ResumeLayout(false);
            this.pnCommands.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.spcViews.Panel1.ResumeLayout(false);
            this.spcViews.Panel1.PerformLayout();
            this.spcViews.Panel2.ResumeLayout(false);
            this.spcViews.Panel2.PerformLayout();
            this.spcViews.ResumeLayout(false);
            this.pnLog.ResumeLayout(false);
            this.pnLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeedLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnCommands;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem miConnect;
        private System.Windows.Forms.ToolStripMenuItem miFiles;
        private System.Windows.Forms.ToolStripMenuItem miQuit;
        private System.Windows.Forms.SplitContainer spcViews;
        public System.Windows.Forms.ListView lvServer;
        private System.Windows.Forms.ColumnHeader chServerName;
        private System.Windows.Forms.ColumnHeader chServerSize;
        private System.Windows.Forms.ColumnHeader chServerDate;
        private System.Windows.Forms.ColumnHeader chServerPermissions;
        private System.Windows.Forms.ColumnHeader chServerExt;
        private System.Windows.Forms.TextBox tbxServerFolder;
        private System.Windows.Forms.Label lbServerStats;
        private System.Windows.Forms.Label lblServerType;
        public System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ColumnHeader chLocalName;
        private System.Windows.Forms.ColumnHeader chLocalExt;
        private System.Windows.Forms.ColumnHeader chLocalSize;
        private System.Windows.Forms.ColumnHeader chLocalTime;
        private System.Windows.Forms.TextBox tbxLocalFolder;
        private System.Windows.Forms.GroupBox grSep;
        private System.Windows.Forms.Panel pnLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.ComboBox cbTransferMode;
        private System.Windows.Forms.Label lbTransferMode;
        private System.Windows.Forms.Label lbServerType;
        public System.Windows.Forms.RichTextBox tbxLog;
        private System.Windows.Forms.Label lbLocalStats;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripMenuItem miCreateFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.CheckBox cbModeZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSpeedLimit;
        private System.Windows.Forms.Label lbSpeedLimit;
        private System.Windows.Forms.Button btCopy;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btNewFolder;
        private System.Windows.Forms.Button btMove;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ToolStripMenuItem miMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.ImageList fileListImageList;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProgress;

    }
}
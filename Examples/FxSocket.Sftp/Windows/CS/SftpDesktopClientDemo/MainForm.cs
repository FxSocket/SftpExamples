using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FxSocket;
using FxSocket.FileSystem;
#if !NETFX20
using FxSocket.Legacy;
#endif
using FxSocket.Net;

namespace FxSocketSamples
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private bool _initialized;
        private bool _busy;
        private Sftp _ftp;
        private DateTime _startTime;
        private string _rootServerDir;
        private bool _serverListSelected;
        private TransferIssueForm _problemForm;   // informs the user about problems while transferring data

        #endregion

        public MainForm()
        {
            FxSocket.Licensing.Key = FxSocket.Examples.TrialKey.Key;
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            _problemForm = new TransferIssueForm();


            #region Local

            string path = Path.GetFullPath(".");
            tbxLocalFolder.Text = path;
            lvLocal.ListViewItemSorter = new ListViewColumnSorter();
            PopulateLocalList(path);
            PopulateLocalDriverList(path.Substring(0, 3));

            #endregion

            #region Server

            lvServer.ListViewItemSorter = new ListViewColumnSorter();
            cbTransferMode.SelectedIndex = 0;
            SetConnectedState(false);

            #endregion

            _initialized = true;
        }

        private void miQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Local List

        private bool IsLocalListSelected { get { return lvLocal.Focused; } }

        void PopulateLocalDriverList(string selectedDrive)
        {
            string[] drives = Directory.GetLogicalDrives();
            
            // populate the drives' list and select one
            for (int c = 0; c < drives.Length; c++)
            {
                string drive = drives[c];

                cbDrives.Items.Add(drive);
                if (string.CompareOrdinal(drive, selectedDrive) == 0)
                {
                    cbDrives.SelectedIndex = c;
                }
            }
        }

        void PopulateLocalList(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            DirectoryInfo[] dirList = directory.GetDirectories();
            FileInfo[] fileList = directory.GetFiles();

            int dirs = 0;
            int files = 0;
            long size = 0;

            // Clear the local list
            lvLocal.Items.Clear();

            // directory up
            if (path.Length > 3)
            {
                ListViewItem item = new ListViewItem("..", 1);
                item.Tag = new ListItemInfo(Path.GetDirectoryName(path), true, true, false, false);
                lvLocal.Items.Add(item);
                dirs++;
            }

            // Populate directories
            for (int c = 0; c < dirList.Length; c++)
            {
                string[] row = new string[4];
                DirectoryInfo dirInfo = dirList[c];

                row[0] = dirInfo.Name; // Name
                row[1] = ""; // Ext
                row[2] = ""; // Size

                // Last Write Time
                try
                {
                    row[3] = Common.FormatTime(dirList[c].LastWriteTime);
                }
                catch
                {
                    row[3] = "";
                }

                ListViewItem item = new ListViewItem(row, 1 + c);
                item.ImageIndex = 1;
                item.Tag = new ListItemInfo(dirInfo.FullName, false, true, false, false);
                lvLocal.Items.Add(item);
                dirs++;
            }

            // Populate files
            for (int c = 0; c < fileList.Length; c++)
            {
                FileInfo fileInfo = fileList[c];

                string[] row = new string[4];
                row[0] = Path.GetFileNameWithoutExtension(fileInfo.Name); // Name
                row[1] = Path.GetExtension(fileInfo.Name); // Ext
                row[2] = Common.BytesToString(fileInfo.Length);
                row[3] = Common.FormatTime(fileInfo.LastWriteTime);

                ListViewItem item = new ListViewItem(row, 1 + dirs + files);
                item.ImageIndex = 0;
                item.Tag = new ListItemInfo(fileInfo.FullName, false, false, true, false);
                lvLocal.Items.Add(item);
                size += fileInfo.Length;
                files++;
            }

            // Update stats
            UpdateListStats(lbLocalStats, dirs, files, size);
        }

        void UpdateListStats(Label llb, int dirs, int files, long totalBytes)
        {
            llb.Text = string.Format("{0} folder(s), {1} file(s) in {2}", dirs, files,
                                              Common.BytesToString(totalBytes));
        }

        void UpdateLocalList(string newPath)
        {
            try
            {
                newPath = Path.GetFullPath(newPath);
                PopulateLocalList(newPath);
                tbxLocalFolder.Text = newPath;
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        void UpdateServerList(string newPath)
        {
            try
            {
                PopulateServerList(newPath);
                tbxServerFolder.Text = newPath;
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        #region Event Handlers

        private void cbDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initialized)
                UpdateLocalList(cbDrives.SelectedItem.ToString());
        }

        private void lvLocal_DoubleClick(object sender, EventArgs e)
        {
            string dirName = ((ListItemInfo)lvLocal.SelectedItems[0].Tag).FullPath;

            UpdateLocalList(dirName);
        }

        private void tbxLocalFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift && e.KeyCode == Keys.Enter)
            {
                UpdateLocalList(tbxLocalFolder.Text);
            }
        }

        List<ListItemInfo> GetSelectedItems(ListView lv)
        {
            List<ListItemInfo> selectedItems = new List<ListItemInfo>();
            foreach (ListViewItem item in lv.SelectedItems)
            {
                // Dont count ".." up dir
                if (string.CompareOrdinal(item.Text, "..") == 0)
                    continue;

                selectedItems.Add((ListItemInfo)item.Tag);
            }

            return selectedItems;
        }

        void ListViewSelectIndexChanged(ListView lv)
        {
            List<ListItemInfo> selectedItems = GetSelectedItems(lv);

            btNewFolder.Enabled =
                miCreateFolder.Enabled = true;    
            
            miCopy.Enabled = miDelete.Enabled = miMove.Enabled =
                btDelete.Enabled = selectedItems.Count > 0;

            btCopy.Enabled = btMove.Enabled = selectedItems.Count > 0 && _ftp != null;

            if (selectedItems.Count == 1)
            {
                ListItemInfo info = selectedItems[0];
                miView.Enabled = miEdit.Enabled = btView.Enabled = btEdit.Enabled = info.IsFile;
            }
            else // No files or directories selected or more than one item selected
            {
                miView.Enabled = miEdit.Enabled = btView.Enabled = btEdit.Enabled = false;
            }
        }

        private void lvLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            _serverListSelected = false;
            ListViewSelectIndexChanged(lvLocal);
        }

        #endregion

        #endregion

        #region Server

        /// <summary>
        /// show transfer status: files, bytes, time, speed
        /// </summary>
        private void ShowTransferStats(long bytesTransferred, int filesTransferred)
        {
            // unknown bytes transferred
            if (bytesTransferred == 0)
                return;

            // files and bytes transferred
            string outstring = string.Format("{0} file{1} ({2} byte{3}) transferred in",
                filesTransferred, (filesTransferred > 1 ? "s" : null),
                bytesTransferred, (bytesTransferred > 1 ? "s" : null));

            // time spent
            TimeSpan ts = DateTime.Now - _startTime;

            // speed
            if (ts.TotalSeconds > 1)
            {
                outstring += (ts.Days > 0 ? " " + ts.Days + " day" + (ts.Days > 1 ? "s" : null) : null);
                outstring += (ts.Hours > 0 ? " " + ts.Hours + " hour" + (ts.Hours > 1 ? "s" : null) : null);
                outstring += (ts.Minutes > 0 ? " " + ts.Minutes + " min" + (ts.Minutes > 1 ? "s" : null) : null);
                outstring += (ts.Seconds > 0 ? " " + ts.Seconds + " sec" + (ts.Seconds > 1 ? "s" : null) : null);
            }
            else
            {
                outstring += " " + ts.TotalSeconds + " sec";
            }

            double speed = bytesTransferred / ts.TotalSeconds;
            if (speed < 1)
                outstring += string.Format(" at {0:F3} B/s", speed);
            else if (speed < 1024)
                outstring += string.Format(" at {0:F0} B/s", speed);
            else
                outstring += string.Format(" at {0:F0} KB/s", speed / 1024);


            Log("> " + outstring, RichTextBoxLogger.COLORCOMMAND);
        }

        void SetConnectedState(bool connected)
        {
            cbTransferMode.Enabled = numSpeedLimit.Enabled = cbModeZ.Enabled = connected;
            btConnect.Text = miConnect.Text = connected ? "Disconnect" : "Connect...";
            btCopy.Enabled = miCopy.Enabled = connected;
            tbxServerFolder.Enabled = connected;
            tbxLog.Enabled = connected;
            
            if (!connected)
            {
                tbxServerFolder.Text = ""; 
                lvServer.Items.Clear();
                lbServerStats.Text = "Not Connected";
            }
        }

        void ShowProgressBar(bool show)
        {
            lbProgress.Visible = progressBar.Visible = show;
            btView.Visible = btCopy.Visible = btMove.Visible = btNewFolder.Visible = btDelete.Visible = btRefresh.Visible = !show;

            if (show)
                _startTime = DateTime.Now;
        }

        void PopulateServerList(string path)
        {
            SftpItemCollection items = _ftp.GetList();

            int dirs = 0;
            int files = 0;
            long size = 0;

            // Clear the local list
            lvServer.Items.Clear();

            // directory up
            if (path.Length > _rootServerDir.Length)
            {
                ListViewItem item = new ListViewItem("..", 1);
                int n = path.LastIndexOf('/');
                item.Tag = new ListItemInfo(n > 0 ? path.Substring(0, n) : "/", true, true, false, false);
                lvServer.Items.Add(item);
                dirs++;
            }

            // Populate files and directories
            for (int c = 0; c < items.Count; c++)
            {
                string[] row = new string[5];
                SftpItem dirInfo = items[c];

                if (dirInfo.Name == "." || dirInfo.Name == "..")
                    continue;

                row[0] = Path.GetFileNameWithoutExtension(dirInfo.Name); // Name
                row[1] = Path.GetExtension(dirInfo.Name); // Ext
                row[2] = Common.BytesToString(dirInfo.Length); // Size
                row[3] = Common.FormatTime(dirInfo.LastWriteTime); // Last Write Time
                if (dirInfo.Permissions != null)
                    row[4] = dirInfo.Permissions.ToString();

                ListViewItem item = new ListViewItem(row, 1 + c);
                item.Tag = new ListItemInfo(path.TrimEnd('/', '\\') + "/" + dirInfo.Name, false, dirInfo.IsDirectory, dirInfo.IsFile, dirInfo.IsLink);
                if (dirInfo.IsDirectory)
                {
                    item.ImageIndex = 1;
                    dirs++;
                }
                else if (dirInfo.IsFile)
                {
                    item.ImageIndex = 0;
                    files++;
                    size += dirInfo.Length;
                }
                //else if (dirInfo.IsLink)
                //{
                //    item.ImageIndex = 2;
                //}
                lvServer.Items.Add(item);
            }

            // Update stats
            UpdateListStats(lbServerStats, dirs, files, size);
        }

        #region Event Handlers

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (_busy)
                return;

            if (_ftp != null)
            {
                _ftp.Disconnect();
                _ftp.Dispose();
                _ftp = null;

                SetConnectedState(false);
                return;
            }

            ConnectForm dlg = new ConnectForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _ftp = new Sftp();

                _ftp.LogWriter = new RichTextBoxLogger(tbxLog, tbxLog.MaxLength, LogLevel.Info);
                // set event handlers
                _ftp.StateChanged += OnStateChanged;
                _ftp.Scanning += OnScanning;
                _ftp.TransferProgressChanged += OnTransferProgress;
                _ftp.DeleteProgressChanged += OnDeleteProgress;
                _ftp.FileTransferIssue += OnFileTransferIssue;
                _ftp.Settings.DisableSftp4 = !dlg.Version4;

                try
                {
                    _ftp.BeginConnect(dlg.Server, dlg.Port, OnConnectFinish, dlg);
                }
                catch (Exception ex)
                {
                    Log(ex);
                    SetConnectedState(false);
                }
            }
        }

        void OnConnectFinish(IAsyncResult asyncResult)
        {
            try
            {
                _ftp.EndConnect(asyncResult);

                ConnectForm dlg = (ConnectForm) asyncResult.AsyncState;

                if (!_ftp.IsAuthenticated)
                    _ftp.Login(dlg.UserName, dlg.Password);

                _rootServerDir = _ftp.GetCurrentDirectory();
                tbxServerFolder.Text = _rootServerDir;

                PopulateServerList(_rootServerDir);

                SetConnectedState(true);
            }
            catch (Exception ex)
            {
                Log(ex);
                SetConnectedState(false);
                return;
            }
        }

        /// <summary>
        /// event displaying ftp state
        /// </summary>
        private void OnStateChanged(object sender, SftpStateChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case SftpState.Disconnected:
                case SftpState.Disposed:
                    SetConnectedState(false);
                    break;
                case SftpState.Ready:
                    break;
            }
        }

        /// <summary>
        /// handles the displaying traversing event
        /// </summary>
        void OnScanning(object sender, SftpDirectoryScanningEventArgs e)
        {
            if (e.Action == FileTransferType.Listing)
                return;

            string strBatchInfo = string.Format("({0} file{1} traversed)    ",
                e.FilesTotal, (e.FilesTotal > 1 ? "s" : null));

            switch (e.TraversingState)
            {
                case DirectoryScanningState.DirectoryRetrieved:
                    strBatchInfo += "Directory retrieved.";
                    break;
                case DirectoryScanningState.DirectoryRetrieving:
                    strBatchInfo += "Retrieving directory...";
                    break;
                case DirectoryScanningState.HierarchyRetrieved:
                    strBatchInfo += string.Format("Hierarchy retrieved ({0} byte{1} in {2} file{3}).",
                        e.BytesTotal, (e.BytesTotal > 1 ? "s" : null),
                        e.FilesTotal, (e.FilesTotal > 1 ? "s" : null));
                    break;
                case DirectoryScanningState.HierarchyRetrieving:
                    strBatchInfo += "Retrieving hierarchy...";
                    break;
            }

            lbProgress.Text = strBatchInfo;
        }

        /// <summary>
        /// handles the transfer progress changed event
        /// </summary>
        void OnTransferProgress(object sender, SftpFileTransferProgressEventArgs e)
        {
            string info = string.Format("({0} / {1} file{2} processed)    ",
                e.FilesProcessed, e.FilesTotal, (e.FilesProcessed > 1 ? "s" : null));

            SetProgressValue(Convert.ToInt32(e.ProgressPercentage));

            switch (e.TransferState)
            {
                case FileTransferProgressState.DataBlockProcessed:
                    info += Common.BytesToString(e.BytesTransferred);
                    break;
                case FileTransferProgressState.DirectoryProcessing:
                    info += "Processing directory...";
                    break;
                case FileTransferProgressState.FileTransferring:
                    info += "Transferring file...";
                    break;
                case FileTransferProgressState.FileTransferred:
                    info += "File transferred.";
                    break;
                case FileTransferProgressState.TransferCompleted:
                    info += "Transfer completed.";
                    ShowTransferStats(e.BytesTransferred, e.FilesTransferred);
                    break;
            }

            lbProgress.Text = info;
        }

        private void SetProgressValue(int value)
        {
            // workaround for progress bar smoothing
            if (value == 100)
            {
                progressBar.Maximum = 101;
                progressBar.Value = 101;
                progressBar.Maximum = 100;
                System.Threading.Thread.Sleep(200);
            }
            else
            {
                progressBar.Value = value;
            }
        }

        /// <summary>
        /// handles the delete progress changed event
        /// </summary>
        private void OnDeleteProgress(object sender, SftpDeleteProgressEventArgs e)
        {
            string strDeleteInfo = string.Format("({0} / {1} file{2} deleted)    ",
                e.FilesProcessed, e.FilesTotal, (e.FilesProcessed > 1 ? "s" : null));

            switch (e.DeleteState)
            {
                case DeleteProgressState.DeleteCompleted:
                    strDeleteInfo += "Delete completed.";
                    break;
                case DeleteProgressState.DirectoryDeleted:
                    strDeleteInfo += "Directory deleted.";
                    break;
                case DeleteProgressState.DirectoryProcessing:
                    strDeleteInfo += "Processing directory...";
                    break;
                case DeleteProgressState.FileDeleted:
                    strDeleteInfo += "File deleted.";
                    break;
                case DeleteProgressState.FileDeleting:
                    strDeleteInfo += "Deleting file...";
                    break;
            }

            lbProgress.Text = strDeleteInfo;
        }

        /// <summary>
        /// handles the batch transfer problem detected event
        /// </summary>
        private void OnFileTransferIssue(object sender, SftpIssueEventArgs e)
        {
            _problemForm.ShowModal(this, e);
        }

        private void miConnect_Click(object sender, EventArgs e)
        {
            btConnect_Click(null, e);
        }

        private void miDownload_Click(object sender, EventArgs e)
        {
            btCopy_Click(null, null);
        }

        #endregion

        #endregion

        #region Diagnostics

        void Log(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Error");
        }

        void Log(string message, Color color)
        {
            
        }

        #endregion

        private void miCreateFolder_Click(object sender, EventArgs e)
        {
            btNewFolder_Click(null, null);
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            btDelete_Click(null, null);
        }

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btMove_Click(null, null);
        }

        private void miRefresh_Click(object sender, EventArgs e)
        {
            btRefresh_Click(null, null);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btView_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btEdit_Click(null, null);
        }

        private void lvServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _serverListSelected = true;
            ListViewSelectIndexChanged(lvServer);
        }

        private void lvLocal_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        lvLocal_DoubleClick(null, null);
                        break;

                    case Keys.Delete:
                        btDelete_Click(null, null);
                        break;
                }
            }
        }

        private void lvServer_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        lvServer_DoubleClick(null, null);
                        break;

                    case Keys.Delete:
                        btDelete_Click(null, null);
                        break;
                }
            }
        }

        private void lvServer_DoubleClick(object sender, EventArgs e)
        {
            string dirName = ((ListItemInfo)lvServer.SelectedItems[0].Tag).FullPath;

            try
            {
                _ftp.ChangeDirectory(dirName);
                UpdateServerList(dirName);
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void btView_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serverListSelected)
                {
                    List<ListItemInfo> items = GetSelectedItems(lvServer);
                    if (items.Count > 0)
                    {
                        string tmpFile = Path.GetTempFileName() + "-" + Path.GetFileName(items[0].FullPath);
                        _ftp.GetFile(items[0].FullPath, tmpFile);

                        Process.Start("notepad", tmpFile);
                    }
                }
                else
                {
                    List<ListItemInfo> items = GetSelectedItems(lvLocal);
                    if (items.Count > 0)
                    {
                        Process.Start("notepad", items[0].FullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            // Should be implemented by developer
        }

        private void btCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serverListSelected)
                {
                    List<ListItemInfo> items = GetSelectedItems(lvServer);
                    if (items.Count > 0)
                    {
                        ShowProgressBar(true);
                        foreach (ListItemInfo item in items)
                        {
                            _ftp.Download(item.FullPath, tbxLocalFolder.Text, SearchMode.Recursive, FileCopyType.Copy, OverwriteMode.ThrowException);
                        }
                        
                        UpdateLocalList(tbxLocalFolder.Text);
                    }
                }
                else
                {
                    List<ListItemInfo> items = GetSelectedItems(lvLocal);
                    if (items.Count > 0)
                    {
                        ShowProgressBar(true);
                        foreach (ListItemInfo item in items)
                        {
                            _ftp.Upload(item.FullPath, tbxServerFolder.Text, SearchMode.Recursive, FileCopyType.Copy, OverwriteMode.ThrowException);
                        }

                        UpdateServerList(tbxServerFolder.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
            finally
            {
                ShowProgressBar(false);
            }
        }

        private void btMove_Click(object sender, EventArgs e)
        {

        }

        private void btNewFolder_Click(object sender, EventArgs e)
        {
            NewNameForm dlg = new NewNameForm("New Folder");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_serverListSelected)
                    {
                        _ftp.CreateDirectory(dlg.NewName);
                        UpdateServerList(tbxServerFolder.Text.TrimEnd('/', '\\') + "/" + dlg.NewName);
                    }
                    else
                    {
                        Directory.CreateDirectory(Path.Combine(tbxLocalFolder.Text, dlg.NewName));
                        UpdateLocalList(tbxLocalFolder.Text);
                    }
                }
                catch (Exception ex)
                {
                    Log(ex);
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            List<ListItemInfo> selectedItems = _serverListSelected
                                                   ? GetSelectedItems(lvServer)
                                                   : GetSelectedItems(lvLocal);
            if (MessageBox.Show(this, string.Format("Do you really want to delete {0}", selectedItems.Count == 1 ? Path.GetFileName(selectedItems[0].FullPath) : (selectedItems.Count + " items")), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    // Delete selected items
                    foreach (ListItemInfo item in selectedItems)
                    {
                        if (_serverListSelected)
                            _ftp.Delete(item.FullPath, SearchMode.Recursive);
                        else
                        {
                            if (item.IsFile)
                                File.Delete(item.FullPath);
                            else
                                Directory.Delete(item.FullPath, true);
                        }
                    }

                    // Refresh the server or local list
                    if (_serverListSelected)
                        UpdateServerList(tbxServerFolder.Text);
                    else
                        UpdateLocalList(tbxLocalFolder.Text);
                }
                catch (Exception ex)
                {
                    Log(ex);
                }
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            UpdateLocalList(tbxLocalFolder.Text);
            if (tbxServerFolder.Enabled)
                UpdateServerList(tbxServerFolder.Text);
        }

        private void cbTransferMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ftp == null)
                return;

            switch (cbTransferMode.SelectedIndex)
            {
                case 0: // Binary
                    _ftp.TransferType = SftpTransferType.Binary;
                    break;

                case 1: // Text
                    _ftp.TransferType = SftpTransferType.Ascii;
                    break;
            }
        }

        private void cbModeZ_CheckedChanged(object sender, EventArgs e)
        {
            if (_ftp == null)
                return;

            _ftp.Settings.SshParameters.Compression = cbModeZ.Checked;
        }

        private void numSpeedLimit_ValueChanged(object sender, EventArgs e)
        {
            _ftp.MaxDownloadSpeed = _ftp.MaxUploadSpeed = (int)numSpeedLimit.Value;
        }
    }

    class ListItemInfo
    {
        public string FullPath;
        public bool IsUpper;
        public bool IsDirectory;
        public bool IsFile;
        public bool IsLink;
        public long Size;
        public DateTime Time;

        public ListItemInfo(string fullPath, bool isUpper, bool isDirectory, bool isFile, bool isLink)
        {
            FullPath = fullPath;
            IsUpper = isUpper;
            IsDirectory = isDirectory;
            IsFile = isFile;
            IsLink = isLink;
        }
    }
}
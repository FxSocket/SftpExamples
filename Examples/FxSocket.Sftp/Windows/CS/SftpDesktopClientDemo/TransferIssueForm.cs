using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using FxSocket.IO;
using FxSocket.FileSystem;
using FxSocket.Net;

namespace FxSocketSamples
{
	/// <summary>
	/// Problem handling form.
	/// </summary>
	public class TransferIssueForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.RadioButton btnSkip;
        private System.Windows.Forms.RadioButton btnRename;
        private System.Windows.Forms.RadioButton btnOverwrite;
		private System.Windows.Forms.RadioButton btnOverwriteOlder;
        private System.Windows.Forms.RadioButton btnOverwriteDiffSize;
		private System.Windows.Forms.RadioButton btnFollowLink;
		private System.Windows.Forms.RadioButton btnResume;

		// event arguments
        private IssueEventArgs _arguments;

		// list of problem types the user chose to skip
		private readonly Hashtable _skipProblemTypes = new Hashtable();

		// true if the user chose to overwrite all existing files
	    private FileOverwriteCondition _overwriteCondition;

		// true if the user chose to overwrite all older files
        private RadioButton btnOverwriteDiffChecksum;

		// true if the user chose to overwrite all files with a different size
		private Button okBtn;
        private Button retryBtn;
        private Button cancelBtn;
        private CheckBox rememberAction;

		public TransferIssueForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Initialize the form for using it again in new batch transfer.
		/// </summary>
		/// <remarks>
		/// Clears the user's chosen default actions.
		/// </remarks>
		public void Initialize()
		{
			_skipProblemTypes.Clear();
		}

		/// <summary>
		/// Shows the form as a modal dialog box.
		/// The form's buttons are shown according to possible actions taken from the given event argument.
		/// </summary>
		/// <param name="e">Event argument describing the type of a problem.</param>
        public void ShowModal(Control form, IssueEventArgs e)
		{
			if (e == null)
				throw new ArgumentNullException("e");

			// if the user chose to skip this problem type, skip it
            if (_skipProblemTypes.ContainsKey(e.IssueType))
			{
                if (e.IssueType == TransferIssueType.FileExists)
                    e.Overwrite(_overwriteCondition);
                else
			        e.Skip();
				return;
			}

			// if the problem is FileExists check, whether the user have chosen any default action already
            if (e.IssueType == TransferIssueType.FileExists)
			{
				// format the text according to action in progress (Downloading or Uploading)
				string messageFormat = "Overwrite file: {0}\n\t{1} Bytes, {2}\n\nwith file: {3}\n\t{4} Bytes, {5}";
				if (e.Action == FileTransferType.Downloading)
				{
					lblMessage.Text = string.Format(messageFormat,
						e.LocalPath, e.LocalItem.Length, e.LocalItem.LastWriteTime,
						e.RemotePath, e.RemoteItem.Length, e.RemoteItem.LastWriteTime);
				}
				else
				{
					lblMessage.Text = string.Format(messageFormat,
						e.RemotePath, e.RemoteItem.Length, e.RemoteItem.LastWriteTime,
						e.LocalPath, e.LocalItem.Length, e.LocalItem.LastWriteTime);
				}

				lblMessage.TextAlign = ContentAlignment.MiddleLeft;
			    this.Text = "Target file already exists";
			}
			else
			{
                lblMessage.Text = e.Exception.Message;
				lblMessage.TextAlign = ContentAlignment.MiddleCenter;
			}

			// store the event arguments for later use at button click handler
			_arguments = e;

			// only enable buttons that represent a possible action
			cancelBtn.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Cancel);
			btnSkip.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Skip);
			retryBtn.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Retry);
			btnRename.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Rename);
			btnOverwrite.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite);
			btnOverwriteOlder.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite);
			btnOverwriteDiffSize.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Overwrite);
            btnOverwriteDiffChecksum.Enabled = e.IsOverwriteConditionPossible(FileOverwriteCondition.ChecksumDiffers);
			btnFollowLink.Enabled = e.IsReactionPossible(FileTransferIssueReaction.FollowLink);
			btnResume.Enabled = e.IsReactionPossible(FileTransferIssueReaction.Resume);

			// select default action button
			SetDefaultActionButton(e);

			ShowDialog(form);
		}

		/// <summary>
		/// Selects the button according to default action.
		/// </summary>
		/// <param name="action">Default action.</param>
        private void SetDefaultActionButton(IssueEventArgs e)
		{
			switch (e.Reaction)
			{
				case FileTransferIssueReaction.Cancel: cancelBtn.Select(); break;
				case FileTransferIssueReaction.Fail: cancelBtn.Select(); break;
				case FileTransferIssueReaction.Skip: btnSkip.Select(); break;
				case FileTransferIssueReaction.Retry: retryBtn.Select(); break;
				case FileTransferIssueReaction.Rename: btnRename.Select(); break;
				case FileTransferIssueReaction.FollowLink: btnFollowLink.Select(); break;
				case FileTransferIssueReaction.Resume: btnResume.Select(); break;
				case FileTransferIssueReaction.Overwrite:
					switch (e.OverwriteCondition)
					{
						case FileOverwriteCondition.None: btnOverwrite.Select(); break;
                        case FileOverwriteCondition.Older: btnOverwriteOlder.Select(); break;
                        case FileOverwriteCondition.SizeDiffers: btnOverwriteDiffSize.Select(); break;
                        case FileOverwriteCondition.ChecksumDiffers: btnOverwriteDiffChecksum.Select(); break;
					}
					break;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            this.btnSkip = new System.Windows.Forms.RadioButton();
            this.btnRename = new System.Windows.Forms.RadioButton();
            this.btnOverwrite = new System.Windows.Forms.RadioButton();
            this.btnOverwriteOlder = new System.Windows.Forms.RadioButton();
            this.btnOverwriteDiffSize = new System.Windows.Forms.RadioButton();
            this.btnFollowLink = new System.Windows.Forms.RadioButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.RadioButton();
            this.btnOverwriteDiffChecksum = new System.Windows.Forms.RadioButton();
            this.okBtn = new System.Windows.Forms.Button();
            this.retryBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.rememberAction = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(271, 160);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(179, 24);
            this.btnSkip.TabIndex = 7;
            this.btnSkip.Text = "&Skip";
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(271, 130);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(157, 24);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "&Rename...";
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.Location = new System.Drawing.Point(12, 100);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Size = new System.Drawing.Size(157, 24);
            this.btnOverwrite.TabIndex = 1;
            this.btnOverwrite.Text = "&Overwrite";
            // 
            // btnOverwriteOlder
            // 
            this.btnOverwriteOlder.Location = new System.Drawing.Point(12, 130);
            this.btnOverwriteOlder.Name = "btnOverwriteOlder";
            this.btnOverwriteOlder.Size = new System.Drawing.Size(157, 24);
            this.btnOverwriteOlder.TabIndex = 2;
            this.btnOverwriteOlder.Text = "Overwrite Older File";
            // 
            // btnOverwriteDiffSize
            // 
            this.btnOverwriteDiffSize.Location = new System.Drawing.Point(11, 160);
            this.btnOverwriteDiffSize.Name = "btnOverwriteDiffSize";
            this.btnOverwriteDiffSize.Size = new System.Drawing.Size(157, 24);
            this.btnOverwriteDiffSize.TabIndex = 3;
            this.btnOverwriteDiffSize.Text = "Overwrite &If Size Differs";
            // 
            // btnFollowLink
            // 
            this.btnFollowLink.Location = new System.Drawing.Point(271, 190);
            this.btnFollowLink.Name = "btnFollowLink";
            this.btnFollowLink.Size = new System.Drawing.Size(157, 24);
            this.btnFollowLink.TabIndex = 8;
            this.btnFollowLink.Text = "Follow &Link";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Location = new System.Drawing.Point(8, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(580, 89);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(271, 100);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(179, 24);
            this.btnResume.TabIndex = 5;
            this.btnResume.Text = "Resume";
            // 
            // btnOverwriteDiffChecksum
            // 
            this.btnOverwriteDiffChecksum.Location = new System.Drawing.Point(11, 190);
            this.btnOverwriteDiffChecksum.Name = "btnOverwriteDiffChecksum";
            this.btnOverwriteDiffChecksum.Size = new System.Drawing.Size(179, 24);
            this.btnOverwriteDiffChecksum.TabIndex = 4;
            this.btnOverwriteDiffChecksum.Text = "Overwrite If Checksum Differs";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Location = new System.Drawing.Point(349, 264);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 31;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // retryBtn
            // 
            this.retryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.retryBtn.Location = new System.Drawing.Point(430, 264);
            this.retryBtn.Name = "retryBtn";
            this.retryBtn.Size = new System.Drawing.Size(75, 23);
            this.retryBtn.TabIndex = 32;
            this.retryBtn.Text = "Retry";
            this.retryBtn.UseVisualStyleBackColor = true;
            this.retryBtn.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(511, 264);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 33;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rememberAction
            // 
            this.rememberAction.AutoSize = true;
            this.rememberAction.Location = new System.Drawing.Point(11, 230);
            this.rememberAction.Name = "rememberAction";
            this.rememberAction.Size = new System.Drawing.Size(141, 17);
            this.rememberAction.TabIndex = 20;
            this.rememberAction.Text = "Use this action next time";
            this.rememberAction.UseVisualStyleBackColor = true;
            // 
            // TransferIssueForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(598, 299);
            this.Controls.Add(this.rememberAction);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.retryBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.btnOverwriteOlder);
            this.Controls.Add(this.btnOverwriteDiffChecksum);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnFollowLink);
            this.Controls.Add(this.btnOverwriteDiffSize);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSkip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransferIssueForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transfer Problem Detected";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_arguments.Cancel();
			Close();
		}

		private void btnSkip_Click(object sender, System.EventArgs e)
		{
			_arguments.Skip();
			Close();
		}

		private void btnRetry_Click(object sender, System.EventArgs e)
		{
			_arguments.Retry();
			Close();
		}

		private void btnRename_Click(object sender, System.EventArgs e)
		{
			// initialize the renaming form
			NewNameForm formNewName = new NewNameForm();

			// set the current file name
			string oldName = Path.GetFileName(_arguments.LocalPath);
			formNewName.NewName = oldName;

			// show the form
			DialogResult result = formNewName.ShowDialog(this);

			// get the new name
			string newName = formNewName.NewName;

			// check whether the user clicked on OK and insert something nonempty and something else
			if (result != DialogResult.OK || newName.Length == 0 || newName == oldName)
				return;

			// set the appropriate action and new name to the event arguments
			_arguments.Rename(newName);
			Close();
		}

		void DoAction()
        {
            if (btnSkip.Checked)
                _arguments.Skip();
            else if (btnOverwrite.Checked)
            {
                _arguments.Overwrite();
                _overwriteCondition = FileOverwriteCondition.None;
            }
            else if (btnOverwriteOlder.Checked)
            {
                _arguments.Overwrite(FileOverwriteCondition.Older);
                _overwriteCondition = FileOverwriteCondition.Older;
            }
            else if (btnOverwriteDiffSize.Checked)
            {
                _arguments.Overwrite(FileOverwriteCondition.SizeDiffers);
                _overwriteCondition = FileOverwriteCondition.SizeDiffers;
            }
            else if (btnOverwriteDiffChecksum.Checked)
            {
                _arguments.Overwrite(FileOverwriteCondition.ChecksumDiffers);
                _overwriteCondition = FileOverwriteCondition.ChecksumDiffers;
            }
            else if (btnFollowLink.Checked)
                _arguments.FollowLink();
            else if (btnResume.Checked)
                _arguments.Resume();

            Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (rememberAction.Checked)
                // add the problem to the table of automatically skipped problems
                _skipProblemTypes.Add(_arguments.IssueType, null);

            DoAction();
        }
	}
}

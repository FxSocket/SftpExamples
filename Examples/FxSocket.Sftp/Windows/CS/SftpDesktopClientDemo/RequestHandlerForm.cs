using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using FxSocket.Security;

namespace FxSocket.Samples.WinFormClient
{
	/// <summary>
	/// Summary description for RequesetHandlerForm.
	/// </summary>
	public class RequesetHandlerForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNoCertificate;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCertList;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lblValidTo;
		private System.Windows.Forms.Label lblValidFrom;
		private System.Windows.Forms.Label lblIssuer;
		private System.Windows.Forms.Label lblSubject;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private SysCertificate[] _certs;
        private SysCertificate _selectedCertificate;

        public SysCertificate Certificate 
		{
			get 
			{
				return _selectedCertificate;
			}
		}

		public RequesetHandlerForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void LoadData(SysCertificate[] certs) 
		{
			_certs = certs;

			for (int i = 0; i < certs.Length; i++) 
			{
				cbCertList.Items.Add(certs[i].GetSubjectName());
			}

			if (certs.Length > 0) 
			{
				cbCertList.SelectedIndex = 0;

				lblSubject.Text = certs[0].GetSubjectName();
				lblIssuer.Text = certs[0].GetIssuerName();
				lblValidFrom.Text = certs[0].GetEffectiveDate().ToString();
				lblValidTo.Text = certs[0].GetExpirationDate().ToString();
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cbCertList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblValidTo = new System.Windows.Forms.Label();
            this.lblValidFrom = new System.Windows.Forms.Label();
            this.lblIssuer = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNoCertificate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(336, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(160, 216);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "&OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cbCertList
            // 
            this.cbCertList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCertList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCertList.Location = new System.Drawing.Point(104, 8);
            this.cbCertList.Name = "cbCertList";
            this.cbCertList.Size = new System.Drawing.Size(304, 21);
            this.cbCertList.TabIndex = 2;
            this.cbCertList.SelectedIndexChanged += new System.EventHandler(this.cbCertList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Certificate:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Certificate details:";
            // 
            // lblValidTo
            // 
            this.lblValidTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidTo.Location = new System.Drawing.Point(80, 136);
            this.lblValidTo.Name = "lblValidTo";
            this.lblValidTo.Size = new System.Drawing.Size(224, 23);
            this.lblValidTo.TabIndex = 10;
            // 
            // lblValidFrom
            // 
            this.lblValidFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValidFrom.Location = new System.Drawing.Point(80, 112);
            this.lblValidFrom.Name = "lblValidFrom";
            this.lblValidFrom.Size = new System.Drawing.Size(224, 23);
            this.lblValidFrom.TabIndex = 9;
            // 
            // lblIssuer
            // 
            this.lblIssuer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssuer.Location = new System.Drawing.Point(80, 72);
            this.lblIssuer.Name = "lblIssuer";
            this.lblIssuer.Size = new System.Drawing.Size(312, 32);
            this.lblIssuer.TabIndex = 8;
            // 
            // lblSubject
            // 
            this.lblSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubject.Location = new System.Drawing.Point(80, 32);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(312, 32);
            this.lblSubject.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valid to:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valid from:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Issuer:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject:";
            // 
            // btnNoCertificate
            // 
            this.btnNoCertificate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNoCertificate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNoCertificate.Location = new System.Drawing.Point(240, 216);
            this.btnNoCertificate.Name = "btnNoCertificate";
            this.btnNoCertificate.Size = new System.Drawing.Size(88, 23);
            this.btnNoCertificate.TabIndex = 5;
            this.btnNoCertificate.Text = "&No Certificate";
            this.btnNoCertificate.Click += new System.EventHandler(this.btnNoCertificate_Click);
            // 
            // RequesetHandlerForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(418, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btnNoCertificate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCertList);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblValidTo);
            this.Controls.Add(this.lblValidFrom);
            this.Controls.Add(this.lblIssuer);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequesetHandlerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select certificate";
            this.ResumeLayout(false);

		}
		#endregion

		private void cbCertList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (cbCertList.SelectedIndex != -1) 
			{
				int selIndex = cbCertList.SelectedIndex;

				lblSubject.Text = _certs[selIndex].GetSubjectName();
				lblIssuer.Text = _certs[selIndex].GetIssuerName();
				lblValidFrom.Text = _certs[selIndex].GetEffectiveDate().ToString();
				lblValidTo.Text = _certs[selIndex].GetExpirationDate().ToString();
			}
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if (cbCertList.SelectedIndex != -1)
				_selectedCertificate = _certs[cbCertList.SelectedIndex];
			else
				_selectedCertificate = null;

			this.Close();
		}

		private void btnNoCertificate_Click(object sender, System.EventArgs e)
		{
			_selectedCertificate = null;
			this.Close();
		}
	}
}

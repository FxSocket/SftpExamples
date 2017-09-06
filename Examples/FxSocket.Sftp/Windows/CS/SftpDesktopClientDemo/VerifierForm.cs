using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FxSocketSamples
{
	/// <summary>
	/// Summary description for Verifier.
	/// </summary>
	public class VerifierForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnOkAndTrust;

		private bool _accepted = false;
        private Label lblHostname;
        private Label label8;
        private Label label6;
        private Label lblValidTo;
        private Label lblValidFrom;
        private Label lblIssuer;
        private Label lblSubject;
        private Label lblProblem;
        private Panel panel2;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
		private bool _addIssuerCertificateAuthothorityToTrustedCaStore = false;

		public string Hostname
		{
			set { lblHostname.Text = value; }
		}

		public string Subject
		{
			set { lblSubject.Text = value; }
		}

		public string Issuer
		{
			set { lblIssuer.Text = value; }
		}

		public string ValidFrom
		{
			set { lblValidFrom.Text = value; }
		}

		public string ValidTo
		{
			set { lblValidTo.Text = value; }
		}

		public string Problem
		{
			set { lblProblem.Text = value; }
		}

		public bool Accepted
		{
			get { return _accepted; }
		}

		public bool AddIssuerCertificateAuthothorityToTrustedCaStore
		{
			get { return _addIssuerCertificateAuthothorityToTrustedCaStore; }
		}

		public bool ShowAddIssuerToTrustedCaStoreButton
		{
			get { return btnOkAndTrust.Visible; }
			set { btnOkAndTrust.Visible = value; }
		}

		public VerifierForm()
		{
			InitializeComponent();
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
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnOkAndTrust = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblProblem = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblIssuer = new System.Windows.Forms.Label();
            this.lblValidFrom = new System.Windows.Forms.Label();
            this.lblValidTo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReject
            // 
            this.btnReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReject.Location = new System.Drawing.Point(336, 329);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(72, 23);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAccept.Location = new System.Drawing.Point(99, 329);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(72, 23);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnOkAndTrust
            // 
            this.btnOkAndTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkAndTrust.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOkAndTrust.Location = new System.Drawing.Point(177, 329);
            this.btnOkAndTrust.Name = "btnOkAndTrust";
            this.btnOkAndTrust.Size = new System.Drawing.Size(153, 23);
            this.btnOkAndTrust.TabIndex = 5;
            this.btnOkAndTrust.Text = "Always Trust this Authority";
            this.btnOkAndTrust.Visible = false;
            this.btnOkAndTrust.Click += new System.EventHandler(this.btnOkAndTrust_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "CERTIFICATE INFORMATION:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subject:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Issuer:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valid from:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valid to:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(8, 200);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 3);
            this.panel2.TabIndex = 5;
            // 
            // lblProblem
            // 
            this.lblProblem.ForeColor = System.Drawing.Color.Red;
            this.lblProblem.Location = new System.Drawing.Point(8, 216);
            this.lblProblem.Name = "lblProblem";
            this.lblProblem.Size = new System.Drawing.Size(384, 72);
            this.lblProblem.TabIndex = 6;
            // 
            // lblSubject
            // 
            this.lblSubject.Location = new System.Drawing.Point(80, 56);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(312, 40);
            this.lblSubject.TabIndex = 7;
            // 
            // lblIssuer
            // 
            this.lblIssuer.Location = new System.Drawing.Point(80, 104);
            this.lblIssuer.Name = "lblIssuer";
            this.lblIssuer.Size = new System.Drawing.Size(312, 40);
            this.lblIssuer.TabIndex = 8;
            // 
            // lblValidFrom
            // 
            this.lblValidFrom.Location = new System.Drawing.Point(80, 152);
            this.lblValidFrom.Name = "lblValidFrom";
            this.lblValidFrom.Size = new System.Drawing.Size(224, 23);
            this.lblValidFrom.TabIndex = 9;
            // 
            // lblValidTo
            // 
            this.lblValidTo.Location = new System.Drawing.Point(80, 176);
            this.lblValidTo.Name = "lblValidTo";
            this.lblValidTo.Size = new System.Drawing.Size(224, 23);
            this.lblValidTo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Certificate details:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hostname:";
            // 
            // lblHostname
            // 
            this.lblHostname.Location = new System.Drawing.Point(80, 32);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(312, 16);
            this.lblHostname.TabIndex = 13;
            // 
            // VerifierForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(418, 364);
            this.ControlBox = false;
            this.Controls.Add(this.btnOkAndTrust);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.lblHostname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblValidTo);
            this.Controls.Add(this.lblValidFrom);
            this.Controls.Add(this.lblIssuer);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblProblem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "VerifierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificate";
            this.ResumeLayout(false);

		}
		#endregion

		private void btnAccept_Click(object sender, System.EventArgs e)
		{
			_accepted = true;
			this.Close();
		}

		private void btnReject_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOkAndTrust_Click(object sender, System.EventArgs e)
		{
			_accepted = true;
			_addIssuerCertificateAuthothorityToTrustedCaStore = true;

			this.Close();
		}

	}
}

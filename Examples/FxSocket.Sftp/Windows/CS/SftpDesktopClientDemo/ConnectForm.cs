using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FxSocket.Net;

namespace FxSocketSamples
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();


            Server = (string)Common.GetKey("Server", "");
            Port = Common.GetKey("Port", 21);

            UserName = (string)Common.GetKey("User", "");
            Password = (string)Common.GetKey("Pass", "");
            UseUtf8Encoding = Common.GetKey("Utf8", false);

            ClientKey = (string)Common.GetKey("Cert", "");

            ProxyHost = (string)Common.GetKey("ProxyHost", "");
            ProxyPort = Common.GetKey("ProxyPort", 1080);
            ProxyType = (NetProxyType)Common.GetKey("ProxyType", 0);
            ProxyAuthnMethod = (ProxyAuthenticationType)Common.GetKey("ProxyAuthnMethod", 0);
            ProxyUser = (string)Common.GetKey("ProxyUser", "");
            ProxyPassword = (string)Common.GetKey("ProxyPassword", "");
            ProxyDomain = (string)Common.GetKey("ProxyDomain", "");
        }

        public string Server
        {
            get { return tbServer.Text; }
            set { tbServer.Text = value; }
        }

        public int Port
        {
            get { return (int)tbPort.Value; }
            set { tbPort.Value = value; }
        }

        public string UserName
        {
            get { return tbUserName.Text; }
            set { tbUserName.Text = value; }
        }

        public string Password
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }

        public bool UseUtf8Encoding
        {
            get { return cbUtf8Encoding.Checked; }
            set { cbUtf8Encoding.Checked = value; }
        }

        public bool Version4
        {
            get { return cbSftpv4.Checked; }
            set { cbSftpv4.Checked = value; }
        }

        #region Security

        public string ClientKey
        {
            get { return tbCert.Text; }
            set { tbCert.Text = value; }
        }

        #endregion

        #region Proxy

        public string ProxyHost
        {
            get { return tbProxyHost.Text; }
            set { tbProxyHost.Text = value; }
        }

        public int ProxyPort
        {
            get { return (int)tbProxyPort.Value; }
            set { tbProxyPort.Value = value; }
        }

        public string ProxyUser
        {
            get { return tbProxyUser.Text; }
            set { tbProxyUser.Text = value; }
        }

        public string ProxyPassword
        {
            get { return tbProxyPassword.Text; }
            set { tbProxyPassword.Text = value; }
        }

        public string ProxyDomain
        {
            get { return tbProxyDomain.Text; }
            set { tbProxyDomain.Text = value; }
        }

        public NetProxyType ProxyType
        {
            get { return (NetProxyType)cbxProxyType.SelectedIndex; }
            set { cbxProxyType.SelectedIndex = (int)value; }
        }

        public ProxyAuthenticationType ProxyAuthnMethod
        {
            get { return (ProxyAuthenticationType)cbxProxyMethod.SelectedIndex; }
            set { cbxProxyMethod.SelectedIndex = (int)value; }
        }

        #endregion

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Common.SetKey("Server", Server);
            Common.SetKey("Port", Port);
            
            Common.SetKey("User", UserName);
            Common.SetKey("Pass", Password);
            Common.SetKey("Utf8", UseUtf8Encoding);
            Common.SetKey("v4", Version4);

            Common.SetKey("Cert", ClientKey);

            Common.SetKey("ProxyHost", ProxyHost);
            Common.SetKey("ProxyPort", ProxyPort);
            Common.SetKey("ProxyType", ProxyType);
            Common.SetKey("ProxyAuthnMethod", ProxyAuthnMethod);
            Common.SetKey("ProxyUser", ProxyUser);
            Common.SetKey("ProxyPassword", ProxyPassword);
            Common.SetKey("ProxyDomain", ProxyDomain);
        }

        private void certBrowseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select a private key file";
                dlg.FileName = tbCert.Text;
                dlg.Filter = "All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    tbCert.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}

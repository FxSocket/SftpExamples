using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FxSocketSamples
{
    public partial class NewNameForm : Form
    {
        public NewNameForm()
        {
            InitializeComponent();
        }

        public NewNameForm(string title) : this()
        {
            this.Text = title;
        }

        /// <summary>
        /// Gets the new name.
        /// </summary>
        public string NewName
        {
            get
            {
                return txtNewName.Text;
            }
            set { txtNewName.Text = value; }
        }
    }
}

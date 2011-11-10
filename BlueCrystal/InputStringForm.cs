using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlueCrystal
{
    public partial class InputStringForm : Form
    {
        public InputStringForm()
        {
            InitializeComponent();
        }

        public String ReturnString
        {
            get { return textBoxProfileName.Text; }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ReturnString))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

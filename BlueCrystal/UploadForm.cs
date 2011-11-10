using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BlueCrystal
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
            string user = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnUser", "");
            string pw = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnAuth", "");

            if(!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pw))
            {
                checkBox1.Checked = true;
                textBoxUsername.Text = user;
                textBoxPassword.Text = pw;
            }
        }

        private void linkLabelRepository_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://code.google.com/p/bluecrystaldict/");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Please enter a short summary of the changes you did.", "Commit");
                return;
            }
            this.Enabled = false;
            Cursor = Cursors.WaitCursor;
            if (checkBox1.Checked)
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnUser", textBoxUsername.Text);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnAuth", textBoxPassword.Text);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnUser", "");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "SvnAuth", "");
            }

            Program.RunSvn("add", "\"" + Path.Combine(Program.DataFolderPath, "\\*") + "\" --force --depth infinity");
            string asdf = Program.RunSvn("commit", "\"" + Program.DataFolderPath + "\" -q -m \"" + textBoxDescription.Text + "\" --depth infinity --username " + textBoxUsername.Text + " --password "  + textBoxPassword.Text + " --no-auth-cache --non-interactive --trust-server-cert");
            Cursor = Cursors.Default;

            if (string.IsNullOrEmpty(asdf))
            {
                MessageBox.Show("Commit Successful.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Commit Failed.\r\nNote: The Google Code Password differs from the Google Password!\r\n:\r\n" + asdf, "Error");
                this.Enabled = true;
            }
        }
    }
}

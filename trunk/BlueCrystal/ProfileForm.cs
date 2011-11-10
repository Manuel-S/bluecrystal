using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using BlueCrystal.Classes;
using System.IO;

namespace BlueCrystal
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
            profile = new List<Profil>();
            languages = new List<string>();
        }
        private List<Profil> profile;
        private List<String> languages;

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            String profiles = (String) Registry.GetValue(@"HKEY_CURRENT_USER\Software\BlueCrystal", "ProfileNames", String.Empty);
            if (profiles == null)
            {
                profiles = String.Empty;
            }
            String[] split = profiles.Split(';');
            foreach (String name in split)
            {
                if (!String.IsNullOrEmpty(name))
                    profile.Add(new Profil(name));
            }
            setProfiles(String.Empty);

            if (Directory.Exists(Program.DataFolderPath))
            {
                IEnumerable<String> dirs = Directory.GetDirectories(Program.DataFolderPath).Select(Path.GetFileName);
                languages.AddRange(dirs);
                languages.Remove(".svn");
                languages.Remove("Voice");
                languages.Remove("Images");
                comboBoxLanguage.DataSource = languages;
            }
        }

        public Profil Profil
        {
            get;
            private set;
        }

        public String Sprache
        {
            get;
            private set;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputStringForm form = new InputStringForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                profile.Add(new Profil(form.ReturnString));
                setProfiles(form.ReturnString);
            }
        }

        private void setProfiles(String currentProfile)
        {
            comboBoxProfile.DataSource = null;
            comboBoxProfile.DataSource = profile;
            comboBoxProfile.SelectedText = currentProfile;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxLanguage.Text) || string.IsNullOrEmpty(comboBoxProfile.Text))
            {
                MessageBox.Show("You need to Select a Profile and a Language to continue");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Profil = new Profil(comboBoxProfile.Text);
            this.Sprache = comboBoxLanguage.Text;
            this.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxLanguage.Text))
            {
                new LektionEditor(comboBoxLanguage.Text).ShowDialog();
            }
        }
    }
}

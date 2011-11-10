using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    public partial class LektionEditor : Form
    {
        public LektionEditor(String sprache)
        {
            InitializeComponent();
            this.sprache = sprache;
            Text = sprache + " - Editor";
            lektionen = new List<Lektion>();
        }

        private readonly String sprache;

        private bool initialized = false;

        private readonly List<Lektion> lektionen;

        private void buttonNewLektion_Click(object sender, EventArgs e)
        {
            InputStringForm form = new InputStringForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                if (!File.Exists(Program.DataFolderPath + "\\" + sprache + "\\" + form.ReturnString + ".xml"))
                {
                    Lektion temp = new Lektion{
                            Karteien = new List<Kartei>(), 
                            Name = form.ReturnString, 
                            Sprachen = new List<string>()};
                    temp.Save(Program.DataFolderPath + "\\" + sprache + "\\" + form.ReturnString + ".xml");
                    lektionen.Add(temp);
                    comboBoxLektion.DataSource = null;
                    comboBoxLektion.DataSource = lektionen;
                    if (comboBoxLektion.Items.Count > 0)
                        comboBoxLektion.SelectedIndex = comboBoxLektion.Items.Count - 1;
                    ActiveLecture(temp);
                }
            }
        }

        private void buttonNewKartei_Click(object sender, EventArgs e)
        {
            InputStringForm form = new InputStringForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                aktiv.Karteien.Add(new Kartei { Vorschau = form.ReturnString });
                comboBoxKartei.DataSource = null;
                comboBoxKartei.DataSource = aktiv.Karteien;
                if (comboBoxKartei.Items.Count > 0)
                    comboBoxKartei.SelectedIndex = comboBoxKartei.Items.Count - 1;
            }
        }

        private Lektion aktiv;

        private void ActiveLecture(Lektion lektion)
        {
            aktiv = lektion;
            comboBoxKartei.DataSource = null;
            comboBoxKartei.DataSource = lektion.Karteien;
            if (comboBoxKartei.Items.Count > 0)
                comboBoxKartei.SelectedIndex = 0;
            textBoxLangs.Text = string.Join(", ", lektion.Sprachen.ToArray());
        }

        private void LektionEditor_Load(object sender, EventArgs e)
        {
            if (!initialized)
            {
                DirectoryInfo langFolder = new DirectoryInfo(Program.DataFolderPath + "\\" + sprache);

                FileInfo[] split = langFolder.GetFiles();


                lektionen.Clear();

                int c = 0;
                foreach (FileInfo lektion in split)
                {
                    if (lektion.Extension != ".xml")
                    {
                        continue;
                    }

                    Lektion lecture = new Lektion(lektion);

                    lektionen.Add(lecture);

                    if (c == 0)
                    {
                        ActiveLecture(lecture);
                    }
                    c++;
                }
                comboBoxLektion.DataSource = null;
                comboBoxLektion.DataSource = lektionen;
                if (comboBoxLektion.Items.Count > 0)
                    comboBoxLektion.SelectedIndex = 0;
                initialized = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String[] langs = textBoxLangs.Text.Split(new[] {", ", ","}, StringSplitOptions.RemoveEmptyEntries);
            aktiv.Sprachen.Clear();
            aktiv.Sprachen.AddRange(langs);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            Cursor = Cursors.AppStarting;
            foreach (Lektion l in lektionen)
            {
                l.Save(Program.DataFolderPath + "\\" + sprache + "\\" + l.Name + ".xml");
            }
            buttonSave.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void buttonDeleteLektion_Click(object sender, EventArgs e)
        {
            lektionen.Remove(aktiv);
            File.Delete(Program.DataFolderPath + "\\" + sprache + "\\" + aktiv.Name + ".xml");
            comboBoxLektion.DataSource = null;
            comboBoxLektion.DataSource = lektionen;
            if (comboBoxLektion.Items.Count > 0)
                comboBoxLektion.SelectedIndex = 0;
        }

        private void buttonDeleteKartei_Click(object sender, EventArgs e)
        {
            Kartei t = aktiv.Karteien.First(k => k.Vorschau == comboBoxKartei.Text);
            if (t != null)
            {
                aktiv.Karteien.Remove(t);
                comboBoxKartei.DataSource = null;
                comboBoxKartei.DataSource = aktiv.Karteien;
                if (comboBoxKartei.Items.Count > 0)
                    comboBoxKartei.SelectedIndex = 0;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string t = aktiv.Sprachen.Find(s => aktiv.Sprachen.Count(z => z == s) > 1);
            if (!string.IsNullOrEmpty(t))
            {
                MessageBox.Show("Please do not use two matching language names, it will cause Errors. (and confusion.)", "Error");
            }
            else if (aktiv.Sprachen.Count < 2)
            {
                MessageBox.Show("Please add at least two languages.", "Error");
            }
            else if (!string.IsNullOrEmpty(comboBoxKartei.Text))
            {
                new VokabelEditor(aktiv, aktiv.Karteien.Find(k => k.Vorschau == comboBoxKartei.Text)).ShowDialog();
            }
            else
            {
                MessageBox.Show("Select/create a chapter first", "Error");
            }
        }

        private void comboBoxLektion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(Program.DataFolderPath + "\\" + sprache + "\\" + comboBoxLektion.Text + ".xml"))
            {
                ActiveLecture(lektionen.Find(l => l.Name == comboBoxLektion.Text));
            }
        }

        private void buttonDirections_Click(object sender, EventArgs e)
        {
            DirectionEditForm f = new DirectionEditForm(aktiv);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                aktiv.NichtAkzeptierteSprachen = f.Liste;
            }
        }

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            new UploadForm().ShowDialog();
        }

        private void buttonRevert_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Are you sure? This will delete all local changes you made.", "Revert", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                Program.RunSvn("revert", "\"" + Program.DataFolderPath + "\" --depth infinity");
                string asdf = Program.RunSvn("status", "\"" + Program.DataFolderPath + "\" --depth infinity");
                foreach (string a in asdf.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrEmpty(a) && a[0] == '?')
                    {
                        string b = a.Substring(8);
                        if (File.Exists(b))
                        {
                            File.Delete(b);
                        }
                        else if (Directory.Exists(b))
                        {
                            Directory.Delete(b, true);
                        }
                    }
                }
                MessageBox.Show("Undid all local changes.");
                initialized = false;
                LektionEditor_Load(this, new EventArgs());
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Program.RunCmd("explorer.exe", Program.DataFolderPath);
        }

        private void labelMoveDown_Click(object sender, EventArgs e)
        {
            var z = aktiv.Karteien.FindIndex(f => f.Vorschau == comboBoxKartei.Text);
            if (z >= 0 && z + 1 < comboBoxKartei.Items.Count)
            {
                aktiv.Karteien.Reverse(z, 2);
                ActiveLecture(aktiv);
                comboBoxKartei.SelectedIndex = z + 1;
            }
        }

        private void labelMoveUp_Click(object sender, EventArgs e)
        {
            var z = aktiv.Karteien.FindIndex(f => f.Vorschau == comboBoxKartei.Text);
            if (z >= 0 && z - 1 >= 0)
            {
                aktiv.Karteien.Reverse(z - 1, 2);
                ActiveLecture(aktiv);
                comboBoxKartei.SelectedIndex = z - 1;
            }
        }
    }
}

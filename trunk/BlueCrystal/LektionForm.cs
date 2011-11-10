using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueCrystal.Classes;
using System.IO;
using System.Collections;

namespace BlueCrystal
{
    public partial class LektionForm : Form
    {
        public LektionForm(Profil profil, String sprache)
        {
            InitializeComponent();

            this.profil = profil;
            this.sprache = sprache;

            tabControlDefault.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);

            textBoxNumber.Text = "0";
        }

        private Lektion activeLecture;

        private Profil profil;
        private String sprache;

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlDefault.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlDefault.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", (float)10.0, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void ActiveLecture(Lektion aktiv)
        {
            activeLecture = aktiv;
            comboBoxShowLang.DataSource = activeLecture.Sprachen;
            comboBoxShowLang.SelectedIndex = 0;

            setAskLangs();

            int count = aktiv.Karteien.Sum(k => k.Selected ? k.Vokabeln.Count : 0);
            textBoxNumber.Text = count.ToString();
            selectedVoks = count;
        }

        private bool initialized = false;

        private int selectedVoks = 0;

        private void LektionForm_Load(object sender, EventArgs e)
        {
            if (!initialized)
            {
                DirectoryInfo langFolder = new DirectoryInfo(Program.DataFolderPath + "\\" + sprache);

                FileInfo[] split = langFolder.GetFiles();

                int c = 0;
                if (split.Count() == 0)
                {
                    MessageBox.Show("You do not have any Lessons for this language.");
                    this.Close();
                    return;
                }
                foreach (FileInfo lektion in split)
                {
                    if (lektion.Extension != ".xml")
                    {
                        continue;
                    }

                    Lektion lecture = new Lektion(lektion);


                    TabPage temp = new TabPage();
                    temp.Text = lecture.Name;
                    temp.AutoScroll = true;
                    temp.UseVisualStyleBackColor = true;
                    temp.Location = new System.Drawing.Point(124, 4);
                    temp.Name = lecture.Name;
                    temp.Padding = new System.Windows.Forms.Padding(3);
                    temp.Size = new System.Drawing.Size(384, 288);
                    temp.Tag = lecture;

                    int count = 0;
                    foreach (Kartei k in lecture.Karteien)
                    {
                        KarteiControl ctrl = new KarteiControl(k);
                        temp.Controls.Add(ctrl);
                        ctrl.Location = new Point(6, 6 + ctrl.Size.Height * count);
                        ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                        ctrl.CheckedChanged += delegate
                                                   {
                                                       bool updateBox = textBoxNumber.Text == selectedVoks.ToString();

                                                       if (ctrl.Selected)
                                                       {
                                                           this.selectedVoks += ctrl.Kartei.Vokabeln.Count;
                                                       }
                                                       else
                                                       {
                                                           this.selectedVoks -= ctrl.Kartei.Vokabeln.Count;
                                                       }

                                                       if (updateBox)
                                                       {
                                                           textBoxNumber.Text = selectedVoks.ToString();
                                                       }
                                                   };
                        count++;
                    }

                    tabControlDefault.TabPages.Add(temp);
                    if (c == 0)
                    {
                        ActiveLecture(lecture);
                    }
                    c++;
                }
                initialized = true;
            }
        }

        public bool Preview
        {
            get { return checkBoxPreview.Checked; }
        }

        public bool Audio
        {
            get { return checkBoxPlayAudio.Checked; }
        }

        public bool Pictures
        {
            get { return checkBoxShowPictures.Checked; }
        }

        private void tabControlDefault_Selected(object sender, TabControlEventArgs e)
        {
            ActiveLecture((Lektion)e.TabPage.Tag);
        }

        private void checkBoxPreview_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxAskLang.Text))
            {
                MessageBox.Show("You cannot select this language.");
            }
            if (comboBoxAskLang.Text == comboBoxShowLang.Text)
            {
                MessageBox.Show("Please select two differing languages.");
            }
            else if (Vokabeln.Count() < 1)
            {
                MessageBox.Show("Please select at least one chapter.");
            }
            else if (Number < 1)
            {
                MessageBox.Show("Please input a correct count number.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public int Number
        {
            get { int result; if (Int32.TryParse(textBoxNumber.Text, out result)) return result; else return -1; }
        }

        public int ShowLanguage
        {
            get { return comboBoxShowLang.SelectedIndex; }
        }

        public int AskLanguage
        {
            get { return activeLecture.Sprachen.IndexOf(comboBoxAskLang.Text); }
        }

        public String AskLanguageString
        {
            get { return comboBoxAskLang.Text; }
        }

        public String ShowLanguageString
        {
            get { return comboBoxShowLang.Text; }
        }


        public IEnumerable<Vokabel> Vokabeln
        {
            get
            {
                var temp = activeLecture.Karteien.Where(kartei => kartei.Selected).Select(kartei => kartei.Vokabeln);
                List<Vokabel> liste = new List<Vokabel>();
                foreach (var ul in temp)
                {
                    liste.AddRange(ul);
                }
                return liste;
            }
        }

        private void comboBoxShowLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            setAskLangs();
        }

        private void setAskLangs()
        {
            int index = activeLecture.Sprachen.IndexOf(comboBoxShowLang.Text);
            Dictionary<int, String> t = new List<string>(activeLecture.Sprachen).ToDictionary(v => activeLecture.Sprachen.IndexOf(v), z => z);
            if (activeLecture.NichtAkzeptierteSprachen.Count > index)
                foreach (int i in activeLecture.NichtAkzeptierteSprachen[index])
                {
                    t.Remove(i);
                }
            t.Remove(index);
            comboBoxAskLang.DataSource = t.Values.ToList();
            comboBoxAskLang.SelectedIndex = comboBoxAskLang.Items.Count - 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    public partial class VokabelForm : Form
    {
        public VokabelForm(IEnumerable<Vokabel> vokabelListe, int count, String askLang, String showLang, int askLangIndex, int showLangIndex, 
            bool audioPlay, bool pictures, bool previewMode)
        {
            InitializeComponent();
            this.vokabelListe = new Dictionary<Vokabel, int>();
            foreach (var s in vokabelListe)
            {
                this.vokabelListe.Add(s, 0);
            }
            this.count = count;

            labelAskLang.Text = askLang;
            labelShowLang.Text = showLang;
            this.askLang = askLangIndex;
            this.showLang = showLangIndex;
            this.audioPlay = audioPlay;
            this.pictures = pictures;
            this.previewMode = previewMode;
        }

        private int count;
        private int askLang;
        private int showLang;
        private bool audioPlay, pictures, previewMode;
        private int doneCount=0, correctCount=0;

        private Vokabel aktiv;

        private void VokabelForm_Load(object sender, EventArgs e)
        {
            next();

            textBoxAnswer.Focus();
            textBoxAnswer.Select();
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            Correct();
        }

        /// <summary>
        /// Corrects this instance.
        /// </summary>
        private void Correct()
        {
            if (doneCount == count)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            if (!previewMode)
            {
                doneCount++;
                bool correct = false;
                this.Size = new Size(Size.Width, 344);
                labelAsked.Text = textBoxShow.Text;
                if (!string.IsNullOrEmpty(aktiv.Bemerkung))
                {
                    label3.Visible = true;
                    labelNote.Visible = true;
                    labelNote.Text = aktiv.Bemerkung;
                }
                else
                {
                    label3.Visible = false;
                    labelNote.Visible = false;
                }
                foreach (TeilVokabel a in aktiv.Sprachen[askLang])
                {
                    string answer = a.Schreibweise.ToLowerInvariant();
                    string compare = textBoxAnswer.Text.ToLowerInvariant();
                    if (answer.Contains("["))
                    {
                        string[] parts = answer.Split(new[] {'[', ']'});
                        if (parts[1] == compare)
                        {
                            correctCount++;
                        correct = true;
                        break;
                        }
                    }
                    else if (answer.Contains("..."))
                    {
                        string[] answers = answer.Split("...".ToCharArray());
                        bool partcorrect = true;
                        foreach(string part in answers)
                        {
                            if (compare.IndexOf(part) < 0)
                            {
                                partcorrect = false;
                                break;
                            }
                        }
                        if (partcorrect)
                        {
                            correctCount++;
                            correct = true;
                            break;
                        }
                    }
                    else if (answer == compare)
                    {
                        correctCount++;
                        correct = true;
                        break;
                    }
                }

                labelCount.Text = "(" + correctCount.ToString() + "/" + doneCount.ToString() + ")";

                if (correct)
                {
                    labelCorrect.Text = "✓ Correct!";
                    labelCorrect.ForeColor = Color.FromKnownColor(KnownColor.SkyBlue);
                    labelAnswer.Text = aktiv.Sprachen[askLang][0].Schreibweise;
                    vokabelListe[aktiv] += 3;
                }
                else
                {
                    labelCorrect.Text = "✘ Wrong!";
                    labelCorrect.ForeColor = Color.FromKnownColor(KnownColor.OrangeRed);
                    labelAnswer.Text = aktiv.Sprachen[askLang][0].Schreibweise + " (you: " + textBoxAnswer.Text + ")";
                    vokabelListe[aktiv] += 1;
                }
                if (aktiv.Sprachen[askLang].Count() > 1)
                {
                    labelAlt1.Text = aktiv.Sprachen[askLang][1].Schreibweise;
                    labelAlt1.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    labelAlt1.Visible = false;
                    labelAlt2.Visible = false;
                    labelAlt3.Visible = false;
                    label4.Visible = false;
                }
                if (aktiv.Sprachen[askLang].Count() > 2)
                {
                    labelAlt2.Text = aktiv.Sprachen[askLang][2].Schreibweise;
                    labelAlt2.Visible = true;
                }
                else
                {
                    labelAlt2.Visible = false;
                    labelAlt3.Visible = false;
                }
                if (aktiv.Sprachen[askLang].Count() > 3)
                {
                    labelAlt3.Text = aktiv.Sprachen[askLang][3].Schreibweise;
                    labelAlt3.Visible = true;
                }
                else
                {
                    labelAlt3.Visible = false;
                }
            }
            if (doneCount == count)
            {
                textBoxAnswer.ReadOnly = true;
                buttonContinue.Text = "Finish";
            }
            else
            {
                next();
            }
        }

        private Dictionary<Vokabel, int> vokabelListe;

        private void next()
        {
            aktiv = GetPseudoRandom();
            var teile = aktiv.Sprachen[showLang];
            string newtext = teile[0].Schreibweise;
            double rate = 0.93 - newtext.Length * 0.03;
            rate = rate < 0.4 ? 0.4 : rate;
            rate = rate > 1 ? 1 : rate;
            float fontsize = (float) rate * 26;
            textBoxShow.Font = new Font(FontFamily.GenericSansSerif, fontsize);
            textBoxShow.Text = newtext;

            if (!teile[0].Schreibweise.Contains("["))
            {
                textBoxAnswer.Size = new Size(233, 31);
                textBoxAnswer.Location = new Point(69, 130);
            }
            else
            {
                string[] parts = teile[0].Schreibweise.Split(new[] {'[', ']'});
                labelAnswerFront.Text = parts[0];
                textBoxAnswer.Location = new Point(labelAnswerFront.Location.X + 5 + labelAnswerFront.Size.Width, textBoxAnswer.Location.Y);
                textBoxAnswer.Size = new Size(100, 31);
                labelAnswerBack.Location = new Point(textBoxAnswer.Location.X + 5 + textBoxAnswer.Size.Width, labelAnswerBack.Location.Y);
                labelAnswerBack.Text = parts[2];
            }


            if (!string.IsNullOrEmpty(teile[0].AudioUri)
                                 && File.Exists(Path.Combine(Program.DataFolderPath,teile[0].AudioUri)))
            {
                buttonPlay.Visible = true;

                if (audioPlay)
                {
                    AudioHelper.Play(teile[0].AudioUri);
                }
            }

            if (pictures && File.Exists(Path.Combine(Program.DataFolderPath,teile[0].BildUri)))
            {
                pictureBox.Image = Image.FromFile(Path.Combine(Program.DataFolderPath,teile[0].BildUri));
                pictureBox.Visible = true;
                Size = new Size(539, Size.Height);
            }
            else
            {
                Size = new Size(386, Size.Height);
                pictureBox.Visible = false;
            }
            Random rand = new Random();

            if (previewMode)
            {
                var ateile = aktiv.Sprachen[askLang];
                textBoxAnswer.Text = ateile[rand.Next() % ateile.Count()].Schreibweise;
                textBoxAnswer.ReadOnly = true;
            }
            else
            {
                textBoxAnswer.Text = "";
            }

            textBoxAnswer.Select(0, 0);
            textBoxAnswer.Focus();
        }

        private Vokabel GetPseudoRandom()
        {
            int i = int.MaxValue;
            List<Vokabel> voks = new List<Vokabel>();
            foreach (KeyValuePair<Vokabel, int> kvp in vokabelListe)
            {
                if (kvp.Value < i)
                {
                    voks.Clear();
                    i = kvp.Value;
                }
                if (i == kvp.Value)
                {
                    voks.Add(kvp.Key);
                }
            }

            Random rand = new Random();
            int id = rand.Next() % voks.Count();

            if (vokabelListe.Count > 1 && voks.Count == 1 && voks.First() == aktiv)
            {
                vokabelListe[aktiv] += 1;
                return GetPseudoRandom();
            }
            else
            {
                return voks.ElementAt(id);
            }

        }

        private void textBoxAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                Correct();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            var teile = aktiv.Sprachen[showLang];
            AudioHelper.Play(teile[0].AudioUri);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}

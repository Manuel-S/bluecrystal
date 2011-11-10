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
    public partial class VokabelEditor : Form
    {
        public VokabelEditor(Lektion lektion, Kartei kartei)
        {
            InitializeComponent();
            this.kartei = kartei;
            int c = 0;
            editoren = new List<TeilVokabelEditor>();
            foreach (string sprache in lektion.Sprachen)
            {
                var t = new TeilVokabelEditor(sprache, c);
                Controls.Add(t);
                editoren.Add(t);
                t.Location = new Point(12 + c * (12 + t.Size.Width), 12);
                c++;
                Size = new Size(30 + c * (12 + t.Size.Width), Size.Height);
            }
        }

        private List<TeilVokabelEditor> editoren;

        private Kartei kartei;

        private Vokabel aktiv = null;

        private int currentPosition = -1;

        private void VokabelEditor_Load(object sender, EventArgs e)
        {
            moveForward();
        }

        private void moveForward()
        {
            if (currentPosition >= kartei.Vokabeln.Count)
            {
                return;
            }

            if (aktiv != null)
            {
                aktiv.Bemerkung = textBoxNote.Text;
            }

            currentPosition++;

            if (kartei.Vokabeln.Count <= currentPosition)
            {
                kartei.Vokabeln.Add(new Vokabel());
            }
            if (currentPosition == 0)
            {
                buttonPrevious.Enabled = false;
            }
            else
            {
                buttonPrevious.Enabled = true;
            }
            if (kartei.Vokabeln.Count <= currentPosition + 1)
            {
                buttonNext.Text = "New";
            }

            setVokabel(kartei.Vokabeln[currentPosition]);
            labelLocation.Text = (currentPosition + 1) + "/" + kartei.Vokabeln.Count;
        }

        private void moveBackwards()
        {
            if (currentPosition <= 0)
            {
                buttonPrevious.Enabled = false;
                return;
            }

            buttonNext.Text = ">";

            if (aktiv != null)
            {
                aktiv.Bemerkung = textBoxNote.Text;
            }

            currentPosition--;

            if (currentPosition <= 0)
            {
                buttonPrevious.Enabled = false;
            }

            setVokabel(kartei.Vokabeln[currentPosition]);
            labelLocation.Text = (currentPosition + 1) + "/" + kartei.Vokabeln.Count;
        }


        private void setVokabel(Vokabel v)
        {
            textBoxNote.Text = v.Bemerkung;
            foreach (var editor in editoren)
            {
                editor.Vokabel = v;
            }
            aktiv = v;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            moveForward();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            moveBackwards();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            currentPosition--;
            if (currentPosition >= 0)
            {
                currentPosition--;
            }
            kartei.Vokabeln.Remove(aktiv);
            foreach (var s in aktiv.Sprachen)
            {
                if (!string.IsNullOrEmpty(s[0].AudioUri) && File.Exists(Path.Combine(Program.DataFolderPath,s[0].AudioUri)))
                {
                    File.Delete(Path.Combine(Program.DataFolderPath,s[0].AudioUri));
                }
                if (!string.IsNullOrEmpty(s[0].BildUri) && File.Exists(Path.Combine(Program.DataFolderPath,s[0].BildUri)))
                {
                    File.Delete(Path.Combine(Program.DataFolderPath,s[0].BildUri));
                }
            }
            aktiv = null;
            moveForward();
        }

        private void VokabelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            aktiv.Bemerkung = textBoxNote.Text;
            foreach (TeilVokabelEditor editor in editoren)
            {
                editor.GetResults();
            }
        }
    }
}

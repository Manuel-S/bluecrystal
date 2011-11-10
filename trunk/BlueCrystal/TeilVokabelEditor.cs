using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    public partial class TeilVokabelEditor : UserControl
    {
        public TeilVokabelEditor(string sprache, int sprachIndex)
        {
            InitializeComponent();
            groupBoxLang.Text = sprache + ":";
            langKey = sprachIndex;
            sp = sprache;
        }

        private List<TeilVokabel> _voks = null;
        private string sp;
        private Vokabel _teilVokabel = null;
        private readonly int langKey;

        public Vokabel Vokabel
        {
            get
            {
                return _teilVokabel;
            } 
            set
            {
                GetResults();

                _teilVokabel = value;
                while (value.Sprachen.Count <= langKey)
                {
                    _teilVokabel.Sprachen.Add(new List<TeilVokabel> { new TeilVokabel() });
                }
                if (value.Sprachen[langKey].Count < 1)
                {
                    value.Sprachen[langKey].Add(new TeilVokabel());
                }
                _voks = value.Sprachen[langKey];


                DisplayVokabel();
            }
        }

        private void DisplayVokabel()
        {
            textBoxMain.Text = _voks[0].Schreibweise;

            if (_voks.Count > 1)
            {
                textBoxAlt1.Text = _voks[1].Schreibweise;
            }
            else
            {
                textBoxAlt1.Text = string.Empty;
            }
            if (_voks.Count > 2)
            {
                textBoxAlt2.Text = _voks[2].Schreibweise;
            }
            else
            {
                textBoxAlt2.Text = string.Empty;
            }
            if (_voks.Count > 3)
            {
                textBoxAlt3.Text = _voks[3].Schreibweise;
            }
            else
            {
                textBoxAlt3.Text = string.Empty;
            }
        }

        public void GetResults()
        {
            if(_teilVokabel != null)
            {
                _voks[0].Schreibweise = textBoxMain.Text;
                if (!string.IsNullOrEmpty(textBoxAlt1.Text))
                {
                    if (_voks.Count < 2)
                    {
                        _voks.Add(new TeilVokabel { Schreibweise = textBoxAlt1.Text });
                    }
                    else
                    {
                        _voks[1].Schreibweise = textBoxAlt1.Text;
                    }
                }
                if (!string.IsNullOrEmpty(textBoxAlt2.Text))
                {
                    if (_voks.Count < 3)
                    {
                        _voks.Add(new TeilVokabel { Schreibweise = textBoxAlt2.Text });
                    }
                    else
                    {
                        _voks[2].Schreibweise = textBoxAlt2.Text;
                    }
                }
                if (!string.IsNullOrEmpty(textBoxAlt3.Text))
                {
                    if (_voks.Count < 4)
                    {
                        _voks.Add(new TeilVokabel { Schreibweise = textBoxAlt3.Text });
                    }
                    else
                    {
                        _voks[3].Schreibweise = textBoxAlt3.Text;
                    }
                }
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            string asdf = _voks[0].AudioUri;
            if (!string.IsNullOrEmpty(asdf) && File.Exists(asdf))
            {
                AudioHelper.Play(asdf);
            }
        }

        private void buttonRecord_MouseDown(object sender, MouseEventArgs e)
        {
            string asdf = _voks[0].AudioUri;
            if (string.IsNullOrEmpty(asdf))
            {
                do
                {
                    asdf = Program.DataFolderPath + "\\Voice\\" + sp + "\\"
                        + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) 
                        + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".wav";
                } while (File.Exists(asdf));
                _voks[0].AudioUri = asdf;
                Directory.CreateDirectory(Path.GetDirectoryName(asdf));
            }

            AudioHelper.StartRecord(asdf);
        }

        private void buttonRecord_MouseUp(object sender, MouseEventArgs e)
        {
            AudioHelper.StopRecord();
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog
                                   {
                                       CheckFileExists = true, 
                                       Filter = "Image Files |*.jpg;*.jpeg;*.png;*.gif"};
            if(f.ShowDialog() == DialogResult.OK)
            {
                string file = f.FileName;
                string asdf = _voks[0].BildUri;
                Directory.CreateDirectory(Program.DataFolderPath + "\\Images\\" + sp);


                bool inDataDir = Directory.GetParent(file).FullName == new DirectoryInfo(Program.DataFolderPath + "\\Images\\" + sp).FullName;

                if (string.IsNullOrEmpty(asdf) && !inDataDir)
                {
                    asdf = Program.DataFolderPath + "\\Images\\" + sp + "\\" + Path.GetFileName(file);
                    while (File.Exists(Path.Combine(Program.DataFolderPath, asdf)))
                    {
                        asdf =  "\\Images\\" + sp + "\\"
                            + Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                            + Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                    }
                    _voks[0].BildUri = Path.Combine(Program.DataFolderPath, asdf);
                    File.Copy(file, Path.Combine(Program.DataFolderPath, asdf));
                }
                else if (inDataDir)
                {
                    _voks[0].BildUri = "\\Images\\" + sp + "\\" + Path.GetFileName(file);
                }
                else
                {
                    if (File.Exists(asdf))
                    {
                        File.Delete(asdf);
                    }
                    File.Copy(file, asdf);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetResults();
            AlternativesEditor f = new AlternativesEditor();
            f.Alternatives = _voks.Skip(1).Select(t => t.Schreibweise).ToList();
            if (f.ShowDialog() == DialogResult.OK)
            {
                var t = _voks[0];
                _voks.Clear();
                _voks.Add(t);
                _voks.AddRange(f.Alternatives.Select(c => new TeilVokabel { Schreibweise = c }));
                DisplayVokabel();
            }
        }
    }
}

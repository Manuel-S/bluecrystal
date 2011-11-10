using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    public partial class KarteiControl : UserControl
    {
        public KarteiControl(Kartei Kartei)
        {
            InitializeComponent();
            this.Kartei = Kartei;
        }

        public Kartei Kartei
        {
            get;
            private set;
        }

        public bool Selected
        {
            get
            {
                return checkBoxSelected.Checked;
            }
            set
            {
                checkBoxSelected.Checked = value;
            }
        }

        public delegate void KarteiCheckedHandler(object sender, EventArgs e);

        public event KarteiCheckedHandler CheckedChanged;

        private void checkBoxSelected_CheckedChanged(object sender, EventArgs e)
        {
            Kartei.Selected = checkBoxSelected.Checked;
            if (CheckedChanged != null)
            {
                CheckedChanged(this, new EventArgs());
            }
            if (checkBoxSelected.Text == "■")
            {
                checkBoxSelected.Text = "✓";
            }
            else
            {
                checkBoxSelected.Text = "■";
            }
        }

        private void KarteiControl_Load(object sender, EventArgs e)
        {
            labelVorschau.Text = Kartei.Vorschau;
            labelAnzahl.Text = "(" + Kartei.Vokabeln.Count() + ")";
        }
    }
}

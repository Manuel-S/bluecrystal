using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    public partial class DirectionEditForm : Form
    {
        public DirectionEditForm(Lektion lektion)
        {
            InitializeComponent();
            this.lektion = lektion;
            tempList = new List<List<int>>();
            int c = 0;
            foreach (string s in lektion.Sprachen)
            {
                c++;
                List<int> asdf;
                if (lektion.NichtAkzeptierteSprachen != null && lektion.NichtAkzeptierteSprachen.Count >= c)
                    asdf = lektion.NichtAkzeptierteSprachen[c - 1];
                else
                {
                    asdf = new List<int>();
                }

                tempList.Add(asdf);
            }
        }

        private Lektion lektion;

        private List<List<int>> tempList;

        public List<List<int>> Liste
        {
            get { return tempList; }
        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxAllow.Items.Clear();




            int id = lektion.Sprachen.IndexOf(comboBoxFrom.Text);

            int c = 0;
            foreach(string s in lektion.Sprachen)
            {
                checkedListBoxAllow.Items.Add(s, tempList[id].IndexOf(c) < 0);
                c++;
            }
        }

        private void DirectionEditForm_Load(object sender, EventArgs e)
        {
            comboBoxFrom.DataSource = lektion.Sprachen;
        }

        private void checkedListBoxAllow_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int id = lektion.Sprachen.IndexOf(comboBoxFrom.Text);
            if (e.NewValue == CheckState.Checked)
            {
                tempList[id].Remove(e.Index);
            }
            else
            {
                tempList[id].Add(e.Index);
                tempList[id] = tempList[id].Distinct().ToList();
            }
        }

        private void checkedListBoxAllow_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

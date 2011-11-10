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
    public partial class AlternativesEditor : Form
    {
        public AlternativesEditor()
        {
            InitializeComponent();
        }

        public List<string> Alternatives
        {
            get
            {
                List<string> liste = new List<string>
                                         {
                                             textBox1.Text,
                                             textBox2.Text,
                                             textBox3.Text,
                                             textBox4.Text,
                                             textBox5.Text,
                                             textBox6.Text,
                                             textBox7.Text,
                                             textBox8.Text,
                                             textBox9.Text,
                                             textBox10.Text
                                         };
                return liste.Distinct().Where(t => !string.IsNullOrEmpty(t)).ToList();
            }
            set
            {
                List<TextBox> controls = new List<TextBox>
                                             {
                                                 textBox1, 
                                                 textBox2, 
                                                 textBox3, 
                                                 textBox4, 
                                                 textBox5, 
                                                 textBox6, 
                                                 textBox7, 
                                                 textBox8, 
                                                 textBox9, 
                                                 textBox10
                                             };
                int c = 0;
                foreach (string a in value)
                {
                    controls[c].Text = a;
                    c++;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

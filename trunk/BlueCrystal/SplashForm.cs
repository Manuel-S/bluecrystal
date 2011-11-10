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
    public partial class SplashForm : Form
    {
        private bool Checkinout;
        private readonly Timer timer1;

        public SplashForm()
        {
            InitializeComponent();
            timer1 = new Timer {Interval = 10};
            timer1.Tick += timer1_Tick;

            Bitmap b = new Bitmap(this.BackgroundImage);
            b.MakeTransparent(b.GetPixel(1, 1));
            this.BackgroundImage = b; 
            KeyPreview = true;
            KeyDown += new KeyEventHandler(SplashForm_KeyDown);
            Initialized = true;
        }

        private void SplashForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public bool Initialized
        {
            get; private set;
        }

        public void setMessage(string message)
        {
            MethodInvoker method = delegate
            {
                labelStatus.Text = message;
            };

            if (InvokeRequired)
            {
                BeginInvoke(method);
            }
            else
            {
                method.Invoke();
            }
        }

        public new void Close()
        {
            MethodInvoker method = delegate
            {
                base.Close();
            };

            if (InvokeRequired)
            {
                BeginInvoke(method);
            }
            else
            {
                method.Invoke();
            }
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            if (!DesignMode)
            {

                Checkinout = true;

                Opacity = 0;

                timer1.Enabled = true;

            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Initialized = false;
            base.OnClosing(e);



            if (e.Cancel == true)

                return;



            if (Opacity > 0)
            {

                Checkinout = false;

                timer1.Enabled = true;

                e.Cancel = true;

            }

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

            if (Checkinout == false)
            {

                Opacity -= (timer1.Interval / 250.0);

                if (this.Opacity > 0)

                    timer1.Enabled = true;

                else
                {

                    timer1.Enabled = false;

                    Close();

                }

            }

            else
            {

                Opacity += (timer1.Interval / 500.0);

                timer1.Enabled = (Opacity < 1.0);

                Checkinout = (Opacity < 1.0);

            }

        }
    }
}

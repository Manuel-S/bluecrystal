namespace BlueCrystal
{
    partial class TeilVokabelEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxLang = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.textBoxAlt3 = new System.Windows.Forms.TextBox();
            this.textBoxAlt2 = new System.Windows.Forms.TextBox();
            this.textBoxAlt1 = new System.Windows.Forms.TextBox();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxLang.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLang
            // 
            this.groupBoxLang.Controls.Add(this.button1);
            this.groupBoxLang.Controls.Add(this.buttonImage);
            this.groupBoxLang.Controls.Add(this.buttonRecord);
            this.groupBoxLang.Controls.Add(this.buttonPlay);
            this.groupBoxLang.Controls.Add(this.textBoxAlt3);
            this.groupBoxLang.Controls.Add(this.textBoxAlt2);
            this.groupBoxLang.Controls.Add(this.textBoxAlt1);
            this.groupBoxLang.Controls.Add(this.textBoxMain);
            this.groupBoxLang.Controls.Add(this.label2);
            this.groupBoxLang.Controls.Add(this.label1);
            this.groupBoxLang.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLang.Name = "groupBoxLang";
            this.groupBoxLang.Size = new System.Drawing.Size(200, 187);
            this.groupBoxLang.TabIndex = 0;
            this.groupBoxLang.TabStop = false;
            this.groupBoxLang.Text = "Language:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(163, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "☃";
            this.toolTip.SetToolTip(this.button1, "Edit more Alternatives");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(163, 121);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(31, 23);
            this.buttonImage.TabIndex = 1;
            this.buttonImage.Text = "☀";
            this.toolTip.SetToolTip(this.buttonImage, "Add/Replace a Picture for this Word");
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.ForeColor = System.Drawing.Color.Red;
            this.buttonRecord.Location = new System.Drawing.Point(163, 40);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(31, 23);
            this.buttonRecord.TabIndex = 1;
            this.buttonRecord.Text = "☗";
            this.toolTip.SetToolTip(this.buttonRecord, "Record Audio using your Microphone");
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonRecord_MouseDown);
            this.buttonRecord.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonRecord_MouseUp);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(163, 69);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(31, 23);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.Text = "\t♪";
            this.toolTip.SetToolTip(this.buttonPlay, "Playpack Audio for this Word");
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // textBoxAlt3
            // 
            this.textBoxAlt3.Location = new System.Drawing.Point(31, 147);
            this.textBoxAlt3.Name = "textBoxAlt3";
            this.textBoxAlt3.Size = new System.Drawing.Size(126, 20);
            this.textBoxAlt3.TabIndex = 13;
            // 
            // textBoxAlt2
            // 
            this.textBoxAlt2.Location = new System.Drawing.Point(31, 121);
            this.textBoxAlt2.Name = "textBoxAlt2";
            this.textBoxAlt2.Size = new System.Drawing.Size(126, 20);
            this.textBoxAlt2.TabIndex = 12;
            // 
            // textBoxAlt1
            // 
            this.textBoxAlt1.Location = new System.Drawing.Point(31, 95);
            this.textBoxAlt1.Name = "textBoxAlt1";
            this.textBoxAlt1.Size = new System.Drawing.Size(126, 20);
            this.textBoxAlt1.TabIndex = 11;
            // 
            // textBoxMain
            // 
            this.textBoxMain.Location = new System.Drawing.Point(31, 42);
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(126, 20);
            this.textBoxMain.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Alternatives:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Main Word:";
            // 
            // TeilVokabelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxLang);
            this.Name = "TeilVokabelEditor";
            this.Size = new System.Drawing.Size(203, 190);
            this.groupBoxLang.ResumeLayout(false);
            this.groupBoxLang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLang;
        private System.Windows.Forms.TextBox textBoxAlt3;
        private System.Windows.Forms.TextBox textBoxAlt2;
        private System.Windows.Forms.TextBox textBoxAlt1;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip;

    }
}

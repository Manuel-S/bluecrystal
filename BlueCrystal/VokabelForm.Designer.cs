namespace BlueCrystal
{
    partial class VokabelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VokabelForm));
            this.labelShowLang = new System.Windows.Forms.Label();
            this.textBoxShow = new System.Windows.Forms.TextBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.labelAskLang = new System.Windows.Forms.Label();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.labelCorrect = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.labelAsked = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAlt1 = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.labelAlt2 = new System.Windows.Forms.Label();
            this.labelAlt3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.labelAnswerFront = new System.Windows.Forms.Label();
            this.labelAnswerBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelShowLang
            // 
            this.labelShowLang.AutoSize = true;
            this.labelShowLang.Location = new System.Drawing.Point(66, 23);
            this.labelShowLang.Name = "labelShowLang";
            this.labelShowLang.Size = new System.Drawing.Size(94, 13);
            this.labelShowLang.TabIndex = 0;
            this.labelShowLang.Text = "Shown Language:";
            // 
            // textBoxShow
            // 
            this.textBoxShow.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBoxShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShow.Location = new System.Drawing.Point(69, 48);
            this.textBoxShow.Multiline = true;
            this.textBoxShow.Name = "textBoxShow";
            this.textBoxShow.ReadOnly = true;
            this.textBoxShow.Size = new System.Drawing.Size(233, 41);
            this.textBoxShow.TabIndex = 1;
            this.textBoxShow.Text = "test";
            this.textBoxShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAnswer.Location = new System.Drawing.Point(69, 130);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(233, 31);
            this.textBoxAnswer.TabIndex = 3;
            this.textBoxAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAnswer_KeyDown);
            this.textBoxAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAnswer_KeyPress);
            // 
            // labelAskLang
            // 
            this.labelAskLang.AutoSize = true;
            this.labelAskLang.Location = new System.Drawing.Point(66, 103);
            this.labelAskLang.Name = "labelAskLang";
            this.labelAskLang.Size = new System.Drawing.Size(91, 13);
            this.labelAskLang.TabIndex = 2;
            this.labelAskLang.Text = "Asked Language:";
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(227, 167);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(75, 23);
            this.buttonContinue.TabIndex = 4;
            this.buttonContinue.Text = "Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // labelCorrect
            // 
            this.labelCorrect.AutoSize = true;
            this.labelCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCorrect.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelCorrect.Location = new System.Drawing.Point(66, 195);
            this.labelCorrect.Name = "labelCorrect";
            this.labelCorrect.Size = new System.Drawing.Size(58, 18);
            this.labelCorrect.TabIndex = 5;
            this.labelCorrect.Text = "Correct";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Asked:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Answer:";
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Location = new System.Drawing.Point(66, 275);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(65, 13);
            this.labelAnswer.TabIndex = 8;
            this.labelAnswer.Text = "Antwort Hier";
            // 
            // labelAsked
            // 
            this.labelAsked.AutoSize = true;
            this.labelAsked.Location = new System.Drawing.Point(66, 237);
            this.labelAsked.Name = "labelAsked";
            this.labelAsked.Size = new System.Drawing.Size(56, 13);
            this.labelAsked.TabIndex = 9;
            this.labelAsked.Text = "Frage Hier";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Note:";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Alternatives:";
            this.label4.Visible = false;
            // 
            // labelAlt1
            // 
            this.labelAlt1.AutoSize = true;
            this.labelAlt1.Location = new System.Drawing.Point(181, 275);
            this.labelAlt1.Name = "labelAlt1";
            this.labelAlt1.Size = new System.Drawing.Size(77, 13);
            this.labelAlt1.TabIndex = 12;
            this.labelAlt1.Text = "Alternative hier";
            this.labelAlt1.Visible = false;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(181, 213);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(61, 13);
            this.labelNote.TabIndex = 13;
            this.labelNote.Text = "Bemerkung";
            this.labelNote.Visible = false;
            // 
            // labelAlt2
            // 
            this.labelAlt2.AutoSize = true;
            this.labelAlt2.Location = new System.Drawing.Point(181, 288);
            this.labelAlt2.Name = "labelAlt2";
            this.labelAlt2.Size = new System.Drawing.Size(77, 13);
            this.labelAlt2.TabIndex = 14;
            this.labelAlt2.Text = "Alternative hier";
            this.labelAlt2.Visible = false;
            // 
            // labelAlt3
            // 
            this.labelAlt3.AutoSize = true;
            this.labelAlt3.Location = new System.Drawing.Point(181, 302);
            this.labelAlt3.Name = "labelAlt3";
            this.labelAlt3.Size = new System.Drawing.Size(77, 13);
            this.labelAlt3.TabIndex = 15;
            this.labelAlt3.Text = "Alternative hier";
            this.labelAlt3.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(309, 167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(143, 200);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(32, 13);
            this.labelCount.TabIndex = 17;
            this.labelCount.Text = "(#/#)";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(32, 59);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(31, 30);
            this.buttonPlay.TabIndex = 18;
            this.buttonPlay.Text = "♪";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Visible = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(309, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(190, 149);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 19;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // labelAnswerFront
            // 
            this.labelAnswerFront.AutoSize = true;
            this.labelAnswerFront.Location = new System.Drawing.Point(66, 142);
            this.labelAnswerFront.Name = "labelAnswerFront";
            this.labelAnswerFront.Size = new System.Drawing.Size(35, 13);
            this.labelAnswerFront.TabIndex = 20;
            this.labelAnswerFront.Text = "label5";
            // 
            // labelAnswerBack
            // 
            this.labelAnswerBack.AutoSize = true;
            this.labelAnswerBack.Location = new System.Drawing.Point(213, 142);
            this.labelAnswerBack.Name = "labelAnswerBack";
            this.labelAnswerBack.Size = new System.Drawing.Size(35, 13);
            this.labelAnswerBack.TabIndex = 21;
            this.labelAnswerBack.Text = "label6";
            // 
            // VokabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(380, 199);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelAlt3);
            this.Controls.Add(this.labelAlt2);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.labelAlt1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAsked);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCorrect);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelAskLang);
            this.Controls.Add(this.textBoxShow);
            this.Controls.Add(this.labelShowLang);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelAnswerBack);
            this.Controls.Add(this.labelAnswerFront);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VokabelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Crystal";
            this.Load += new System.EventHandler(this.VokabelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShowLang;
        private System.Windows.Forms.TextBox textBoxShow;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label labelAskLang;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Label labelCorrect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Label labelAsked;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAlt1;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label labelAlt2;
        private System.Windows.Forms.Label labelAlt3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelAnswerFront;
        private System.Windows.Forms.Label labelAnswerBack;
    }
}
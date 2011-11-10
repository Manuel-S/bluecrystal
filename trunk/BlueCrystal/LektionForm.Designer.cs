namespace BlueCrystal
{
    partial class LektionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LektionForm));
            this.tabControlDefault = new System.Windows.Forms.TabControl();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxShowLang = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxShowPictures = new System.Windows.Forms.CheckBox();
            this.checkBoxPlayAudio = new System.Windows.Forms.CheckBox();
            this.checkBoxPreview = new System.Windows.Forms.CheckBox();
            this.comboBoxAskLang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlDefault
            // 
            this.tabControlDefault.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlDefault.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlDefault.ItemSize = new System.Drawing.Size(20, 120);
            this.tabControlDefault.Location = new System.Drawing.Point(12, 12);
            this.tabControlDefault.Multiline = true;
            this.tabControlDefault.Name = "tabControlDefault";
            this.tabControlDefault.SelectedIndex = 0;
            this.tabControlDefault.Size = new System.Drawing.Size(405, 270);
            this.tabControlDefault.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDefault.TabIndex = 0;
            this.tabControlDefault.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlDefault_Selected);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Location = new System.Drawing.Point(393, 288);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(474, 288);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Logout";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxShowLang
            // 
            this.comboBoxShowLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShowLang.FormattingEnabled = true;
            this.comboBoxShowLang.Location = new System.Drawing.Point(6, 50);
            this.comboBoxShowLang.Name = "comboBoxShowLang";
            this.comboBoxShowLang.Size = new System.Drawing.Size(114, 21);
            this.comboBoxShowLang.TabIndex = 3;
            this.comboBoxShowLang.SelectedIndexChanged += new System.EventHandler(this.comboBoxShowLang_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBoxShowPictures);
            this.groupBox1.Controls.Add(this.checkBoxPlayAudio);
            this.groupBox1.Controls.Add(this.checkBoxPreview);
            this.groupBox1.Controls.Add(this.comboBoxAskLang);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxShowLang);
            this.groupBox1.Location = new System.Drawing.Point(423, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(6, 173);
            this.textBoxNumber.MaxLength = 3;
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(52, 20);
            this.textBoxNumber.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Count:";
            // 
            // checkBoxShowPictures
            // 
            this.checkBoxShowPictures.AutoSize = true;
            this.checkBoxShowPictures.Checked = true;
            this.checkBoxShowPictures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowPictures.Location = new System.Drawing.Point(6, 220);
            this.checkBoxShowPictures.Name = "checkBoxShowPictures";
            this.checkBoxShowPictures.Size = new System.Drawing.Size(94, 17);
            this.checkBoxShowPictures.TabIndex = 9;
            this.checkBoxShowPictures.Text = "Show Pictures";
            this.checkBoxShowPictures.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlayAudio
            // 
            this.checkBoxPlayAudio.AutoSize = true;
            this.checkBoxPlayAudio.Checked = true;
            this.checkBoxPlayAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlayAudio.Location = new System.Drawing.Point(6, 243);
            this.checkBoxPlayAudio.Name = "checkBoxPlayAudio";
            this.checkBoxPlayAudio.Size = new System.Drawing.Size(76, 17);
            this.checkBoxPlayAudio.TabIndex = 8;
            this.checkBoxPlayAudio.Text = "Play Audio";
            this.checkBoxPlayAudio.UseVisualStyleBackColor = true;
            // 
            // checkBoxPreview
            // 
            this.checkBoxPreview.AutoSize = true;
            this.checkBoxPreview.Location = new System.Drawing.Point(6, 127);
            this.checkBoxPreview.Name = "checkBoxPreview";
            this.checkBoxPreview.Size = new System.Drawing.Size(90, 17);
            this.checkBoxPreview.TabIndex = 7;
            this.checkBoxPreview.Text = "view answers";
            this.checkBoxPreview.UseVisualStyleBackColor = true;
            this.checkBoxPreview.CheckedChanged += new System.EventHandler(this.checkBoxPreview_CheckedChanged);
            // 
            // comboBoxAskLang
            // 
            this.comboBoxAskLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAskLang.FormattingEnabled = true;
            this.comboBoxAskLang.Location = new System.Drawing.Point(6, 100);
            this.comboBoxAskLang.Name = "comboBoxAskLang";
            this.comboBoxAskLang.Size = new System.Drawing.Size(114, 21);
            this.comboBoxAskLang.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ask:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show:";
            // 
            // LektionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(565, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.tabControlDefault);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(691, 521);
            this.MinimumSize = new System.Drawing.Size(581, 361);
            this.Name = "LektionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Crystal Lesson Selection";
            this.Load += new System.EventHandler(this.LektionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlDefault;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxShowLang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxPreview;
        private System.Windows.Forms.ComboBox comboBoxAskLang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxShowPictures;
        private System.Windows.Forms.CheckBox checkBoxPlayAudio;

    }
}
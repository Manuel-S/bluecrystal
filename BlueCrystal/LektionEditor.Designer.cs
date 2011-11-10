namespace BlueCrystal
{
    partial class LektionEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLangs = new System.Windows.Forms.TextBox();
            this.comboBoxLektion = new System.Windows.Forms.ComboBox();
            this.comboBoxKartei = new System.Windows.Forms.ComboBox();
            this.buttonNewLektion = new System.Windows.Forms.Button();
            this.buttonNewKartei = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDeleteLektion = new System.Windows.Forms.Button();
            this.buttonDeleteKartei = new System.Windows.Forms.Button();
            this.buttonDirections = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMoveUp = new System.Windows.Forms.Label();
            this.labelMoveDown = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lesson:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Languages: (comma seperated, min. 2)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chapter:";
            // 
            // textBoxLangs
            // 
            this.textBoxLangs.Location = new System.Drawing.Point(27, 99);
            this.textBoxLangs.Name = "textBoxLangs";
            this.textBoxLangs.Size = new System.Drawing.Size(178, 20);
            this.textBoxLangs.TabIndex = 3;
            this.textBoxLangs.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBoxLektion
            // 
            this.comboBoxLektion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLektion.FormattingEnabled = true;
            this.comboBoxLektion.Location = new System.Drawing.Point(27, 44);
            this.comboBoxLektion.Name = "comboBoxLektion";
            this.comboBoxLektion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLektion.TabIndex = 4;
            this.comboBoxLektion.SelectedIndexChanged += new System.EventHandler(this.comboBoxLektion_SelectedIndexChanged);
            // 
            // comboBoxKartei
            // 
            this.comboBoxKartei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKartei.FormattingEnabled = true;
            this.comboBoxKartei.Location = new System.Drawing.Point(27, 156);
            this.comboBoxKartei.Name = "comboBoxKartei";
            this.comboBoxKartei.Size = new System.Drawing.Size(121, 21);
            this.comboBoxKartei.TabIndex = 5;
            // 
            // buttonNewLektion
            // 
            this.buttonNewLektion.Location = new System.Drawing.Point(154, 42);
            this.buttonNewLektion.Name = "buttonNewLektion";
            this.buttonNewLektion.Size = new System.Drawing.Size(75, 23);
            this.buttonNewLektion.TabIndex = 6;
            this.buttonNewLektion.Text = "New";
            this.buttonNewLektion.UseVisualStyleBackColor = true;
            this.buttonNewLektion.Click += new System.EventHandler(this.buttonNewLektion_Click);
            // 
            // buttonNewKartei
            // 
            this.buttonNewKartei.Location = new System.Drawing.Point(154, 154);
            this.buttonNewKartei.Name = "buttonNewKartei";
            this.buttonNewKartei.Size = new System.Drawing.Size(75, 23);
            this.buttonNewKartei.TabIndex = 7;
            this.buttonNewKartei.Text = "New";
            this.buttonNewKartei.UseVisualStyleBackColor = true;
            this.buttonNewKartei.Click += new System.EventHandler(this.buttonNewKartei_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(49, 215);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 8;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(130, 215);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(211, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Back";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteLektion
            // 
            this.buttonDeleteLektion.Location = new System.Drawing.Point(235, 42);
            this.buttonDeleteLektion.Name = "buttonDeleteLektion";
            this.buttonDeleteLektion.Size = new System.Drawing.Size(51, 23);
            this.buttonDeleteLektion.TabIndex = 11;
            this.buttonDeleteLektion.Text = "Delete";
            this.buttonDeleteLektion.UseVisualStyleBackColor = true;
            this.buttonDeleteLektion.Click += new System.EventHandler(this.buttonDeleteLektion_Click);
            // 
            // buttonDeleteKartei
            // 
            this.buttonDeleteKartei.Location = new System.Drawing.Point(235, 154);
            this.buttonDeleteKartei.Name = "buttonDeleteKartei";
            this.buttonDeleteKartei.Size = new System.Drawing.Size(51, 23);
            this.buttonDeleteKartei.TabIndex = 12;
            this.buttonDeleteKartei.Text = "Delete";
            this.buttonDeleteKartei.UseVisualStyleBackColor = true;
            this.buttonDeleteKartei.Click += new System.EventHandler(this.buttonDeleteKartei_Click);
            // 
            // buttonDirections
            // 
            this.buttonDirections.Location = new System.Drawing.Point(211, 97);
            this.buttonDirections.Name = "buttonDirections";
            this.buttonDirections.Size = new System.Drawing.Size(63, 23);
            this.buttonDirections.TabIndex = 13;
            this.buttonDirections.Text = "Directions";
            this.buttonDirections.UseVisualStyleBackColor = true;
            this.buttonDirections.Click += new System.EventHandler(this.buttonDirections_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(211, 12);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 14;
            this.buttonUpload.Text = "⌂ Upload ⌂";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonRevert
            // 
            this.buttonRevert.Location = new System.Drawing.Point(130, 12);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.buttonRevert.TabIndex = 15;
            this.buttonRevert.Text = "☠Undo☠";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(11, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 31);
            this.panel1.TabIndex = 16;
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // labelMoveUp
            // 
            this.labelMoveUp.AutoSize = true;
            this.labelMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMoveUp.Location = new System.Drawing.Point(135, 140);
            this.labelMoveUp.Name = "labelMoveUp";
            this.labelMoveUp.Size = new System.Drawing.Size(13, 13);
            this.labelMoveUp.TabIndex = 17;
            this.labelMoveUp.Text = "^";
            this.labelMoveUp.Click += new System.EventHandler(this.labelMoveUp_Click);
            // 
            // labelMoveDown
            // 
            this.labelMoveDown.AutoSize = true;
            this.labelMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMoveDown.Location = new System.Drawing.Point(135, 180);
            this.labelMoveDown.Name = "labelMoveDown";
            this.labelMoveDown.Size = new System.Drawing.Size(13, 13);
            this.labelMoveDown.TabIndex = 18;
            this.labelMoveDown.Text = "v";
            this.labelMoveDown.Click += new System.EventHandler(this.labelMoveDown_Click);
            // 
            // LektionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(298, 250);
            this.Controls.Add(this.labelMoveDown);
            this.Controls.Add(this.labelMoveUp);
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonDirections);
            this.Controls.Add(this.buttonDeleteKartei);
            this.Controls.Add(this.buttonDeleteLektion);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonNewKartei);
            this.Controls.Add(this.buttonNewLektion);
            this.Controls.Add(this.comboBoxKartei);
            this.Controls.Add(this.comboBoxLektion);
            this.Controls.Add(this.textBoxLangs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "LektionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.LektionEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLangs;
        private System.Windows.Forms.ComboBox comboBoxLektion;
        private System.Windows.Forms.ComboBox comboBoxKartei;
        private System.Windows.Forms.Button buttonNewLektion;
        private System.Windows.Forms.Button buttonNewKartei;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDeleteLektion;
        private System.Windows.Forms.Button buttonDeleteKartei;
        private System.Windows.Forms.Button buttonDirections;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonRevert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMoveUp;
        private System.Windows.Forms.Label labelMoveDown;
    }
}
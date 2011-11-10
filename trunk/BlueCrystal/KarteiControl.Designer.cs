namespace BlueCrystal
{
    partial class KarteiControl
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
            this.checkBoxSelected = new System.Windows.Forms.CheckBox();
            this.labelAnzahl = new System.Windows.Forms.Label();
            this.labelVorschau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxSelected
            // 
            this.checkBoxSelected.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSelected.AutoSize = true;
            this.checkBoxSelected.Location = new System.Drawing.Point(3, 3);
            this.checkBoxSelected.Name = "checkBoxSelected";
            this.checkBoxSelected.Size = new System.Drawing.Size(29, 23);
            this.checkBoxSelected.TabIndex = 3;
            this.checkBoxSelected.Text = "■";
            this.checkBoxSelected.UseVisualStyleBackColor = true;
            this.checkBoxSelected.CheckedChanged += new System.EventHandler(this.checkBoxSelected_CheckedChanged);
            // 
            // labelAnzahl
            // 
            this.labelAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAnzahl.AutoSize = true;
            this.labelAnzahl.Location = new System.Drawing.Point(336, 8);
            this.labelAnzahl.Name = "labelAnzahl";
            this.labelAnzahl.Size = new System.Drawing.Size(20, 13);
            this.labelAnzahl.TabIndex = 5;
            this.labelAnzahl.Text = "(#)";
            // 
            // labelVorschau
            // 
            this.labelVorschau.AutoSize = true;
            this.labelVorschau.Location = new System.Drawing.Point(38, 8);
            this.labelVorschau.Name = "labelVorschau";
            this.labelVorschau.Size = new System.Drawing.Size(52, 13);
            this.labelVorschau.TabIndex = 4;
            this.labelVorschau.Text = "Vorschau";
            // 
            // KarteiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.checkBoxSelected);
            this.Controls.Add(this.labelAnzahl);
            this.Controls.Add(this.labelVorschau);
            this.MaximumSize = new System.Drawing.Size(372, 32);
            this.MinimumSize = new System.Drawing.Size(261, 32);
            this.Name = "KarteiControl";
            this.Size = new System.Drawing.Size(372, 32);
            this.Load += new System.EventHandler(this.KarteiControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxSelected;
        private System.Windows.Forms.Label labelAnzahl;
        private System.Windows.Forms.Label labelVorschau;
    }
}

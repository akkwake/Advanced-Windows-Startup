namespace Advanced_Windows_Startup
{
    partial class StartupItemDialog
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
            this.labelDelay = new System.Windows.Forms.Label();
            this.numericUpDownDelay = new System.Windows.Forms.NumericUpDown();
            this.buttonDisable = new System.Windows.Forms.Button();
            this.buttonEnable = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxHidden = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(13, 9);
            this.labelDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(111, 18);
            this.labelDelay.TabIndex = 1;
            this.labelDelay.Text = "Delay (Seconds):";
            // 
            // numericUpDownDelay
            // 
            this.numericUpDownDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDelay.Font = new System.Drawing.Font("Calibri", 12.25F);
            this.numericUpDownDelay.Location = new System.Drawing.Point(12, 30);
            this.numericUpDownDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownDelay.Name = "numericUpDownDelay";
            this.numericUpDownDelay.Size = new System.Drawing.Size(289, 27);
            this.numericUpDownDelay.TabIndex = 3;
            this.numericUpDownDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonDisable
            // 
            this.buttonDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDisable.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonDisable.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonDisable.Location = new System.Drawing.Point(12, 85);
            this.buttonDisable.Name = "buttonDisable";
            this.buttonDisable.Size = new System.Drawing.Size(75, 33);
            this.buttonDisable.TabIndex = 4;
            this.buttonDisable.Text = "Disabled";
            this.buttonDisable.UseVisualStyleBackColor = true;
            // 
            // buttonEnable
            // 
            this.buttonEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnable.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonEnable.ForeColor = System.Drawing.Color.DarkGreen;
            this.buttonEnable.Location = new System.Drawing.Point(226, 84);
            this.buttonEnable.Name = "buttonEnable";
            this.buttonEnable.Size = new System.Drawing.Size(75, 33);
            this.buttonEnable.TabIndex = 5;
            this.buttonEnable.Text = "Enabled";
            this.buttonEnable.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(291, 9);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(10, 10);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxHidden
            // 
            this.checkBoxHidden.AutoSize = true;
            this.checkBoxHidden.Location = new System.Drawing.Point(12, 61);
            this.checkBoxHidden.Name = "checkBoxHidden";
            this.checkBoxHidden.Size = new System.Drawing.Size(148, 22);
            this.checkBoxHidden.TabIndex = 7;
            this.checkBoxHidden.Text = "Hide from Launcher";
            this.checkBoxHidden.UseVisualStyleBackColor = true;
            this.checkBoxHidden.CheckedChanged += new System.EventHandler(this.checkBoxHidden_CheckedChanged);
            // 
            // StartupItemDialog
            // 
            this.AcceptButton = this.buttonEnable;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(313, 129);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEnable);
            this.Controls.Add(this.buttonDisable);
            this.Controls.Add(this.numericUpDownDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.checkBoxHidden);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartupItemDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StartupItemDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartupItemDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.NumericUpDown numericUpDownDelay;
        private System.Windows.Forms.Button buttonDisable;
        private System.Windows.Forms.Button buttonEnable;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxHidden;
    }
}
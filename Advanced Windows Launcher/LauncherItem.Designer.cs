namespace Advanced_Windows_Launcher
{
    partial class LauncherItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.checkBoxPaused = new System.Windows.Forms.CheckBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBar = new Advanced_Windows_Launcher.SimpleProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 27);
            this.panel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.Location = new System.Drawing.Point(30, 1);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(236, 19);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStart.Location = new System.Drawing.Point(274, 0);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(50, 29);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // checkBoxPaused
            // 
            this.checkBoxPaused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPaused.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPaused.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic);
            this.checkBoxPaused.Location = new System.Drawing.Point(274, 27);
            this.checkBoxPaused.Name = "checkBoxPaused";
            this.checkBoxPaused.Size = new System.Drawing.Size(50, 21);
            this.checkBoxPaused.TabIndex = 9;
            this.checkBoxPaused.Text = "Skip";
            this.checkBoxPaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPaused.UseVisualStyleBackColor = true;
            this.checkBoxPaused.CheckedChanged += new System.EventHandler(this.checkBoxPaused_CheckedChanged);
            // 
            // labelDelay
            // 
            this.labelDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDelay.BackColor = System.Drawing.SystemColors.Control;
            this.labelDelay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelDelay.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDelay.Location = new System.Drawing.Point(247, 28);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(27, 20);
            this.labelDelay.TabIndex = 10;
            this.labelDelay.Text = "0";
            this.labelDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStatus
            // 
            this.labelStatus.BackColor = System.Drawing.SystemColors.Control;
            this.labelStatus.Location = new System.Drawing.Point(36, 30);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(182, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "STATUS";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelStatus.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar.Location = new System.Drawing.Point(1, 28);
            this.progressBar.Maximum = 1000;
            this.progressBar.Minimum = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressBarColor = System.Drawing.Color.RosyBrown;
            this.progressBar.Size = new System.Drawing.Size(246, 20);
            this.progressBar.TabIndex = 11;
            this.progressBar.Value = 0;
            // 
            // LauncherItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxPaused);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panel1);
            this.Name = "LauncherItem";
            this.Size = new System.Drawing.Size(324, 48);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonStart;
        public System.Windows.Forms.CheckBox checkBoxPaused;
        private System.Windows.Forms.Label labelDelay;
        private SimpleProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
    }
}

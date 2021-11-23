namespace Advanced_Windows_Launcher
{
    partial class LauncherForm
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelTimeElapsed = new System.Windows.Forms.Label();
            this.timerFadeOut = new System.Windows.Forms.Timer(this.components);
            this.buttonStartManager = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(329, 7);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.WrapContents = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 12);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(353, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripLabelStatusInfo
            // 
            this.toolStripLabelStatusInfo.Name = "toolStripLabelStatusInfo";
            this.toolStripLabelStatusInfo.Size = new System.Drawing.Size(28, 17);
            this.toolStripLabelStatusInfo.Text = "Info";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(19, 19);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 30;
            this.timerUpdate.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelTimeElapsed
            // 
            this.labelTimeElapsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeElapsed.BackColor = System.Drawing.SystemColors.Control;
            this.labelTimeElapsed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTimeElapsed.Location = new System.Drawing.Point(292, 14);
            this.labelTimeElapsed.Name = "labelTimeElapsed";
            this.labelTimeElapsed.Size = new System.Drawing.Size(58, 18);
            this.labelTimeElapsed.TabIndex = 2;
            this.labelTimeElapsed.Text = "0";
            this.labelTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerFadeOut
            // 
            this.timerFadeOut.Interval = 10;
            this.timerFadeOut.Tick += new System.EventHandler(this.timerFadeOut_Tick);
            // 
            // buttonStartManager
            // 
            this.buttonStartManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartManager.BackColor = System.Drawing.SystemColors.Control;
            this.buttonStartManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartManager.ForeColor = System.Drawing.Color.Firebrick;
            this.buttonStartManager.Location = new System.Drawing.Point(12, 13);
            this.buttonStartManager.Name = "buttonStartManager";
            this.buttonStartManager.Size = new System.Drawing.Size(274, 20);
            this.buttonStartManager.TabIndex = 15;
            this.buttonStartManager.Text = "Unmanaged apps found. Click to fix.";
            this.buttonStartManager.UseVisualStyleBackColor = false;
            this.buttonStartManager.Visible = false;
            this.buttonStartManager.Click += new System.EventHandler(this.buttonStartManager_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 34);
            this.Controls.Add(this.buttonStartManager);
            this.Controls.Add(this.labelTimeElapsed);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.flowLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LauncherForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Startup Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LauncherForm_FormClosing);
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelStatusInfo;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label labelTimeElapsed;
        private System.Windows.Forms.Timer timerFadeOut;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonStartManager;
    }
}


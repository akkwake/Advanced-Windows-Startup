namespace Advanced_Windows_Startup
{
    partial class UnmanagedItemsResolutionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnmanagedItemsResolutionForm));
            this.buttonDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView = new Advanced_Windows_Startup.mListView();
            this.columnHeaderIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDelay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDone.Location = new System.Drawing.Point(13, 179);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(603, 32);
            this.buttonDone.TabIndex = 0;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Calibri", 10F);
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(603, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "The following applications were added to startup since the last time Advanced Win" +
    "dows Startup was ran:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.CheckBoxes = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIcon,
            this.columnHeaderName,
            this.columnHeaderPath,
            this.columnHeaderDelay});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(13, 40);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(603, 129);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIcon
            // 
            this.columnHeaderIcon.Text = "";
            this.columnHeaderIcon.Width = 45;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 124;
            // 
            // columnHeaderPath
            // 
            this.columnHeaderPath.Text = "Path";
            this.columnHeaderPath.Width = 380;
            // 
            // columnHeaderDelay
            // 
            this.columnHeaderDelay.Text = "Delay";
            this.columnHeaderDelay.Width = 50;
            // 
            // UnmanagedItemsResolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 227);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UnmanagedItemsResolutionForm";
            this.Text = "Resolve Unmanaged Applications";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnmanagedItemsResolutionForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public mListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderIcon;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderPath;
        private System.Windows.Forms.ColumnHeader columnHeaderDelay;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label label1;
    }
}
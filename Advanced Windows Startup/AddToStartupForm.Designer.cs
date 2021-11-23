namespace Advanced_Windows_Startup
{
    partial class AddToStartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddToStartupForm));
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            this.radioButtonCommon = new System.Windows.Forms.RadioButton();
            this.radioButtonUser = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.browseFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelPath = new System.Windows.Forms.Label();
            this.labelArgs = new System.Windows.Forms.Label();
            this.textBoxArgs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Items.AddRange(new object[] {
            "Launcher",
            "Folder",
            "Registry"});
            this.comboBoxLocation.Location = new System.Drawing.Point(12, 80);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(199, 27);
            this.comboBoxLocation.TabIndex = 0;
            this.comboBoxLocation.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocation_SelectedIndexChanged);
            // 
            // radioButtonCommon
            // 
            this.radioButtonCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonCommon.AutoSize = true;
            this.radioButtonCommon.Location = new System.Drawing.Point(217, 156);
            this.radioButtonCommon.Name = "radioButtonCommon";
            this.radioButtonCommon.Size = new System.Drawing.Size(66, 17);
            this.radioButtonCommon.TabIndex = 1;
            this.radioButtonCommon.Text = "All Users";
            this.radioButtonCommon.UseVisualStyleBackColor = true;
            // 
            // radioButtonUser
            // 
            this.radioButtonUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonUser.AutoSize = true;
            this.radioButtonUser.Checked = true;
            this.radioButtonUser.Location = new System.Drawing.Point(217, 179);
            this.radioButtonUser.Name = "radioButtonUser";
            this.radioButtonUser.Size = new System.Drawing.Size(70, 17);
            this.radioButtonUser.TabIndex = 2;
            this.radioButtonUser.TabStop = true;
            this.radioButtonUser.Text = "This User";
            this.radioButtonUser.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.labelInfo);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // labelInfo
            // 
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(3, 22);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(193, 61);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "Sets up the launcher to include the selected application. No shortcuts or registr" +
    "y entries are created.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPath.Location = new System.Drawing.Point(50, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxPath.Size = new System.Drawing.Size(451, 26);
            this.textBoxPath.TabIndex = 3;
            // 
            // browseFileDialog
            // 
            this.browseFileDialog.Filter = "Executable files |*.exe|All files|*.*";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(399, 43);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(102, 26);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "Browse File";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAccept.Enabled = false;
            this.buttonAccept.Location = new System.Drawing.Point(426, 176);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 4;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(345, 176);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 50;
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.InitialDelay = 50;
            this.toolTip.ReshowDelay = 10;
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPath.Location = new System.Drawing.Point(9, 17);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(35, 15);
            this.labelPath.TabIndex = 6;
            this.labelPath.Text = "Path:";
            // 
            // labelArgs
            // 
            this.labelArgs.AutoSize = true;
            this.labelArgs.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArgs.Location = new System.Drawing.Point(9, 48);
            this.labelArgs.Name = "labelArgs";
            this.labelArgs.Size = new System.Drawing.Size(68, 15);
            this.labelArgs.TabIndex = 7;
            this.labelArgs.Text = "Arguments:";
            // 
            // textBoxArgs
            // 
            this.textBoxArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArgs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxArgs.Location = new System.Drawing.Point(83, 43);
            this.textBoxArgs.Name = "textBoxArgs";
            this.textBoxArgs.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxArgs.Size = new System.Drawing.Size(310, 26);
            this.textBoxArgs.TabIndex = 8;
            // 
            // AddToStartupForm
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(513, 211);
            this.Controls.Add(this.textBoxArgs);
            this.Controls.Add(this.labelArgs);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.radioButtonUser);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.radioButtonCommon);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBoxLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddToStartupForm";
            this.Text = "Add to Startup";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLocation;
        private System.Windows.Forms.RadioButton radioButtonCommon;
        private System.Windows.Forms.RadioButton radioButtonUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.OpenFileDialog browseFileDialog;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelArgs;
        private System.Windows.Forms.TextBox textBoxArgs;
    }
}
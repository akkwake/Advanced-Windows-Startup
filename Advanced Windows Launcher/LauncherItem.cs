using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartupExplorer;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Advanced_Windows_Launcher
{
    public partial class LauncherItem : UserControl
    {
        public new string Name
        {
            get { return base.Name; }
            set
            {
                base.Name = value;
                labelName.Text = value;
            }
        }

        public readonly string pathInitial;

        public readonly string path;
        public readonly string args;
        public readonly float delay;
        public readonly bool hidden;

        readonly FileInfo file;

        bool launched = false;

        /// <summary>
        /// Used by unmanaged items.
        /// </summary>
        /// <param name="appData"></param>
        public LauncherItem(StartupApplicationData appData)
        {
            InitializeComponent();

            this.Name = appData.name;

            GetApplicationIcon(appData.executablePath);
            MarkAsInactive("UNMANAGED");
        }

        /// <summary>
        /// Used by items found in startup file.
        /// </summary>
        /// <param name="appData"></param>
        public LauncherItem(string[] appData)
        {
            InitializeComponent();

            bool fileError = false;
            
            this.Name = appData[0];
            this.pathInitial = appData[1];
            StartupApplicationData.SplitPathAndArguments(appData[1], out this.path, out this.args);
            this.file = new FileInfo(this.path);

            if (!file.Exists)
                MarkAsInactive("FILE NOT FOUND");
            else
            {
                GetApplicationIcon(this.path);
                
                //Delay
                if (!float.TryParse(appData[2], out this.delay))
                    LauncherForm.fileErrorFound = true;
                else
                    labelDelay.Text = this.delay.ToString();

                //Hide
                if (!bool.TryParse(appData[4], out this.hidden))
                    LauncherForm.fileErrorFound = true;
            }
        }

        
        /// <summary>
        /// Checks if it's time to start the process.
        /// </summary>
        /// <param name="timeElapsed"></param>
        /// <returns></returns>
        public bool Update(float timeElapsed)
        {
            if (launched)
                return true;

            if (checkBoxPaused.Checked)
                return false;

            int progressValue = (int)((timeElapsed / this.delay) * 1000);
            progressBar.Value = progressValue;

            if (LauncherForm.timeElapsed > this.delay)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Start the process corresponding to this item.
        /// </summary>
        public void StartProcess()
        {
            if (launched)
                return;

            launched = true;
            progressBar.Value = progressBar.Maximum;
            DisableUI();

            if (file.Exists)
            {
                ProcessStartInfo info = new ProcessStartInfo(this.path, this.args);
                Process process = new Process();
                process.StartInfo = info;
                process.Start();
            }
        }

        void MarkAsInactive(string statusText)
        {
            DisableUI();
            launched = true;
            labelStatus.Text = statusText;
            labelStatus.Visible = true;
            labelDelay.Text = "-";
        }

        void DisableUI()
        {
            checkBoxPaused.Enabled = false;
            buttonStart.Enabled = false;
        }

        void GetApplicationIcon(string path)
        {
            LauncherForm.imageListMain.Images.Add(Icon.ExtractAssociatedIcon(path));
            pictureBox1.Image = LauncherForm.imageListMain.Images[LauncherForm.imageListMain.Images.Count - 1];
        }


        private void checkBoxPaused_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPaused.Checked)
            {
                progressBar.ProgressBarColor = Color.Silver;
                LauncherForm.launcherItems.Remove(this);
            }
            else
            {
                progressBar.ProgressBarColor = Color.RosyBrown;
                LauncherForm.launcherItems.Add(this);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartProcess();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartupExplorer;


namespace Advanced_Windows_Launcher
{
    public partial class LauncherForm : Form
    {
        //Holds images for launcherItem
        public static ImageList imageListMain;
        
        //Entries enabled in registry
        public static List<StartupApplicationData> unmanagedItems;
        
        //Entries enabled in startup file
        public static List<string[]> managedItems;
        
        //Items queued
        public static List<LauncherItem> launcherItems = new List<LauncherItem>();
        
        public static float timeElapsed = 0f;

        public static bool fileErrorFound = false;

        float timeInterval;

        public LauncherForm()
        {
            InitializeComponent();

            //Add Minimum timeElapsed before fadeout
            imageListMain = imageList1;

            unmanagedItems = GetUnmanagedItems();
            managedItems = GetManagedItems();
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            //Create items for unmanaged apps
            foreach (StartupApplicationData app in unmanagedItems)
            {
                LauncherItem item = new LauncherItem(app);
                flowLayoutPanel.Controls.Add(item);
            }

            //Create items for managed apps
            //Exception thrown here if there is no user startup file
            foreach (string[] app in managedItems)
            {
                LauncherItem item = new LauncherItem(app);
                if (!item.hidden)
                    flowLayoutPanel.Controls.Add(item);
                launcherItems.Add(item);
            }

            SetStartupSizeAndPosition();

            //Show `Launch Manager` button
            if (unmanagedItems.Count > 0 )
                buttonStartManager.Visible = true;
            if (fileErrorFound)
            {
                buttonStartManager.Visible = true;
                buttonStartManager.Text = "File error found. Click to fix.";
            }

            //Configure timer
            timeInterval = timerUpdate.Interval / 1000f;
            timerUpdate.Start();
        }

        /// <summary>
        /// Returns a list of all entries in startup file.
        /// </summary>
        /// <returns></returns>
        List<string[]> GetManagedItems()
        {
            //Find startup file
            string s = Assembly.GetExecutingAssembly().Location;
            string username = Environment.UserName;
            string path = s.Substring(0, s.LastIndexOf('\\')) + '\\' + username + ".startup.dat";

            List<string[]> apps = new List<string[]>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] appData = line.Split(new string[] { "&&" }, StringSplitOptions.None);
                        
                        //If app is enabled in file
                        if (appData[3].Equals("True")) 
                        {
                            //Check if app is also enabled in registry
                            bool skip = unmanagedItems.Where(p => p.name.Equals(appData[0])).Any();
                           
                            if (skip)
                                continue;
                        
                            apps.Add(appData);
                        }
                    }
                }
            }
            return apps;
        }
        

        /// <summary>
        /// Returns a list with all applications enabled during startup.
        /// </summary>
        /// <returns></returns>
        List<StartupApplicationData> GetUnmanagedItems()
        {
            List<StartupApplicationData> appDataList = new List<StartupApplicationData>();

            Dictionary<StartupGroup, StartupApplicationData[]> enabledApps = Explorer.GetAllEnabled();

            foreach (KeyValuePair<StartupGroup, StartupApplicationData[]> apps in enabledApps)
            {
                foreach (StartupApplicationData app in enabledApps[apps.Key])
                    if (!app.name.Equals("Advanced Windows Startup")) //Ignore Launcher
                        appDataList.Add(app);
            }

            return appDataList;
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            timeElapsed += timeInterval;
            labelTimeElapsed.Text = timeElapsed.ToString("F1");

            //Update launcher items
            for (int i = launcherItems.Count - 1; i >= 0; i--)
            {
                if (launcherItems[i].Update(timeElapsed))
                {
                    LauncherItem item = launcherItems[i];
                    launcherItems.RemoveAt(i);
                    item.StartProcess();
                    i--;
                }
            }

            //Fadeout when all items are finished
            if (launcherItems.Count == 0)
            {
                timerUpdate.Stop();
                timerFadeOut.Start();
            }
        }

        private void timerFadeOut_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.005f;
            if (this.Opacity <= 0)
                this.Close();

            //This might happen if you skip an app, then re-enable it after fadeout started
            if (launcherItems.Count != 0)
                ResetFadeout();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (launcherItems.Count == 0)
                return;

            DialogResult result = MessageBox.Show("Startup hasn't finished yet. Are you sure you want to exit?", "Startup Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void buttonStartManager_Click(object sender, EventArgs e)
        {
            //Get manager executable path
            string launcherPath = Assembly.GetExecutingAssembly().Location;
            string path = launcherPath.Substring(0, launcherPath.LastIndexOf('\\') + 1) + "Advanced Windows Startup.exe";


            ProcessStartInfo info = new ProcessStartInfo(path);
            Process process = new Process();
            process.StartInfo = info;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.Verb = "runas";   //Run as admin
            process.Start();
        }

        void SetStartupSizeAndPosition()
        {
            StartPosition = FormStartPosition.Manual;
            Size s = this.Size; //new Size(370, 100);

            //Increase height for each launcher item
            if (flowLayoutPanel.Controls.Count > 0)
                s.Height += (flowLayoutPanel.Controls[0].Size.Height + 6) * flowLayoutPanel.Controls.Count - 3;
            Size = s;

            //Set form position
            Point _point = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Right - s.Width, Screen.PrimaryScreen.WorkingArea.Bottom - s.Height);
            Top = _point.Y;
            Left = _point.X;
        }

        void ResetFadeout()
        {
            timerFadeOut.Stop();
            this.Opacity = 1f;
            timerUpdate.Start();
        }
    }
}

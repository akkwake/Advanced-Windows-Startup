using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartupExplorer;
using System.Security.Principal;
using System.Diagnostics;

namespace Advanced_Windows_Startup
{
    public class StartupApplicationItem : ListViewItem
    {
        public StartupApplicationData applicationData;

        public new string Name
        {
            get { return SubItems[1].Text; }
        }

        public string Path
        {
            get { return SubItems[2].Text; }
        }

        public string Delay
        {
            get { return SubItems[3].Text; }
        }

        public bool isShortcut
        {
            get
            {
                if (applicationData == null)
                    return true;
                else
                    return applicationData.isShortcut;
            }
        }

        public readonly bool requiresAdminPrivileges;
        public bool hidden;


        /// <summary>
        /// Newly added startup entries use this constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <param name="delay"></param>
        /// <param name="isChecked"></param>
        public StartupApplicationItem(string name, string path, string delay, bool isChecked, bool requiresAdminPrivileges)
        {
            this.SubItems.Add(name);
            this.SubItems.Add(path);
            this.SubItems.Add(delay);
            Checked = isChecked;
            this.requiresAdminPrivileges = requiresAdminPrivileges;

            GetApplicationIcon();
        }

        /// <summary>
        /// Items loaded from file use this constructor (Launcher Only Items).
        /// </summary>
        /// <param name="userFileLine"></param>
        public StartupApplicationItem(string userFileLine)
        {
            string[] split = userFileLine.Split(new string[] { "&&" }, StringSplitOptions.None);
            this.SubItems.Add(split[0]);
            this.SubItems.Add(split[1]);
            this.SubItems.Add(split[2]);
            Checked = bool.Parse(split[3]);
            hidden = bool.Parse(split[4]);

            requiresAdminPrivileges = false;

            GetApplicationIcon();
        }

        /// <summary>
        /// Items found in StartupExplorer use this constructor.
        /// </summary>
        /// <param name="appData"></param>
        /// <param name="group"></param>
        public StartupApplicationItem(StartupApplicationData appData, ListViewGroup group)
        {
            applicationData = appData;

            this.SubItems.Add(appData.name);
            this.SubItems.Add(appData.rawPath);
            this.SubItems.Add(0.ToString());
            if (appData.state == AppStartupState.Disabled)
                Checked = false;
            else
                Checked = true;

            this.Group = group;

            requiresAdminPrivileges = appData.requiresAdminPrivileges;
            if (requiresAdminPrivileges && !Settings.IsAdministrator)
                ForeColor = Color.Gray;

            GetApplicationIcon();
        }

        public void RemoveEntry()
        {
            if (applicationData != null)
                applicationData.RemoveFromStartup();

            Remove();
        }
            

        void GetApplicationIcon()
        {
            //Get the icon
            Icon ico = null;
            if (isShortcut)
            {
                if (File.Exists(Path))
                    ico = Icon.ExtractAssociatedIcon(Path);
            }
            else
            {
                if (File.Exists(applicationData.executablePath))
                    ico = Icon.ExtractAssociatedIcon(applicationData.executablePath);
            }

            //If icon is found add to imageList
            if (ico != null)
            {
                ManagerForm.ImageList.Images.Add(ico);
                ImageIndex = ManagerForm.ImageList.Images.Count - 1;
            }
            else
            {
                //Set icon to default (question mark)
                ImageIndex = 0;
            }
        }
    }
}

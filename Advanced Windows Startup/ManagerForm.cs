using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Advanced_Windows_Startup.Properties;
using StartupExplorer;

namespace Advanced_Windows_Startup
{
    public partial class ManagerForm : Form
    {
        bool isLoading = true;
        
        // Application icons are stored here.
        public static ImageList ImageList;

        public ManagerForm()
        {
            InitializeComponent();

            ImageList = imageList;

            //Question mark icon if getting application icon fails
            imageList.Images.Add(Resources.question_mark_clear);
        }


        private void ManagerForm_Load(object sender, EventArgs e)
        {
            isLoading = true;
            checkBoxLauncherEnabled.Checked = Settings.LauncherEnabled;
            isLoading = false;
        }

        private void ManagerForm_Shown(object sender, EventArgs e)
        {
            if (!Settings.IsAdministrator)
              MessageBox.Show("This program requires administrator privileges for full functionality. Without privileges, you can only affect startup entries for this specific user.\n\nOptions you can't change will be greyed out.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //Get startup entries async
            Thread t = new Thread(new ThreadStart(this.PopulateListView));
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Gets all startup entries and creates ListViewItems for each.
        /// </summary>
        void PopulateListView()
        {
            isLoading = true;

            //Initialize list for unmanaged
            List<StartupApplicationItem> unmanagedApplications = new List<StartupApplicationItem>();

            //Load settings
            Settings.ParseFile();

            //Get all startup entries
            Dictionary<StartupGroup, StartupApplicationData[]> startupEntries = Explorer.GetAll();

            //Loop through them
            foreach (KeyValuePair<StartupGroup, StartupApplicationData[]> group in startupEntries)
            {
                //Continue if group is empty
                if (group.Value.Length == 0)
                    continue;

                //Create the group and add to listview
                ListViewGroup listViewGroup = new ListViewGroup(group.Value[0].groupPath);
                listView.Invoke(new Action(() =>
                {
                    listView.Groups.Add(listViewGroup);
                }));
                
                //Loop through apps in group
                foreach (StartupApplicationData app in group.Value)
                {
                    //Ignore this application
                    if (app.name.Equals(Settings.registryName))
                        continue;

                    StartupApplicationItem appItem = new StartupApplicationItem(app, listViewGroup);

                    //Check state of this item from the user's data file
                    bool isUnmanaged = Settings.CorrectItemFromFile(appItem);
                    if (isUnmanaged) 
                        unmanagedApplications.Add(appItem);
                    else
                        listView.Invoke(new Action(() =>
                        {
                            listView.Items.Add(appItem);
                        }));
                }

            }

            //Load Launcher only applications
            StartupApplicationItem[] launcherOnlyItems = Settings.CreateItemsFromFile();
            if (launcherOnlyItems.Length > 0)
            {
                ListViewGroup launcherGroup = new ListViewGroup("Launcher");
                listView.Invoke(new Action(() =>
                {
                    listView.Groups.Add(launcherGroup);
                }));

                foreach (StartupApplicationItem item in launcherOnlyItems)
                {
                    listView.Invoke(new Action(() =>
                    {
                        item.Group = launcherGroup;
                        listView.Items.Add(item);
                    }));
                }
            }

            //Resolve unmanaged applications
            if (unmanagedApplications.Count > 0)
            {
                UnmanagedItemsResolutionForm resolver = new UnmanagedItemsResolutionForm(unmanagedApplications, listView);
                resolver.StartPosition = FormStartPosition.CenterParent;
                resolver.ShowDialog();
            }
            
            if (Settings.LauncherEnabled)
            {
                DisableWindowsStartup();
            }

            isLoading = false;
        }


        void RefreshListview()
        {
            listView.Items.Clear();
            listView.Groups.Clear();

            //Get startup entries async
            Thread t = new Thread(new ThreadStart(this.PopulateListView));
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Disable regular windows startup, enable launcher.
        /// </summary>
        void DisableWindowsStartup()
        {
            listView.Invoke(new Action(() =>
            {
                foreach (StartupApplicationItem item in listView.Items)
                {
                    if (item.requiresAdminPrivileges && !Settings.IsAdministrator)
                        continue;

                    if (item.Checked && item.applicationData != null)
                        item.applicationData.SetKeyState(false);
                }
            }
            ));

            Settings.AddToStartup();
        }

        /// <summary>
        /// Disable launcher, enable regular startup.
        /// </summary>
        void EnableWindowsStartup()
        {
            foreach (StartupApplicationItem item in listView.Items)
            {
                if (item.requiresAdminPrivileges && !Settings.IsAdministrator)
                    continue;

                if (item.Checked && item.applicationData != null)
                    item.applicationData.SetKeyState(true);
            }

            Settings.RemoveFromStartup();
        }

        /// <summary>
        /// Makes sure context menu shows correctly.
        /// </summary>
        /// <param name="item"></param>
        void SetContextMenuState(StartupApplicationItem item)
        {
            if (item.requiresAdminPrivileges && !Settings.IsAdministrator)
            {
                enableToolStripMenuItem.Enabled = false;
                disableToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                if (item.Checked)
                {
                    enableToolStripMenuItem.Enabled = false;
                    disableToolStripMenuItem.Enabled = true;
                    deleteToolStripMenuItem.Enabled = true;
                }
                else
                {
                    enableToolStripMenuItem.Enabled = true;
                    disableToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = true;
                }
            }
        }


        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isLoading)
                return;

            StartupApplicationItem item = (StartupApplicationItem)listView.Items[e.Index];

            //Don't allow changing checked flag if you don't have permission
            if (item.requiresAdminPrivileges && !Settings.IsAdministrator)
            {
                e.NewValue = e.CurrentValue;
                return;
            }

            SetContextMenuState(item);

            //If launcher is disabled, change registry entry to reflect this item's checked state
            if (!checkBoxLauncherEnabled.Checked)
            {
                if (item.applicationData != null)
                    item.applicationData.SetKeyState(!item.Checked);
            }
        }

        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isLoading)
                return;

            Settings.SaveStartupList(listView);
        }

        private void checkBoxLauncherEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLauncherEnabled.Checked)
            {
                //UI Stuff
                checkBoxLauncherEnabled.Text = "Enabled";
                checkBoxLauncherEnabled.ForeColor = Color.ForestGreen;
                statusStrip.BackColor = Color.ForestGreen;
                toolStripStatusLabel.Text = "Launcher will handle startup.";

                //Save
                if (!isLoading)
                {
                    DisableWindowsStartup();
                    Settings.SaveStartupList(listView);
                }
            }
            else
            {
                //UI Stuff
                checkBoxLauncherEnabled.Text = "Disabled";
                checkBoxLauncherEnabled.ForeColor = Color.Firebrick;
                statusStrip.BackColor = Color.Firebrick;
                toolStripStatusLabel.Text = "Regular windows startup.";
                
                //Save
                if (!isLoading)
                {
                    EnableWindowsStartup();
                    Settings.SaveStartupList(listView);
                }
            }
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshListview();
        }


        private void addProgramToStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToStartupForm form = new AddToStartupForm(listView);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Settings.SaveStartupList(listView);
                RefreshListview();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this entry from startup?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                StartupApplicationItem item = (StartupApplicationItem)listView.SelectedItems[0];
                item.RemoveEntry();
                Settings.SaveStartupList(listView);
            }
            
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            SetContextMenuState((StartupApplicationItem)listView.SelectedItems[0]);
        }


        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.SelectedItems[0].Checked = true;
            enableToolStripMenuItem.Enabled = false;
            disableToolStripMenuItem.Enabled = true;
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {

            listView.SelectedItems[0].Checked = false;
            enableToolStripMenuItem.Enabled = true;
            disableToolStripMenuItem.Enabled = false;
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.SaveStartupList(listView);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Windows_Startup
{
    public partial class UnmanagedItemsResolutionForm : Form
    {
        List<StartupApplicationItem> resolvedItems;
        ListView mainListView;
        
        public UnmanagedItemsResolutionForm(List<StartupApplicationItem> unmanagedItems, ListView mainListView)
        {
            InitializeComponent();

            resolvedItems = unmanagedItems;
            this.mainListView = mainListView;

            foreach (StartupApplicationItem item in unmanagedItems)
            {
                listView.Items.Add(item);
            }

            listView.ItemCheck += listView_ItemCheck;
        }


        private void buttonDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UnmanagedItemsResolutionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Create a group for all new entries
            ListViewGroup newGroup = new ListViewGroup("New Entries");
            mainListView.Invoke(new Action(() =>
            {
                mainListView.Groups.Insert(0, newGroup);
            }));

            //Disable from window startup, add to launcher if checked
            foreach (StartupApplicationItem item in resolvedItems)
            {
                if (!item.requiresAdminPrivileges || Settings.IsAdministrator)
                    item.applicationData.SetKeyState(item.Checked);

                listView.Items.Remove(item);

                mainListView.Invoke(new Action(() =>
                {
                    mainListView.Items.Add(item);
                    item.Group = newGroup;
                }));
            }

            //Save startup to include the new entries
            Settings.SaveStartupList(mainListView);
        }

        private void listView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Make sure that you cannot change items you don't have the privileges to change
            StartupApplicationItem item = (StartupApplicationItem)listView.Items[e.Index];
            if (item.requiresAdminPrivileges && !Settings.IsAdministrator)
            {
                e.NewValue = CheckState.Checked;
                return;
            }
        }
    }
}

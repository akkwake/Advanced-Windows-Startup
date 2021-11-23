using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartupExplorer;

namespace Advanced_Windows_Startup
{
    public partial class AddToStartupForm : Form
    {
        ListView listView;

        public AddToStartupForm(ListView listView)
        {
            InitializeComponent();

            this.listView = listView;
            if (!Settings.IsAdministrator)
                radioButtonCommon.Enabled = false;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            DialogResult dr = browseFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = browseFileDialog.FileName;
                textBoxPath.Text = path;
                toolTip.SetToolTip(textBoxPath, path);
                if (comboBoxLocation.SelectedIndex != -1)
                    buttonAccept.Enabled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            //Get app path
            string targetPath = textBoxPath.Text;

            //Add arguments
            if (!textBoxArgs.Text.Equals(""))
                targetPath += " " + textBoxArgs.Text;

            //Get name of application
            int index = targetPath.LastIndexOf('\\') + 1;
            string appName = targetPath.Substring(index, targetPath.Length - index);

            int indexExtension = appName.LastIndexOf('.');
            string appNameNoExtension = appName.Substring(0, indexExtension);

            //Current User
            if (radioButtonUser.Checked)
            {
                switch (comboBoxLocation.SelectedIndex)
                {
                    case 0:
                        StartupApplicationItem item = new StartupApplicationItem(appNameNoExtension, targetPath, 0.ToString(), true, false);
                        listView.Items.Add(item);
                        break;
                    case 1:
                        Explorer.AddToStartup(appNameNoExtension, targetPath, StartupGroup.StartMenuUser);
                        break;
                    case 2:
                        Explorer.AddToStartup(appNameNoExtension, targetPath, StartupGroup.HKCU);
                        break;
                }
            }
            //All users
            else
            {
                switch (comboBoxLocation.SelectedIndex)
                {
                    case 0:
                        StartupApplicationItem item = new StartupApplicationItem(appNameNoExtension, targetPath, 0.ToString(), true, true);
                        listView.Items.Add(item);
                        break;
                    case 1:
                        Explorer.AddToStartup(appNameNoExtension, targetPath, StartupGroup.StartMenuCommon);
                        break;
                    case 2:
                        Explorer.AddToStartup(appNameNoExtension, targetPath, StartupGroup.HKLM64);
                        break;
                }
            }

            this.Close();
        }


        private void comboBoxLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxLocation.SelectedIndex)
            {
                case 0:     //Launcher
                    labelInfo.Text = "Sets up the launcher to include the selected application. No shortcuts or registry entries are created.";
                    break;
                case 1:     //Folder
                    labelInfo.Text = "Creates a shortcut to the Startup folder in Start Menu.";
                    break;
                case 2:     //Registry
                    labelInfo.Text = "Creates a registry entry in the Startup key.";
                    break;
            }

            if (textBoxPath.Text.Length != 0)
                buttonAccept.Enabled = true;
        }
    }
}

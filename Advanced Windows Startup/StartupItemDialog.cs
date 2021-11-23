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
    public partial class StartupItemDialog : Form
    {
        StartupApplicationItem item;

        public StartupItemDialog(StartupApplicationItem appItem)
        {
            InitializeComponent();

            //Hidden button so you can close the dialog by hitting escape
            buttonCancel.Location = new Point(-15, -15);

            //Set dialog data
            item = appItem;
            Text = appItem.SubItems[1].Text;
            numericUpDownDelay.Value = Convert.ToInt32(appItem.Delay);
            checkBoxHidden.Checked = item.hidden;
        
            //Set icon
            Bitmap ico = ManagerForm.ImageList.Images[appItem.ImageIndex] as Bitmap;
            this.Icon = Icon.FromHandle(ico.GetHicon());

            //Disable one of the buttons if you don't have the privileges to change this item
            if (appItem.requiresAdminPrivileges && !Settings.IsAdministrator)
            {
                if (appItem.Checked)
                    buttonDisable.Enabled = false;
                else
                    buttonEnable.Enabled = false;
            }
        }

        private void StartupItemDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            item.SubItems[3].Text = numericUpDownDelay.Value.ToString();
        }


        private void checkBoxHidden_CheckedChanged(object sender, EventArgs e)
        {
            item.hidden = checkBoxHidden.Checked;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Windows_Startup
{
    public class mListView : ListView
    {
        // Intercept mouse double click. Double click should show the ItemDialog form rather than toggle check state.
        protected override void WndProc(ref Message m)
        {
            // Filter WM_LBUTTONDBLCLK
            if (m.Msg != 0x203) base.WndProc(ref m);
            else
            {
               ShowStartupItemDialog();
            }
        }

        void ShowStartupItemDialog()
        {
            if (this.SelectedItems.Count == 0)
                return;

            //Reference selected item
            StartupApplicationItem item = (StartupApplicationItem)this.SelectedItems[0];

            //Create dialog
            StartupItemDialog dialog = new StartupItemDialog(item);
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.Yes)
                item.Checked = true;
            else if (result == DialogResult.No)
                item.Checked = false;

            //Save changes on file
            Settings.SaveStartupList(this);
        }
    }
}

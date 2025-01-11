using Microsoft.Win32;
using StartupExplorer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Windows_Startup
{
    public static class Settings
    {
        /// <summary>
        /// Application name for the startup entry.
        /// </summary>
        public const string registryName = "Advanced Windows Startup";

        /// <summary>
        /// True if this program is ran with administrator privileges.
        /// </summary>
        public static bool IsAdministrator { get; private set; }

        public static bool LauncherEnabled { get; private set; } = false;

        static string username = Environment.UserName;

        //static string userFilePath = Assembly.GetExecutingAssembly().Location + '\\' + username + ".startup.dat";
        static string userFilePath = Environment.CurrentDirectory + '\\' + username + ".startup.dat";

        static List<string> userfileData = new List<string>();

        static Settings()
        {
            if (StartsWithWindows())
            {
                userFilePath = GetConfigPath();
            }

            IsAdministrator = CheckAdminStatus();
            LauncherEnabled = StartsWithWindows();
        }


        /// <summary>
        /// Saves the startup list.
        /// </summary>
        /// <param name="listView"></param>
        public static void SaveStartupList(ListView listView)
        {
            string managerPath = Assembly.GetExecutingAssembly().Location;
            string path = managerPath.Substring(0, managerPath.LastIndexOf('\\') + 1) + username + ".startup.dat";
            
            if (StartsWithWindows())
            {
                path = GetConfigPath();
            }

            StreamWriter sw = new StreamWriter(userFilePath);

            listView.Invoke(new Action(() =>
            {
                foreach (StartupApplicationItem item in listView.Items)
                    sw.WriteLine(item.Name + "&&" + item.Path + "&&" + item.Delay + "&&" + item.Checked + "&&" + item.hidden);
            }));
            

            sw.Close();
        }


        /// <summary>
        /// Adds the launcher to the current user's startup.
        /// </summary>
        public static void AddToStartup()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            string launcherPath = path.Substring(0, path.LastIndexOf('\\') + 1) + "awsl.exe";

            Explorer.AddToStartup(registryName, launcherPath, StartupGroup.HKCU);
            LauncherEnabled = true;
        }

        /// <summary>
        /// Removes the launcher from the current user's startup.
        /// </summary>
        public static void RemoveFromStartup()
        {
            //"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Explorer.GetGroupData(StartupGroup.HKCU).path, true))
                key.DeleteValue(registryName, false);

            //"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\StartupApproved\\Run"
            using (RegistryKey keyState = Registry.CurrentUser.OpenSubKey(Explorer.GetGroupData(StartupGroup.HKCU).approvedPath, true))
                keyState.DeleteValue(registryName, false);
            
            LauncherEnabled = false;
        }
        
        /// <summary>
        /// Parses the user data file and stores the result in the userFileData list.
        /// </summary>
        public static void ParseFile()
        {
            if (!File.Exists(userFilePath))
                return;

            userfileData.Clear();

            using (StreamReader sr = new StreamReader(userFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    userfileData.Add(line);
                }
            }
        }

        /// <summary>
        /// Loads item settings.
        /// Returns true if application is unmanaged.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool CorrectItemFromFile(StartupApplicationItem item)
        {
            if (!File.Exists(userFilePath))
                return false;

            for (int i = 0; i < userfileData.Count; i++)
            {
                LineResult lineResult = ProcessItem(item, userfileData[i]);

                switch (lineResult)
                {
                    case LineResult.ItemFound:
                        userfileData.RemoveAt(i);
                        return false;
                    case LineResult.ItemUnmanaged:
                        userfileData.RemoveAt(i);
                        return true;
                }
            }
            return true;
        }

        /// <summary>
        /// Creates StartupApplicationItems from all objects in userfileData.
        /// Should run after `CorrectItemFromFile()` to get launcher only items.
        /// </summary>
        /// <returns></returns>
        public static StartupApplicationItem[] CreateItemsFromFile()
        {
            StartupApplicationItem[] items = new StartupApplicationItem[userfileData.Count]; 
            for (int i = 0; i < userfileData.Count; i++)
            {
                items[i] = new StartupApplicationItem(userfileData[i]);
            }
            return items;
        }

        enum LineResult
        {
            ItemFound,
            ItemNotFound,
            ItemUnmanaged
        }

        /// <summary>
        /// Loads item settings.
        /// Returns LineResult enumerator.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        static LineResult ProcessItem(StartupApplicationItem item, string line)
        {
            string[] args = line.Split(new string[] { "&&" }, StringSplitOptions.None);

            //Entry in file found for item
            if (item.Name.Equals(args[0]))
            {
                item.SubItems[3].Text = args[2];
                bool enabledInFile = Convert.ToBoolean(args[3]);

                if (LauncherEnabled)
                {
                    //Checked means it is set to run on startup
                    if (item.Checked)
                        return LineResult.ItemUnmanaged;    //Item is unmanaged
                    else
                        item.Checked = enabledInFile;   //Set checked state to whatever is in the user file
                }

                bool hiddenInLauncher = Convert.ToBoolean(args[4]);
                item.hidden = hiddenInLauncher;

                return LineResult.ItemFound;
            }
            return LineResult.ItemNotFound;
        }

        /// <summary>
        /// Returns true if launcher is found in the HKCU group.
        /// </summary>
        /// <returns></returns>
        static bool StartsWithWindows()
        {
            //"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Explorer.GetGroupData(StartupGroup.HKCU).path, false))
                return key.GetValueNames().Where(p => p.Equals(registryName)).Any();
        }

        static string GetConfigPath()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(Explorer.GetGroupData(StartupGroup.HKCU).path, false))
            {
                IEnumerable<String> k = key.GetValueNames().Where(p => p.Equals(registryName));

                return Path.GetDirectoryName((String)key.GetValue("Advanced Windows Startup")) + "\\" + username + ".startup.dat";
            }
        }

            /// <summary>
            /// Returns true if this application was ran with administrator privileges.
            /// </summary>
            /// <returns></returns>
            static bool CheckAdminStatus()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

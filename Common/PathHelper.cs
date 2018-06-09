using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace TravelAgency.Common
{
    public class PathHelper
    {

        public static string GetUserDesktop()
        {
            RegistryKey folders;
            folders = OpenRegistryPath(Registry.CurrentUser, @"/software/microsoft/windows/currentversion/explorer/shell folders");
            string desktopPath = folders.GetValue("Desktop").ToString();
            return desktopPath;
        }

        private static RegistryKey OpenRegistryPath(RegistryKey root, string s)

        {

            s = s.Remove(0, 1) + @"/";

            while (s.IndexOf(@"/") != -1)

            {

                root = root.OpenSubKey(s.Substring(0, s.IndexOf(@"/")));

                s = s.Remove(0, s.IndexOf(@"/") + 1);

            }

            return root;

        }
    }
}

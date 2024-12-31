using System;
using System.Diagnostics;
using System.IO;

namespace GOGAdminBypass
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.WriteLine("Arg0: FilePath, Arg1 (Optional): Working Directory");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"{args[0]} does not exists");
                return;
            }

            Process adminProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = args[0],
                    UseShellExecute = true,
                    Verb = "runas"
                }
            };

            if (args.Length == 2 && Directory.Exists(args[1])) adminProcess.StartInfo.WorkingDirectory = args[1];
            adminProcess.Start();
            adminProcess.WaitForExit();
        }
    }
}

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace GameDateFix
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //args
            // [0] 64 bit flag
            // [1] Executable Path
            // [2] dateback (Years)
            // [3] timeout (seconds)

            if (args.Length != 4)
            {
                Console.WriteLine("64bit flag(0/1), Executable Path, dateback years, timeout (in seconds)");
                return;
            }

            string processName;
            if (!File.Exists(args[1]))
            {
                Console.WriteLine("File doesn't exist");
                return;
            }
            else processName = Path.GetFileNameWithoutExtension(args[1]);

            if (!int.TryParse(args[2], out int yearsChange))
            {
                Console.WriteLine(args[2] + "is not a number");
                return;
            }

            int timeout = 5;
            int.TryParse(args[3], out timeout);

            byte[] runAsDate = int.Parse(args[0]) == 0 ? Properties.Resources.RunAsDate32 : Properties.Resources.RunAsDate;
            string tmpFilePath = Path.GetTempFileName();
            File.Move(tmpFilePath, tmpFilePath.Replace(".tmp", ".exe"));
            tmpFilePath = tmpFilePath.Replace(".tmp", ".exe");
            File.WriteAllBytes(tmpFilePath, runAsDate);
            Console.WriteLine(tmpFilePath);
            Console.ReadLine();
            Process.Start(tmpFilePath, $"/movetime Years:{yearsChange} \"{args[1]}\"");
            Thread.Sleep(timeout * 1000);
            try
            {
                foreach (Process p in Process.GetProcessesByName(processName))
                {
                    p.WaitForExit();
                }
            }
            finally
            {
                File.Delete(tmpFilePath);
            }


        }
    }
}

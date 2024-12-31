using System.Diagnostics;
using System.Threading;

namespace SteamStartBypasser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //arg 0 id steam
            //arg 1 process name
            //arg 2 timeout (s)

            Process.Start($"steam://rungameid/{args[0]}");
            Thread.Sleep(int.Parse(args[2]) * 1000);
            foreach (Process p in Process.GetProcessesByName(args[1]))
            {
                try
                {
                    p.WaitForExit();
                }
                catch
                {

                }
            }

        }
    }
}

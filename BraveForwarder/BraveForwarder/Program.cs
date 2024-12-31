using System.Diagnostics;

namespace BraveForwarder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string rebuiltArgs = string.Empty;
            foreach (var arg in args) rebuiltArgs += arg + ' ';
            Process.Start("brave.exe", rebuiltArgs.TrimEnd());
        }
    }
}

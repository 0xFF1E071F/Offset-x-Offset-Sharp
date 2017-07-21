using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    internal static class GlobalDataAndMethods
    {
        internal static string AbsoluteDirectory = Path.GetDirectoryName(typeof(GlobalDataAndMethods).Assembly.Location);

        private static string firstrunData = Environment.UserName + Environment.MachineName;

        internal static string currentVersion = "0.2";
        internal static string date = "04/07/2017";

        private static Config _config;

        internal static Config Config
        {
            get
            {
                if (_config == null)
                    SaverLoader.LoadConfig(out _config);
                return _config;
            }
        }
        internal static string VersionAndDate()
        {
            return string.Format("{0} ({1})", currentVersion, date);
        }

        internal static void NagScreen()
        {

            string firstRunPath = Path.Combine(AbsoluteDirectory, "firstrun");

            try
            {
                if (File.Exists(firstRunPath))
                    using (TextReader reader = new StreamReader(firstRunPath))
                    {
                        if (reader.ReadLine() == firstrunData)
                            return;
                    }
            }
            catch { }

            if (new frmAbout(true).ShowDialog() != System.Windows.Forms.DialogResult.OK)
                Environment.Exit(0);

            try
            {
                File.WriteAllLines(firstRunPath, new string[] { firstrunData });
            }
            catch { }
        }

        internal static string OutputFormat(int CurrentStart, int CurrentEnd, bool extension = false)
        {
            return string.Format("{0:X8}-{1:X8}" + ((extension) ? ".exe" : ""), CurrentStart, CurrentEnd);
        }
        internal static string OutputFormat(int value)
        {
            return string.Format("{0:X8}", value);
        }

        internal static void RunProcess(string fileName, string commandLine, bool useShellExecute = false, bool WaitForExit = false)
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo(fileName, commandLine)
                {
                    UseShellExecute = useShellExecute
                }
            };
            process.Start();
            if (WaitForExit)
                process.WaitForExit();

        }
        internal static void Scan(bool WaitForExit = false)
        {
            if (Config.AV_File == "" || !File.Exists(Config.AV_File))
                ShowConfigForm(true);
            else
                GlobalDataAndMethods.RunProcess(Config.AV_File, Config.AV_CommandLine,false,WaitForExit);
        }
        internal static void ShowConfigForm(bool FlashTxtAv = false)
        {
            using (frmConfig frmConfig = new frmConfig(Config, FlashTxtAv))
            {
                frmConfig.ShowDialog();
            }
        }

        internal static int AutoCalculateSize(int start, int end)
        {
            return ((end - start) / GlobalDataAndMethods.Config.SizeDivider);
        }
    }
}

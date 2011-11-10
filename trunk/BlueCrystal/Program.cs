using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BlueCrystal.Classes;

namespace BlueCrystal
{
    static class Program
    {

        public static string DataFolderPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                    "BlueCrystal\\Data");
            }
        }
        private static bool shutDown = false;

        public static string RunSvn(string command, string parameters)
        {
            return RunCmd(".\\lib\\svn.exe ", command + " " + parameters);
        }

        static void setAltF4Handler(Form f)
        {
            f.KeyPreview = true;
            f.KeyDown += new KeyEventHandler(f_KeyDown);
        }

        static void f_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                shutDown = true;
            }
        }

        public static string RunCmd(string file, string arguments)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = file;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.WorkingDirectory = Process.GetCurrentProcess().StartInfo.WorkingDirectory + "lib\\";
            p.StartInfo.CreateNoWindow = true;

            p.Start();


            p.WaitForExit();

            return p.StandardError.ReadToEnd() + p.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Splash.Open();

            if (!Directory.Exists(Program.DataFolderPath + ""))
            {
                Directory.CreateDirectory(Program.DataFolderPath + "");
            }
            Splash.SetMessage("getting Info...");

            string asdf = RunSvn("info", "\"" + DataFolderPath +"\"");
            
            if (asdf.Contains("is not a working copy"))
            {
                Splash.SetMessage("Downloading Language Files...");
                RunSvn("checkout", "https://bluecrystaldict.googlecode.com/svn/trunk/ \"" + DataFolderPath +"\"");
            }
            else
            {
                Splash.SetMessage("Updating Language Files...");
                RunSvn("update", "\"" + DataFolderPath +"\" --depth infinity --accept theirs-full");
            }

            Splash.SetMessage("Starting");

            Thread.Sleep(1000);

            Splash.Close();


            while (!shutDown)
            {
                ProfileForm profileForm = new ProfileForm();
                setAltF4Handler(profileForm);
                DialogResult result = profileForm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    shutDown = true;
                }
                else
                {
                    LektionForm f = new LektionForm(profileForm.Profil, profileForm.Sprache);
                    setAltF4Handler(f);
                    while (!shutDown)
                    {
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            VokabelForm v = new VokabelForm(f.Vokabeln, f.Number, f.AskLanguageString, f.ShowLanguageString, f.AskLanguage, f.ShowLanguage, f.Audio, f.Pictures, f.Preview);
                            setAltF4Handler(v);
                            v.ShowDialog();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}

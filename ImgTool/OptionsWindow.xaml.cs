using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace ImgTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class OptionsWindow : MetroWindow
    {
        public ResourceManager lang = new ResourceManager("ImgTool.Strings", Assembly.GetExecutingAssembly());
        public OptionsWindow()
        {
            InitializeComponent();
            Loaded += OptionsWindow_Loaded;
        }
        private void OptionsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = lang.GetString("Title");
            tab1.Header = lang.GetString("System_Editor");
            tab2.Header = lang.GetString("Boot_Editor");
            tab3.Header = lang.GetString("Recovery_Editor");
            tab4.Header = lang.GetString("APK_Editor");
            tab5.Header = lang.GetString("Sparse_Editor");
            tab6.Header = lang.GetString("DAT_Editor");
            tab7.Header = lang.GetString("Brotli_Editor");
            btn1.Content = lang.GetString("Unpack");
            btn2.Content = lang.GetString("Repack");
            btn3.Content = lang.GetString("Unpack");
            btn4.Content = lang.GetString("Repack");
            btn5.Content = lang.GetString("Unpack");
            btn6.Content = lang.GetString("Repack");
            btn7.Content = lang.GetString("Unpack");
            btn8.Content = lang.GetString("Repack");
            btn9.Content = lang.GetString("Sparse");
            btn10.Content = lang.GetString("Unsparse");
            btn11.Content = lang.GetString("DAT_To_IMG");
            btn12.Content = lang.GetString("IMG_To_DAT");
            btn13.Content = lang.GetString("BR_To_DAT_IMG");
            btn14.Content = lang.GetString("DAT_IMG_To_BR");
            label.Content = lang.GetString("Copyright");
        }
        public void Execute(string arg)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c " + arg,
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            proc.WaitForExit();
            this.ShowMessageAsync(lang.GetString("Warning"), lang.GetString("Process_Ok"), MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = lang.GetString("Ok") });
        }
        private string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
            {
                string currentVersion = rk.GetValue("CurrentVersion").ToString();
                using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                {
                    return key.GetValue("JavaHome").ToString();
                }
            }
        }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("System_File")+" (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (!Directory.Exists("Source_System"))
                {
                    Directory.CreateDirectory("Source_System");
                }
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                System.IO.DirectoryInfo di = new DirectoryInfo("Source_System");
                foreach (FileInfo filex in di.GetFiles())
                {
                    filex.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Execute("libs\\extract \"" + file + "\" Source_System & del /F /Q Source_System_statfile.txt");
                Process.Start("Source_System");
            }
        }
        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("Source_System"))
            {
                this.ShowMessageAsync(lang.GetString("Warning"), lang.GetString("Not_Found_Source"), MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = lang.GetString("Ok") });
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = lang.GetString("System_File")+" (.img)|*.img";
                save.OverwritePrompt = true;
                save.ShowDialog();
                if (save.FileName != "")
                {               
                    string file = save.InitialDirectory + save.FileName;
                    string totalSize = Microsoft.VisualBasic.Interaction.InputBox(lang.GetString("Partition_Byte_Value"), lang.GetString("Information")).Trim();
                    if(totalSize=="" || totalSize == "0") totalSize = ((GetDirectorySize("Source_System")/(1000*1000))+5).ToString()+"M";
                    Execute("libs\\make_ext4fs -L system -S libs\\file_contexts -l "+totalSize+" -a system \"" + file + "\" Source_System");
                }
            }
        }
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("Boot_File") + " (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (!Directory.Exists("Source_Boot"))
                {
                    Directory.CreateDirectory("Source_Boot");
                }
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                System.IO.DirectoryInfo di = new DirectoryInfo("Source_Boot");
                foreach (FileInfo filex in di.GetFiles())
                {
                    filex.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Execute("xcopy /q /Y \"" + file + "\" Source_Boot & ren Source_Boot\\*.img boot.img & xcopy /q /Y libs\\bootimg.exe Source_Boot & cd Source_Boot & bootimg --unpack-bootimg & del bootimg.exe & del boot-old.img & del boot.img & cd..");
                Process.Start("Source_Boot");
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("Source_Boot"))
            {
                this.ShowMessageAsync(lang.GetString("Warning"), lang.GetString("Not_Found_Source"), MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = lang.GetString("Ok") });
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = lang.GetString("Boot_File")+" (.img)|*.img";
                save.OverwritePrompt = true;
                save.ShowDialog();
                if (save.FileName != "")
                {
                    string file = save.InitialDirectory + save.FileName;
                    Execute("xcopy /q /Y libs\\bootimg.exe Source_Boot & cd Source_Boot & bootimg --repack-bootimg & move boot-new.img \"" + file + "\" & cd ../ & rmdir Source_Boot /s /q");
                }
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("Recovery_File")+" (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (!Directory.Exists("Source_Recovery"))
                {
                    Directory.CreateDirectory("Source_Recovery");
                }
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                System.IO.DirectoryInfo di = new DirectoryInfo("Source_Recovery");
                foreach (FileInfo filex in di.GetFiles())
                {
                    filex.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Execute("xcopy /q /Y \"" + file + "\" Source_Recovery & ren Source_Recovery\\*.img boot.img & xcopy /q /Y libs\\bootimg.exe Source_Recovery & cd Source_Recovery & bootimg --unpack-bootimg & del bootimg.exe & del boot-old.img & del boot.img & cd..");
                Process.Start("Source_Recovery");
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists("Source_Recovery"))
            {
                this.ShowMessageAsync(lang.GetString("Warning"), lang.GetString("Not_Found_Source"), MessageDialogStyle.Affirmative, new MetroDialogSettings() { AffirmativeButtonText = lang.GetString("Ok") });
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = lang.GetString("Recovery_File") +" (.img)|*.img";
                save.OverwritePrompt = true;
                save.ShowDialog();
                if (save.FileName != "")
                {
                    string file = save.InitialDirectory + save.FileName;
                    Execute("xcopy /q /Y libs\\bootimg.exe Source_Recovery & cd Source_Recovery & bootimg --repack-bootimg & move boot-new.img \"" + file + "\" & cd ../ & rmdir Source_Recovery /s /q");
                }
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("APK_File")+" (.apk)|*.apk";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                if (Directory.Exists("Source_APK"))
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo("Source_APK");
                    foreach (FileInfo filex in di.GetFiles())
                    {
                        filex.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                }
                Execute("\"" + System.IO.Path.Combine(GetJavaInstallationPath(), "bin\\java.exe") + "\" -jar libs\\apktool.jar d -f -o Source_APK " + file);
                Process.Start("Source_APK");
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = lang.GetString("APK_File")+" (.apk)|*.apk";
            save.OverwritePrompt = true;
            save.ShowDialog();
            if (save.FileName != "")
            {
                string file = save.InitialDirectory + save.FileName;
                Execute("\"" + System.IO.Path.Combine(GetJavaInstallationPath(), "bin\\java.exe") + "\" -jar libs\\apktool.jar b -f -o \"" + file + "\" Source_APK ");
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("System_File")+" (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = lang.GetString("System_File")+" (.img)|*.img";
                save.OverwritePrompt = true;
                save.ShowDialog();
                if (save.FileName != "")
                {
                    string file2 = save.InitialDirectory + save.FileName;
                    Execute("libs\\img2simg \"" + file + "\" \"" + file2+"\"");
                }
            }
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("System_File")+" (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = lang.GetString("System_File")+" (.img)|*.img";
                save.OverwritePrompt = true;
                save.ShowDialog();
                if (save.FileName != "")
                {
                    string file2 = save.InitialDirectory + save.FileName;
                    Execute("libs\\simg2img \"" + file + "\" \"" + file2+"\"");
                }
            }
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("DAT_File") + " (.dat)|system.new.dat";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string directory = System.IO.Path.GetDirectoryName(openFileDialog1.InitialDirectory + openFileDialog1.FileName) + "\\";
                Execute("libs\\sdat2img \"" + directory + "system.transfer.list\" \"" + directory + "system.new.dat\" \"" + directory + "system.img\"");
            }
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("System_File") + " (.img)|*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                string directory = System.IO.Path.GetDirectoryName(file) + "\\";
                Execute("libs\\rimg2sdat \"" + file + "\" & move system.new.dat \"" + directory + "system.new.dat\" & move system.transfer.list \"" + directory + "system.transfer.list\"");
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Btn13_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("BR_File") + " (.br)|*.br";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                Execute("libs\\brotli -d \""+file+"\"");
            }
        }

        private void Btn14_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = lang.GetString("DAT_IMG_File") + " (.dat,.img)|*.dat;*.img";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string file = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                Execute("libs\\brotli \"" + file+"\"");
            }
        }
    }
}

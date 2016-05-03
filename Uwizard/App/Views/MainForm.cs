using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using SmartFormat;
using Uwizard.App.Models;
using Uwizard.Entities;
using Uwizard.Entities.Enums;
using Uwizard.Entities.Helpers;
using Uwizard.Extensions;
using Uwizard.Resources.Languages;

namespace Uwizard.App.Views
{
    public partial class MainForm : Form, IView<MainFormViewModel>
    {
        public MainForm()
        {
            ViewModel = new MainFormViewModel();
            InitializeComponent();
        }

        private void MainFormLoading(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists("uwiz_newverfiles"))
            {
                try
                {
                    Thread.Sleep(1000);
                    System.IO.File.Delete("uwiz_newverfiles/Updater.exe");
                    if (System.IO.File.Exists("uwiz_newverfiles/uwiz_lver.txt"))
                    {
                        int lver = int.Parse(System.IO.File.ReadAllText("uwiz_newverfiles/uwiz_lver.txt"));
                        switch (lver)
                        {
                            case 110:
                                break;
                            case 112:
                            case 113:
                            case 111:
                                Properties.Settings.Default.Language = (byte) LanguagesEnum.System;
                                Properties.Settings.Default.Save();
                                break;
                        }
                    }
                    else
                    { // Updating from v1.0.0 or v1.0.1
                        var sr = new System.IO.StreamReader("uwiz_newverfiles/doNOTopen.txt");
                        sr.ReadLine();
                        sr.ReadLine();
                        Properties.Settings.Default.UserCommonKey = sr.ReadLine().EncodeDecode();
                        Properties.Settings.Default.UserAncastStarbuckKey = sr.ReadLine().EncodeDecode();
                        Properties.Settings.Default.UserAncastEspressoKey = sr.ReadLine().EncodeDecode();
                        sr.Close();
                        sr.Dispose();
                        Properties.Settings.Default.Save();
                        Helpers.DisplayMessage(string.Format(Strings.UwizardUpdatePartialSuccess, AssemblyHelper.GetProductVersionString()));
                    }
                    Helpers.DisplayMessage(string.Format(Strings.Updated, AssemblyHelper.GetProductVersionString()));
                }
                catch (Exception ex)
                {
                    Helpers.DisplayMessage(string.Format(Strings.UpdatedWithError, AssemblyHelper.GetProductVersionString()));
                }
                System.IO.Directory.Delete("uwiz_newverfiles", true);
            }

            /*if ((LanguagesEnum)Properties.Settings.Default.Language == LanguagesEnum.English)
                hideKeys.Font = new Font(nus_usecdecrypt.Font.FontFamily, 8.25f);
            else
                hideKeys.Font = new Font(nus_usecdecrypt.Font.FontFamily, 6.25f);

            if (uwiz_settings_language == LanguagesEnum.English || uwiz_settings_language == LanguagesEnum.Português)
                nus_usecdecrypt.Font = new Font(nus_usecdecrypt.Font.FontFamily, 8.25f);
            else
                nus_usecdecrypt.Font = new Font(nus_usecdecrypt.Font.FontFamily, 6.25f);

            

            ckey_prev.Text = uwiz_settings_key_common;
            aekey_prev.Text = uwiz_settings_key_ancast_espresso;
            askey_prev.Text = uwiz_settings_key_ancast_starbuck;

            ckey_prev_TextChanged(ckey_prev, null);
            aekey_prev_TextChanged(aekey_prev, null);
            askey_prev_TextChanged(aekey_prev, null);

            splitContainer1_SplitterMoved(splitContainer1, null);

            /*System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile("http://wiiubrew.net/?smd_process_download=1&download_id=531", "uwizard.tmp");
            if (System.IO.File.Exists("uwizard.tmp")) System.IO.File.Delete("uwizard.tmp");
            wc.Dispose();*/

           /* if (ckey_prev.Text == "" && System.IO.File.Exists("ckey.bin"))
                ckey_prev.Text = byte2hex(System.IO.File.ReadAllBytes("ckey.bin"));

            ticktock_refreshinator.Start();*/
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        public MainFormViewModel ViewModel { get; set; }
    }
}

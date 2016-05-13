using System;
using System.Collections.Generic;
using System.IO;

namespace UwizardWPF.Entities.Helpers
{
    public static class Helpers
    {
        public static void DisplayMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message, "Uwizard");
        }

        public static void SetReadOnly(TextBox textBox, bool readOnly)
        {
            textBox.ReadOnly = readOnly;
            textBox.BackColor = readOnly ? SystemColors.Control: SystemColors.Window;
        }

        public static void DownloadCover(string cvnam, IEnumerable<String> klinks, string rtext, string gameid)
        {
            if (System.IO.File.Exists(cvnam)) return;

            var wc = new System.Net.WebClient();
            foreach (var link in klinks)
            {
                try
                {
                    wc.DownloadFile(link + rtext + "/" + gameid + ".jpg", cvnam);
                    break;
                }
                catch (Exception ex) { }
                try
                {
                    wc.DownloadFile(link + rtext + "/" + gameid + ".png", cvnam);
                    break;
                }
                catch (Exception ex) { }
            }
            wc.Dispose();
        }

        public static Bitmap OpenBitmap(string fpath)
        {
            return String.IsNullOrWhiteSpace(fpath) || !File.Exists(fpath) ? null : new Bitmap(fpath);
        }
    }
}

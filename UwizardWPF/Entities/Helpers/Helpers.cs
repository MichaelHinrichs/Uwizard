using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace UwizardWPF.Entities.Helpers
{
    public static class Helpers
    {
        public static void DisplayMessage(string message)
        {
            MessageBox.Show(message, "Uwizard", MessageBoxButton.OK);
        }

        public static void SetReadOnly(TextBox textBox, bool readOnly)
        {
            textBox.IsReadOnly = readOnly;
            textBox.Background = readOnly ? SystemColors.InactiveSelectionHighlightBrush : SystemColors.WindowBrush;
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

        public static BitmapImage OpenBitmap(string fpath)
        {
            return String.IsNullOrWhiteSpace(fpath) || !File.Exists(fpath) ? null : new BitmapImage(new Uri(fpath));
        }
    }
}

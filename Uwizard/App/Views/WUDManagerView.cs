using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualBasic;
using Uwizard.App.Models;
using Uwizard.Entities;
using Uwizard.Entities.Helpers;
using Uwizard.Extensions;
using Uwizard.Properties;
using Strings = Uwizard.Resources.Languages.Strings;

namespace Uwizard.App.Views
{
    public partial class WUDManagerView : TabPage, IView<WUDManagerViewModel>
    {
        public WUDManagerView()
        {
            ViewModel = new WUDManagerViewModel();
            InitializeComponent();
        }

        public WUDManagerView(WUDManagerViewModel wudManagerViewModel) : this()
        {
            ViewModel = wudManagerViewModel;
        }


        private void ShowGameListCheckedChanged(object sender, EventArgs e)
        {
            WUDSplitter.Panel1Collapsed = !ShowGameListCheckBox.Checked;
            WUDSplitterMoved(WUDSplitter, null);
        }

        private void WUDSplitterMoved(object sender, SplitterEventArgs e)
        {
            WUDList.Height = AddFolderButton.Top - WUDList.Top - 4;
        }
        private void ShowFullCoverChecked(object sender, EventArgs e)
        {
            GameCoverPicture.Image = ShowFullCoverCheckBox.Checked ? Helpers.OpenBitmap(((WiiUDiskViewModel)WUDList.SelectedItem)?.CoverFullLocation) : Helpers.OpenBitmap(((WiiUDiskViewModel)WUDList.SelectedItem)?.CoverFrontLocation);
            GameCoverPicture.Refresh();
        }

        private void SaveGameInformationButtonClicked(object sender, EventArgs e)
        {
            ViewModel.GameDatabase.SingleOrDefault(x => x.Id.Equals(GameIDTextBox.Tag))?.Update(GameIDTextBox.Text, GameNameTextBox.Text, GameTitleKeyTextBox.Text, (string)GameTitleKeyTextBox.Tag, (RegionCodeEnum)GameRegionTextBox.Tag, GameDescriptionTextBox.Text);
            ViewModel.SaveGameDatabase();
            SaveGameInformationButton.Enabled = false;
        }

        private void ScrubWUDButtonClicked(object sender, EventArgs e)
        {
            Helpers.DisplayMessage(Strings.FeatureNotImplimented);
        }

        private void ExtractGameFilesButtonClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(GameTitleKeyTextBox.Text))
            {
                Helpers.DisplayMessage(Strings.DiskTitleKeyRequired); // "The disc title key is required to decrypt the data."
                //badtkey();
                return;
            }
            if (String.IsNullOrWhiteSpace(Settings.Default.UserCommonKey))
            {
                Helpers.DisplayMessage(Strings.CommonKeyRequired); // "The common key is required to decrypt the data."
                //badckey();
                return;
            }
            var tkeydu = GameTitleKeyTextBox.Text.ToByteArray();
            var ckeydu = Settings.Default.UserCommonKey.ToByteArray();
            if (tkeydu == null || tkeydu.Length != 16)
            {
                Helpers.DisplayMessage(Strings.DiskTitleKeyInvalid); // "The disc title key is invalid."
                //badtkey();
                return;
            }
            if (ckeydu == null || ckeydu.Length != 16)
            {
                Helpers.DisplayMessage(Strings.CommonKeyInvalid); // "The common key is invalid."
                //badtkey();
                return;
            }

            var haddiscu = File.Exists("DiscU.exe");
            var currentwud = (WiiUDiskViewModel) WUDList.SelectedItem;
            if (currentwud == null) return;
            var fbox = new FolderBrowserDialog
            {
                Description = Strings.SelectSaveLocation,
                ShowNewFolderButton = true,
                SelectedPath = Environment.CurrentDirectory
            };
            if (fbox.ShowDialog() != DialogResult.Cancel)
            {
                File.WriteAllBytes("ckey.bin", ckeydu);
                File.WriteAllBytes("tkey.bin", tkeydu);

                if (!haddiscu)
                {
                    gzip.decompress(Properties.Resources.DiscU, "DiscU.exe");
                    gzip.decompress(Properties.Resources.libeay32, "libeay32.dll");
                }

                System.Diagnostics.Process discu = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        FileName = Environment.CurrentDirectory + "\\DiscU.exe",
                        Arguments = "\"" + Environment.CurrentDirectory + "\\tkey.bin\" \"" +
                                    currentwud.FilePath + "\" \"" + Environment.CurrentDirectory +
                                    "\\ckey.bin\"",
                        WorkingDirectory = fbox.SelectedPath,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true,
                        UseShellExecute = false
                    }
                };

                DownloadTextBox.Visible = true;
                DownloadTextBox.Text = "";
                Cursor = Cursors.WaitCursor;

                discu.Start();
                while (!discu.StandardOutput.EndOfStream)
                {
                    DownloadTextBox.AppendText(discu.StandardOutput.ReadLine() + "\r\n");
                    DownloadTextBox.SelectionStart = DownloadTextBox.TextLength;
                    DownloadTextBox.SelectionLength = 0;
                    DownloadTextBox.ScrollToCaret();
                    Application.DoEvents();
                }
                discu.WaitForExit();
                discu.Dispose();

                var opath = fbox.SelectedPath + "\\" + currentwud.Id.Substring(0, 10);
                if (!Directory.Exists(opath))
                {
                    Helpers.DisplayMessage(Strings.ErrorExtracting); // "Error Extracting Files!"
                }
                else
                {
                    System.Diagnostics.Process.Start("C:\\Windows\\explorer.exe", "\"" + opath + "\"");
                }
            }

            fbox.Dispose();
            Cursor = Cursors.Default;
            DownloadTextBox.Visible = false;
            if (System.IO.File.Exists("tkey.bin")) System.IO.File.Delete("tkey.bin");
            if (System.IO.File.Exists("ckey.bin")) System.IO.File.Delete("ckey.bin");

            if (!haddiscu)
            {
                if (System.IO.File.Exists("DiscU.exe")) System.IO.File.Delete("DiscU.exe");
                if (System.IO.File.Exists("libeay32.dll")) System.IO.File.Delete("libeay32.dll");
            }
        }

        private void ImportSHA1ButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OpenWUDButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameTitleKeyTextBoxTextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Refresh();
        }

        private void GameTitleKeyTextBoxEnter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameTitleKeyTextBoxLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameNameTextBoxTextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Refresh();
        }

        private void GameTBDPictureClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gametdb.com");
        }

        public void WUDManagerViewLoad()
        {
            DownloadTextBox.BringToFront();
            DoubleBuffered = true;
            GameTitleKeyTextBox.Tag = "";
            GameIDTextBox.Tag = -1;
            GameRegionTextBox.Tag = RegionCodeEnum.Unknown;
        }

        public WUDManagerViewModel ViewModel { get; set; }

        private void WUDSplitterSplitterMoved(object sender, SplitterEventArgs e)
        {
            WUDList.Height = WUDListAddFolderButton.Top - WUDList.Top - 4;
        }

        private void WUDListClearFoldersButtonClicked(object sender, EventArgs e)
        {
            ViewModel.GameDatabase.Clear();
            ViewModel.SaveGameDatabase();
            Settings.Default.GameFileFolderList.Clear();
            FormRefresh(null);
        }

        private void WUDListSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (WiiUDiskViewModel) WUDList.SelectedItem;
            if(selected == null) return;
            
            if (String.IsNullOrWhiteSpace(selected.Id))
                LoadGameData(selected);
            else if(selected.Id.Equals(GameIDTextBox.Text)) return;

            FormRefresh(selected);
        }

        private void LoadGameData(WiiUDiskViewModel selected)
        {
            Cursor = Cursors.WaitCursor;
            String currentWudId = null;
            Application.DoEvents();
            try
            {
                DownloadTextBox.Text = "Reading " + Path.GetFileName(selected.FilePath) + "\r\n";
                Application.DoEvents();
                var sr = new StreamReader(selected.FilePath);
                currentWudId = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                Helpers.DisplayMessage(Strings.InvalidWiiUDisk + "\r\n\r\n" + ex.Message); // "Invalid Wii U disc Image. Perhaps you forgot to unzip the file?\r\n\r\n" + ex.Message
            }

            if (!String.IsNullOrWhiteSpace(currentWudId))
            {
                var id = currentWudId[6] + currentWudId[7].ToString() + currentWudId[8] + currentWudId[9];

                DownloadTextBox.Text += "Searching game database...\r\n";
                Application.DoEvents();
                var xmlSerializer = new XmlSerializer(typeof(BindingList<WiiUDiskViewModel>), new XmlRootAttribute("GameDatabase"));
                var streamReader = new StreamReader(ConfigurationManager.AppSettings["GameDatabasePath"]);
                var gameList = streamReader.EndOfStream ? Enumerable.Empty<WiiUDiskViewModel>() : ((BindingList<WiiUDiskViewModel>)xmlSerializer.Deserialize(streamReader)).Where(x=>!String.IsNullOrWhiteSpace(x.Id));
                var gameInfo = gameList.SingleOrDefault(x => x.Id.Equals(id));
                streamReader.Close();
                streamReader.Dispose();

                if (gameInfo == null)
                {
                    var xdoc = new XmlDocument();
                    xdoc.Load(ConfigurationManager.AppSettings["GameDescriptionPath"]);
                    var node = (XmlElement)xdoc.DocumentElement?.SelectSingleNode($"//game[contains(id, '{id}')]");
                    if (node != null)
                    {
                        gameInfo = new WiiUDiskViewModel
                        {
                            Name = node.SelectSingleNode(".//locale/title")?.InnerText,
                            Id = node.SelectSingleNode(".//id")?.InnerText,
                            Description = node.SelectSingleNode(".//locale/synopsis")?.InnerText
                        };
                        switch (node.SelectSingleNode(".//region")?.InnerText)
                        {
                            case "NTSC-J": gameInfo.RegionCode = RegionCodeEnum.JPN; break;
                            case "PAL": gameInfo.RegionCode = RegionCodeEnum.EUR; break;
                            case "NTSC-U": gameInfo.RegionCode = RegionCodeEnum.USA; break;
                            default: gameInfo.RegionCode = RegionCodeEnum.Unknown; break;
                        }
                    }
                }

                if (gameInfo == null)
                {
                    selected.Name = Interaction.InputBox(Strings.GameNotInDatabase, Strings.EnterGameName, selected.DisplayName, -1, -1); // "This game is not in the database. Please enter the name:", "Enter Game Name"
                    SaveGameInformationButtonClicked(null, EventArgs.Empty);
                }
                else
                {
                    selected.Update(gameInfo.Id, gameInfo.Name, gameInfo.Key, gameInfo.KeyHash, gameInfo.RegionCode, gameInfo.Description);

                    DownloadTextBox.Text = DownloadTextBox.Text + "Searching GameTDB for covers...\r\n";
                    Application.DoEvents();

                    selected.DownloadCovers();

                    DownloadTextBox.Text += " Done!";
                    Application.DoEvents();
                }
            }

            DownloadTextBox.Visible = false;
            ViewModel.SaveGameDatabase();
            Cursor = Cursors.Default;
        }

        private void FormRefresh(WiiUDiskViewModel selected)
        {
            if (GameCoverPicture.Image != null)
            {
                ((Bitmap)GameCoverPicture.Image).Dispose();
                GameCoverPicture.Image = null;
            }

            GameCoverPicture.Image = ShowFullCoverCheckBox.Checked ? Helpers.OpenBitmap(selected?.CoverFullLocation) : Helpers.OpenBitmap(selected?.CoverFrontLocation);
            GameCoverPicture.Show();
            GameCoverPicture.Refresh();

            Helpers.SetReadOnly(GameTitleKeyTextBox, false);
            Helpers.SetReadOnly(GameNameTextBox, false);
            ImportGameKeySHA1Button.Enabled = true;
            ExtractGameFilesButton.Enabled = true;

            GameTitleKeyTextBox.Text = selected?.KeyHash;
            GameIDTextBox.Text = selected?.Id;
            GameNameTextBox.Text = selected?.Name;
            GameRegionTextBox.Text = selected?.RegionCode.GetDescription();
            GameDescriptionTextBox.Text = selected?.Description;
            WUDListUpdate();
        }

        private void WUDListAddFolderButtonClicked(object sender, EventArgs e)
        {
            var fbox = new FolderBrowserDialog {Description = Strings.WiiUGameDirectorySearch};
            if (fbox.ShowDialog() != DialogResult.Cancel)
            {
                ViewModel.AddFolder(fbox.SelectedPath);
            }
            fbox.Dispose();
            WUDListUpdate();
            WUDList.SelectedIndex = WUDList.SelectedIndex;
        }

        private void WUDListUpdate()
        {
            WUDList.DataSource = null;
            WUDList.DataSource = ViewModel.GameDatabase;
            WUDList.DisplayMember = "DisplayName";
            WUDList.Refresh();
        }
    }
}

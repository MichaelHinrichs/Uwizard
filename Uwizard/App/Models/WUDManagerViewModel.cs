using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Uwizard.App.Views;
using Uwizard.Entities;
using Uwizard.Entities.Helpers;
using Uwizard.Resources.Languages;

namespace Uwizard.App.Models
{
    public class WUDManagerViewModel : BaseViewModel
    {
        [XmlElement("Game")]
        public BindingList<WiiUDiskViewModel> GameDatabase { get; set; } 
        public bool ShowGameList { get; set; }

        public WUDManagerViewModel()
        {
            LoadGameDatabase();
            SaveGameDatabase();
        }

        public void LoadGameDatabase()
        {
            var xmlSerializer = new XmlSerializer(typeof(BindingList<WiiUDiskViewModel>), new XmlRootAttribute("GameDatabase"));
            var streamReader = new StreamReader(ConfigurationManager.AppSettings["GameDatabasePath"]);
            GameDatabase = streamReader.EndOfStream ? new BindingList<WiiUDiskViewModel>() : (BindingList<WiiUDiskViewModel>)xmlSerializer.Deserialize(streamReader);
            streamReader.Close();
            streamReader.Dispose();
        }
        
        public void SaveGameDatabase()
        {
            var xmlSerializer = new XmlSerializer(typeof(BindingList<WiiUDiskViewModel>), new XmlRootAttribute("GameDatabase"));
            var streamwWriter = new StreamWriter(ConfigurationManager.AppSettings["GameDatabasePath"]);
            xmlSerializer.Serialize(streamwWriter, GameDatabase);
            streamwWriter.Close();
            streamwWriter.Dispose();
        }

        public override Control View()
        {
            return new WUDManagerView(this);
        }

        public void AddFolder(string folder)
        {
            if (!Directory.Exists(folder) || Properties.Settings.Default.GameFileFolderList.Contains(folder)) return;

            var files = Directory.GetFiles(folder);

            if (files.Any(x => Path.GetExtension(x) == ".wud"))
                Properties.Settings.Default.GameFileFolderList.Add(folder);

            Properties.Settings.Default.Save();
            RefreshGameList();
        }

        public void RefreshGameList()
        {
            var folders = Properties.Settings.Default.GameFileFolderList.Cast<string>().Where(Directory.Exists);
            var files = folders.SelectMany(Directory.GetFiles).Where(x=> Path.GetExtension(x) == ".wud");
            GameDatabase.Clear();
            foreach (var file in files)
            {
                GameDatabase.Add(new WiiUDiskViewModel(file));
            }
            OnPropertyChanged(nameof(GameDatabase));
            SaveGameDatabase();
        }
    }
}

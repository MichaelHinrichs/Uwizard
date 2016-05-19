using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Gat.Controls;
using Gat.Controls.Model;
using UwizardWPF.Resources.Languages;

namespace UwizardWPF.ViewModel
{
    public class GameManagementViewModel : TabViewModel
    {
        private static string[] _gx2SubFolders = { "code", "content", "meta"};
        private ObservableCollection<WiiUDiskViewModel> _gameCollection; 
        public ObservableCollection<WiiUDiskViewModel> GameCollection
        {
            get { return _gameCollection; }
            set { Set(ref _gameCollection, value); }
        }

        private WiiUDiskViewModel _selectedItem;
        public WiiUDiskViewModel SelectedItem
        {
            get { return _selectedItem; }
            set { Set(ref _selectedItem, value); }
        }

        private ICommand _gameTDBClickCommand;
        public ICommand GameTDBClickCommand => _gameTDBClickCommand ?? (_gameTDBClickCommand = new RelayCommand(LaunchGameTDB));

        private ICommand _addFolderCommand;
        public ICommand AddFolderCommand => _addFolderCommand ?? (_addFolderCommand = new RelayCommand(AddFolder));

        private void AddFolder()
        {
            var dialog = new OpenDialogView();
            var dialogViewModel = (OpenDialogViewModel)dialog.DataContext;
            dialogViewModel.IsDirectoryChooser = true;
            dialogViewModel.Caption = Strings.FolderOpen;
            dialogViewModel.StartupLocation = WindowStartupLocation.CenterScreen;

            if (dialogViewModel.Show() ?? false)
            {
                AddGameFolder(dialogViewModel.SelectedFolder);
            }
        }

        private void AddGameFolder(OpenFolderItem selectedFolder)
        {
            var folders = selectedFolder.Children.ToList();
            folders.Add(selectedFolder);
            folders = folders.Where(x => Regex.Match(x.Name, @"\[([^)]*)\]").Success).ToList();

            var gx2Folders = ValidGX2Folders(folders);

            //wudlist_fullpaths.AddRange(folders);
            //wudlist.Items.AddRange(folders.Select(x => x.Replace(Path.GetDirectoryName(x) + Path.DirectorySeparatorChar, "")).ToArray());
        }

        private IEnumerable<OpenFolderItem> ValidGX2Folders(List<OpenFolderItem> folders)
        {
            return folders.Where(x => !_gx2SubFolders.Except(x.Children.Select(c => c.Name)).Any());
        }

        private void LaunchGameTDB()
        {
            throw new NotImplementedException();
        }

        public GameManagementViewModel(string header) : base(header)
        {
            _gameCollection = new ObservableCollection<WiiUDiskViewModel>();
        }
    }
}

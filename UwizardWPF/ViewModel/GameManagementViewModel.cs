using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace UwizardWPF.ViewModel
{
    public class GameManagementViewModel : TabViewModel
    {
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

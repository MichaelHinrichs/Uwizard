using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace UwizardWPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<TabViewModel> _tabs;
        public ObservableCollection<TabViewModel> Tabs
        {
            get { return _tabs;}
            set { Set(ref _tabs, value); }
        } 

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _tabs = new ObservableCollection<TabViewModel>();
            Tabs.Add(new GameManagementViewModel("Games"));
        }
    }
}
using System;
using GalaSoft.MvvmLight;

namespace UwizardWPF.ViewModel
{
    public class TabViewModel : ViewModelBase
    {
        private string _header;

        public string Header
        {
            get { return _header; }
            set { Set(ref _header, value); }
        }
    }
}

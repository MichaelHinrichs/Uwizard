using System;
using GalaSoft.MvvmLight;

namespace UwizardWPF.ViewModel
{
    public class TabViewModel : ViewModelBase
    {
        public string Header { get; }

        protected TabViewModel(string header)
        {
            Header = header;
        }
    }
}

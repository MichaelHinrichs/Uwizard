using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Uwizard.Annotations;

namespace Uwizard.App.Models
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public abstract Control View();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

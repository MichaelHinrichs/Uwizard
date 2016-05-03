using Uwizard.App.Models;

namespace Uwizard.App.Views
{
    public interface IView<TViewModel> where TViewModel : BaseViewModel
    {
        TViewModel ViewModel { get; set; }
    }
}

using System.Collections.Generic;
using System.Windows.Forms;

namespace Uwizard.App.Models
{
    public class MainFormViewModel : BaseViewModel
    {
        public ICollection<BaseViewModel> Views { get; set; }

        public MainFormViewModel()
        {
            Views = new List<BaseViewModel>();
        }

        public override Control View()
        {
            throw new System.NotImplementedException();
        }
    }
}

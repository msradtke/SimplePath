using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
namespace SimplePath.ViewModels
{
    [ImplementPropertyChanged]
    public class MainContainerViewModel
    {
        public MainContainerViewModel()
        {
            LinePathSetupViewModel = new LinePathSetupViewModel();
            OutputViewModel = new OutputViewModel();
            PathsViewModel = new PathsViewModel();
        }
        public object LinePathSetupViewModel { get; set; }
        public object OutputViewModel { get; set; }
        public object PathsViewModel { get; set; }

    }
}

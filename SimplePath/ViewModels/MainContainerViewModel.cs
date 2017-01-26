using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Prism.Events;
namespace SimplePath.ViewModels
{
    [ImplementPropertyChanged]
    public class MainContainerViewModel
    {
        public MainContainerViewModel()
        {
            var eventAggregator = new EventAggregator();
            LinePathSetupViewModel = new LinePathSetupViewModel(eventAggregator);
            OutputViewModel = new OutputViewModel(eventAggregator);
            PathsViewModel = new PathsViewModel(eventAggregator);
        }
        public object LinePathSetupViewModel { get; set; }
        public object OutputViewModel { get; set; }
        public object PathsViewModel { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using PropertyChanged;
namespace SimplePath.ViewModels
{
    [ImplementPropertyChanged]
    public class OutputViewModel
    {
        EventAggregator _eventAggregator;
        public OutputViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OutputSetEvent>().Subscribe(OutputSet);

        }
        public string Output { get; set; }

        private void OutputSet(string output)
        {
            Output = output;
        }
    }
}

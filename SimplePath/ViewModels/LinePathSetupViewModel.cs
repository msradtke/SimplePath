using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using SimplePath.Models;
namespace SimplePath.ViewModels
{
    public class LinePathSetupViewModel
    {
        EventAggregator _eventAggregator;
        public LinePathSetupViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public LinePath GetCurrentLine()
        {
            var linePath = new LinePath();

            return linePath;
        }
        public void AddLineCommand()
        {
            _eventAggregator.GetEvent<LineAddedEvent>().Publish(GetCurrentLine());
        }
    }
}

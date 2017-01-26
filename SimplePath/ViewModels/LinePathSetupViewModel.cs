using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using SimplePath.Models;
using System.Windows.Input;
using PropertyChanged;
namespace SimplePath.ViewModels
{
    [ImplementPropertyChanged]
    public class LinePathSetupViewModel
    {
        EventAggregator _eventAggregator;
        public LinePathSetupViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            ActiveLinePath = new LinePath();

            //test
            AddLineCommand = new ActionCommand(AddLine);
        }
        public ICommand AddLineCommand { get; private set; }
        public double ClearanceHeight
        {
            get { return Machine.ClearanceHeight; }
            set
            {
                if (Machine.ClearanceHeight != value)
                {
                    Machine.ClearanceHeight = value;
                }
            }
        }
        public double FinishX
        {
            get { return Machine.EndX; }
            set
            {
                if (Machine.EndX != value)
                {
                    Machine.EndX = value;
                }
            }
        }
        public double FinishY
        {
            get { return Machine.EndY; }
            set
            {
                if (Machine.EndY != value)
                {
                    Machine.EndY = value;
                }
            }
        }
        public LinePath ActiveLinePath { get; set; }
        public IEnumerable<CutMethod> CutMethodTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(CutMethod))
                    .Cast<CutMethod>();
            }
        }
        public void AddLine()
        {
            _eventAggregator.GetEvent<LineAddedEvent>().Publish(ActiveLinePath);
            ActiveLinePath = new LinePath();
        }
    }
}

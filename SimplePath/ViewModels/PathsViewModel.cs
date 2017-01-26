using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplePath.Models;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace SimplePath.ViewModels
{
    public class PathsViewModel
    {
        EventAggregator _eventAggregator;
        public PathsViewModel(EventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<LineAddedEvent>().Subscribe(LineAdded);
            LinePaths = new ObservableCollection<LinePath>();

            GenerateCommand = new ActionCommand(Generate);
        }
        public ICommand GenerateCommand { get; private set; }
        public ObservableCollection<LinePath> LinePaths { get; set; }

        private void LineAdded(LinePath linePath)
        {
            if (String.IsNullOrWhiteSpace(linePath.Name))
                linePath.Name = "LinePath " + (LinePaths.Count+1);
            LinePaths.Add(linePath);
        }

        private void Generate()
        {
            var gen = new Generator();
            gen.Generate(LinePaths.ToList());
            _eventAggregator.GetEvent<OutputSetEvent>().Publish(gen.Output);
        }
    }
}

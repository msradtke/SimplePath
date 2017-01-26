using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PropertyChanged;
namespace SimplePath.Models
{
    [ImplementPropertyChanged]
    public class LinePath
    {
        public LinePath()
        {
            CutMethod = CutMethod.TwoWay;
        }
        public double StartX { get; set; }
        public double StartY { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public double StartZ { get; set; }
        public double EndZ { get; set; }
        public double DepthOfCut { get; set; }
        public CutMethod CutMethod { get; set; }
        public string Name { get; set; }
    }
    public enum CutMethod { OneWay, TwoWay };
}

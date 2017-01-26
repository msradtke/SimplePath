using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace SimplePath.Models
{
    public class LinePath
    {
        public Vector Start { get; set; }
        public Vector End { get; set; }
        public double Depth { get; set; }
        public CutMethod CutMethod { get; set; }

        
    }
    public enum CutMethod { OneWay, TwoWay };
}

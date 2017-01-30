using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Events;
namespace SimplePath.Models
{
    public class Generator
    {
        List<LinePath> _linePaths;
        public Generator()
        {

        }
        public string Output { get; set; }
        public void Generate(List<LinePath> linePaths)
        {
            _linePaths = linePaths;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Machine.Preamble);
            
            foreach(var linePath in _linePaths)
            {
               
                int passes = CalculatePasses(linePath);
                double passDepth = GetPassDepth(linePath, passes);
                sb.AppendLine(Machine.MoveToClearanceHeight());
                sb.AppendLine(Machine.MoveXY(linePath.StartX, linePath.StartY));

                double currentCutDepth = linePath.StartZ - passDepth;
                double startX = linePath.StartX;
                double startY = linePath.StartY;
                double endX = linePath.EndX;
                double endY = linePath.EndY;
                for (int i =0;i< passes;++i)
                {
                    if (i == passes - 1)
                        currentCutDepth = linePath.EndZ;
                    else if (i > 0)
                        currentCutDepth -= passDepth;
                    sb.AppendLine(Machine.CutZ(currentCutDepth));
                    sb.AppendLine(Machine.CutXY(endX, endY));
                    double endXCopy = endX;
                    double endYCopy = endY;
                    endX = startX;
                    endY = startY;
                    startX = endXCopy;
                    startY = endYCopy;                    
                }
            }
            sb.AppendLine(Machine.Postamble);
            Output = sb.ToString();
        }

        private int CalculatePasses(LinePath linePath)
        {
            var numOfPasses = Convert.ToInt32(Math.Ceiling((linePath.StartZ - linePath.EndZ) / linePath.DepthOfCut));
            return numOfPasses;
        }

        private double GetPassDepth(LinePath linePath, int totalPasses)
        {
            double totalDepth = linePath.StartZ - linePath.EndZ;
            double depth = totalDepth / totalPasses;
            return depth;
        }
    }
}

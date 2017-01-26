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
    static class Machine
    {
        static Machine()
        {

        }
        public static double EndX { get; set; }
        public static double EndY { get; set; }
        public static string Preamble { get { return SetPreamble(); } }
        public static string Postamble { get { return SetPostamble(); } }
        public static double ClearanceHeight { get; set; }
        public static string Move(double x,double y,double z)
        {
            return "G00 X" + x.ToString("f5") + " Y" + y.ToString("f5") + " Z" + z.ToString("f5");
        }
        public static string MoveZ(double z)
        {
            return "G00 Z" + z.ToString("f5");
        }
        public static string MoveToClearanceHeight()
        {
            return "G00 Z" + ClearanceHeight.ToString("f5");
        }
        public static string MoveXY(double x, double y)
        {
            return "G00 X" + x.ToString("f5") + " Y" + y.ToString("f5");
        }
        public static string Cut(double x, double y, double z)
        {
            return "G01 X" + x.ToString("f5") + " Y" + y.ToString("f5") + " Z" + z.ToString("f5");
        }
        public static string CutZ(double z)
        {
            return "G01 Z" + z.ToString("f5");
        }
        public static string CutXY(double x, double y)
        {
            return "G01 X" + x.ToString("f5") + " Y" + y.ToString("f5");
        }

        private static string SetPreamble()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("G17 G90"); //plane and distance mode
            sb.AppendLine("G20"); //standard units
            sb.AppendLine("M6 T1.0");  //tool change
            sb.AppendLine("M3 S15000.0000"); //spindle clockwise with speed
            return sb.ToString();
        }
        private static string SetPostamble()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MoveToClearanceHeight());
            sb.AppendLine("M05"); //stop spindle
            sb.AppendLine(MoveXY(EndX, EndY)); //move to end location
            sb.AppendLine("G17 G90");  //reset these
            sb.AppendLine("M2"); //End program
            return sb.ToString();
        }
    }
}

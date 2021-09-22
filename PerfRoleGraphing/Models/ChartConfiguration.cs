using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRoleGraphing.Models;
using PerfRoleGraphing.CSVManagement;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerfRoleGraphing.Models
{
    public class ChartConfiguration
    {
        public string File { get; set; }
        public string Role { get; set; }
        public string OutFile { get; set; }
        public string Counter { get; set; }
        public string YAxis { get; set; }
        public double Scale { get; set; }
        public double Interval { get; set; }
        public int FullLoadTime { get; set; }
    }
}

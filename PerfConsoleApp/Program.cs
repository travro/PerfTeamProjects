using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRoleGraphing;
using PerfRoleGraphing.Models;

namespace PerfConsoleApp
{
    class Program
    {      
        static void Main(string[] args)
        {
            //Memory\Committed MBytes
            try
            {
                var chartConfiguration1 = new ChartConfiguration() 
                {
                    File = @"C:\Users\tsmelvin\Desktop\PR-UUD46.csv",
                    OutFile = @"C:\Users\tsmelvin\Desktop\UUD-46.png",
                    Role = "PR-UUD46",
                    Counter = @"Processor(_Total)\% Processor Time",
                    YAxis = "CPU Time",
                    Scale = 100.0,
                    Interval = 10.0,
                    FullLoadTime = 40
                };

                var chartMaker = new ChartMaker(chartConfiguration1);
                chartMaker.SaveChart();
                
              /* var chartConfiguration2 = new ChartConfiguration()
                {
                    File = @"C:\Users\tsmelvin\Desktop\PR-UUD23.csv",
                    OutFile = @"C:\Users\tsmelvin\Desktop\PR-UUD23_ram.png",
                    Role = "PR-UUD23",
                    Counter = @"Memory\Committed MBytes",
                    Scale = 3277.0,
                    Interval = 200.0,
                    FullLoadTime = 30
                };

                chartMaker = new ChartMaker(chartConfiguration2);
                chartMaker.SaveChart();*/


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}

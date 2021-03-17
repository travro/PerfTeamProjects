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
                    File = @"C:\Users\tsmelvin\Desktop\PR-UUD43.csv",
                    OutFile = @"C:\Users\tsmelvin\Desktop\PR-UUD43_cpu.jpeg",
                    Role = "PR-UUD43",
                    Counter = @"Processor(_Total)\% Processor Time",
                    Scale = 100.0,
                    Interval = 10.0,
                    FullLoadTime = 40
                };

                var chartMaker = new ChartMaker(chartConfiguration1);
                chartMaker.SaveChart();
                
                var chartConfiguration2 = new ChartConfiguration()
                {
                    File = @"C:\Users\tsmelvin\Desktop\PR-UUD43.csv",
                    OutFile = @"C:\Users\tsmelvin\Desktop\PR-UUD43_ram.jpeg",
                    Role = "PR-UUD43",
                    Counter = @"Memory\Committed MBytes",
                    Scale = 32770.0,
                    Interval = 2000.0,
                    FullLoadTime = 40
                };

                chartMaker = new ChartMaker(chartConfiguration2);
                chartMaker.SaveChart();


                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

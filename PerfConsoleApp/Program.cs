using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRoleGraphing;

namespace PerfConsoleApp
{
    class Program
    {      
        static void Main(string[] args)
        {
            var pathIn = @"C:\Users\tsmelvin\Desktop\PR-UUD43.csv";
            var pathOut = @"C:\Users\tsmelvin\Desktop\PR-UUD43.jpeg";
            var role = "PR-UUD43";

            try
            {
                var fileProcessor = new FileProcessor();
                //fileProcessor.Process(role, pathIn, pathOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

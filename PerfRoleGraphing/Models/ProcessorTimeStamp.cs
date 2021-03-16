using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;


namespace PerfRoleGraphing.Models
{
    public class ProcessorTimeStamp
    {
        public DateTime TimeStamp {  get; set; }
        public double ProcessorTime {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfRoleGraphing.Models.ClassMaps
{
    internal class TotalProcessClassMap : PerfRecordMap
    {
        public TotalProcessClassMap() : base(@"Processor(_Total)\% Processor Time") { }
    }
}

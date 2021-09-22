using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRepoTabler.Models;

namespace PerfRepoTabler
{
    public static class StaticTableFactory
    {
        public static DataTable GetBlankSummaryTable()
        {
            var t =  new PerfSummaryTable();
            return t.GetTable();
        }

        public static PerfDetailsTable GetPerformanceDetailsTable()
        {
            return new PerfDetailsTable();
        }
    }
}

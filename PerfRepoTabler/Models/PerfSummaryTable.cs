using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfRepoTabler.Models
{
    public class PerfSummaryTable
    {
        public  DataTable GetTable()
        {
            var table = new DataTable();
            table.Columns.Add("Test Status");
            table.Columns.Add("");
            table.Rows.Add("Summary", "");
            table.Rows.Add("Next Steps");
            return table;
        }
    }
}

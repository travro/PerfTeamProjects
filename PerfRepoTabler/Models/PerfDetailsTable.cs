using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfRepoTabler.Models
{
    public class PerfDetailsTable
    {
        private DataTable _table;
        public string BaseRepID { private get; set; } = "";
        public string CurrentRepID { private get; set; } = "";
        public string PatchData { private get; set; } = "";
        public string EnvironmentConfig { private get; set; } = "";
        public IEnumerable<int> RampConfig { private get; set; }
        public int DatabaseGB { private get; set; } = 32;
        public string RepoURL { private get; set; } = @"http://pr-rptdev/reports/browse/Performance%20Lab%20Test%20Reports;";
        public string RepoCredentials { private get; set; } = "reportuser/titan#12";
        public string JiraTickets { private get; set; } = "";

        public DataTable GetTable()
        {
            _table = new DataTable();
            _table.Columns.Add("Value");
            _table.Columns.Add("Description");
            //_table.Rows.Add("Value", "Description");
            _table.Rows.Add("Baseline Test and Log locations", $"RepID - {BaseRepID}");
            _table.Rows.Add("Current Test  and log location ", $"RepID - {CurrentRepID}");
            _table.Rows.Add("Raw Patches applied ( Web /DB )", PatchData);
            _table.Rows.Add("Configuration Changes", EnvironmentConfig);

            var testRampDesc = "Total Test Duration and Breakup";

            if (RampConfig?.Count() == 3)
            {
                _table.Rows.Add(testRampDesc, $"{RampConfig.Sum()} ({RampConfig.ElementAt(0)} Ramp-Up + {RampConfig.ElementAt(1)} Full Load + {RampConfig.ElementAt(2)} Ramp-Down)");
            }
            else
            {
                _table.Rows.Add(testRampDesc, "Ramp configuration must be an array or list of three integer values");
            }

            _table.Rows.Add("DB size", DatabaseGB);
            _table.Rows.Add("Performance Results Site", RepoURL);
            _table.Rows.Add("Performance Results Site Login", RepoCredentials);
            _table.Rows.Add("Jira Tickets Covered", JiraTickets);

            return _table;
        }

        public string GetHTMLTable()
        {
            StringBuilder tableBuilder = new StringBuilder();

            tableBuilder.Append("<table>");
            tableBuilder.Append("<tr><td>Value</td><td>Description</td></tr>");
            tableBuilder.Append($"<tr><td>BaseRepID</td><td>{BaseRepID}</td></tr>");
            tableBuilder.Append($"<tr><td>CurrentRepID</td><td>{CurrentRepID}</td></tr>");
            tableBuilder.Append($"<tr><td>Any raw patches applied ( web /DB )</td><td>{PatchData}</td></tr>");
            tableBuilder.Append($"<tr><td>Configuration Changes</td><td>{EnvironmentConfig}</td></tr>");

            if(RampConfig != null && RampConfig.Count() == 3)
            {
                tableBuilder.Append($"<tr><td>Test Duration (Breakup) </td><td>{RampConfig.Sum()} ({RampConfig.ElementAt(0)} Ramp-Up + {RampConfig.ElementAt(1)} Full Load + {RampConfig.ElementAt(2)} Ramp-Down)</td></tr>");
            }
            else
            {
                tableBuilder.Append($"<tr><td>Test Duration (Breakup) </td><td>Ramp configuration must be an array or list of three integer values</td></tr>");
            }

            tableBuilder.Append($"<tr><td>UUD DB Size</td><td>{DatabaseGB} GB</td></tr>");
            tableBuilder.Append($"<tr><td>Performance Results Site </td><td>{RepoURL}</td></tr>");
            tableBuilder.Append($"<tr><td>Performance Results Login Credentials </td><td>{RepoCredentials}</td></tr>");
            tableBuilder.Append($"<tr><td>Jira Tickets Covered</td><td>{JiraTickets}</td></tr>");
            tableBuilder.Append("</table>");

            return tableBuilder.ToString();
        }
    }
}

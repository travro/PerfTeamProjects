using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRoleGraphing.Models;
using PerfRoleGraphing.CSVManagement;

namespace PerfRoleGraphing
{
    public class ChartMaker
    {
        private PerfChart _perfChart;
        private ChartConfiguration _configuration;
        private bool _configurationComplete = false;
        private IEnumerable<PerfRecordItem> _records;
        private RecordSelector _selector;
        public ChartMaker(ChartConfiguration configuration)
        {
            var list = new List<string>() 
            { 
                configuration.File, 
                configuration.Role, 
                configuration.OutFile, 
                configuration.Counter, 
                configuration.Scale.ToString(), 
                configuration.Interval.ToString(), 
                configuration.FullLoadTime.ToString()
            };

            _configurationComplete = list.Any(configProp => !String.IsNullOrEmpty(configProp) && !String.IsNullOrWhiteSpace(configProp));
            _configuration = configuration;
            SelectRecords();
            MakeChart();
        }

        private void SelectRecords()
        {
            if (_configurationComplete)
            {
                _selector = new RecordSelector(_configuration.File);

                if (_configuration.Counter.Contains("Processor"))
                {
                    _records = _selector.GetFullTestRecords(new PerfRecordMap($"\\\\{_configuration.Role}\\Processor(_Total)\\% Processor Time"));
                }
                else if(_configuration.Counter.Contains("Memory"))
                {
                    _records = _selector.GetFullTestRecords(new PerfRecordMap($"\\\\{_configuration.Role}\\Memory\\Committed Bytes"));

                    foreach (var rec in _records)
                    {
                        rec.Value /= 10000000.0;
                    }
                }
                else
                {
                    _records = new List<PerfRecordItem>();
                }
            }
        }

        private bool MakeChart()
        {
            if(_configurationComplete)
            {
                _perfChart = new PerfChart(_configuration, _records);
            }
            return _perfChart != null;
        }

        public bool SaveChart()
        {
            if(_perfChart != null)
            {
                _perfChart.SaveChart();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

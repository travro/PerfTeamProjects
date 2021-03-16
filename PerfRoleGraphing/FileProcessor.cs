using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerfRoleGraphing.Models;
using PerfRoleGraphing.CSVManagement;
using PerfRoleGraphing.Charting;
using System.Windows.Forms.DataVisualization.Charting;

namespace PerfRoleGraphing
{
    public class FileProcessor
    {
        private string _file;
        private string _role;
        private string _pathOut;
        private string _counter;
        private int _scale;
        private int _interval;
        private PerfChart _chart;

        public FileProcessor Read(string file)
        {
            _file = file;
            return this;
        }

        public FileProcessor ForTheRole(string role)
        {
            _role = role;
            return this;
        }

        public FileProcessor ForCounter(string counter, int scale, int interval)
        {
            _counter = counter; _scale = scale; _interval = interval;
            return this;
        }

        public FileProcessor AndSendTo(string pathOuth)
        {
            _pathOut = pathOuth;
            return this;
        }
        public string MakeChartImage()
        {
            var list = new List<string>() { _file, _role, _pathOut, _counter, _scale.ToString(), _interval.ToString() };

            if(list.Any(e => String.IsNullOrEmpty(e) || string.IsNullOrWhiteSpace(e)))
            {
                var message = "Meta data missing. Please be sure to call methods ForTheRole(string), ForConter(string, int scale, int interval), and AndSendTo(filePathOut) on this object before MakeChartImage()";
                throw new Exception(message);
            }
            else
            {

                //get correct mapping for records, 

                /**
                 * left off here, need a dynamic map chooser to get the correct recordlist, PerfChart may be fine though
                 */
                var reader = new FileReader(_file);
                var recs = reader.GetTotalProcessorTime();

                //call graphing class(es) with stamps as arguments
                _chart = new PerfChart(recs, "UUD", "Processor(_Total)\\%PRocessor Time", 30);
            }

            if (_chart != null)
            {
                if (String.IsNullOrWhiteSpace(_pathOut))
                {
                    _chart.SaveChart(_pathOut);
                }
                else
                {
                    _chart.SaveChart(_file);
                }
                return "processed";
            }
            else
            {
                return "no chart has been constructed";
            }
        }

    }
}

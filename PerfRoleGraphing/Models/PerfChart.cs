using PerfRoleGraphing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.IO;

namespace PerfRoleGraphing.Models
{
    internal class PerfChart
    {
        private ChartConfiguration _chartConfig;
        private Chart _chart;
        public PerfChart(ChartConfiguration configuration, IEnumerable<PerfRecordItem> records)
        {
            _chartConfig = configuration;
            _chart = new Chart();

            var font = new Font("Arial", 14, FontStyle.Bold);
            _chart.ClientSize = new Size(1900, 800);

            var titleText = $"{_chartConfig.Role} at Highest Concurrency";

            var title = new Title()
            {
                Text = (_chartConfig.FullLoadTime > 0) ? $"{titleText} for {_chartConfig.FullLoadTime} minutes" : titleText,
                Font = font
            };
            _chart.Titles.Add(title);

            var chartArea = new ChartArea();    
            chartArea.AxisX.TitleFont = font;
            chartArea.AxisX.LabelStyle.Format = "{H:mm:ss}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Title = _chartConfig.Counter;
            chartArea.AxisY.TitleFont = font;
            chartArea.AxisY.Maximum = _chartConfig.Scale;
            chartArea.AxisY.Interval = _chartConfig.Interval;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            _chart.ChartAreas.Add(chartArea);

            var series = new Series() { ChartType = SeriesChartType.Line, BorderWidth = 2 };
            series.IsVisibleInLegend = false;
            series.XValueType = ChartValueType.DateTime;
            series.YValueType = ChartValueType.Double;

            int i = 0;

            foreach (var rec in records)
            {                
                if (i++ % 5 == 0) 
                {
                    series.Points.AddXY(rec.TimeStamp, rec.Value);
                }
            }
            _chart.Series.Add(series);
        }

        public void SaveChart()
        {
            if (_chart != null)
            {
                using (var filewriter = new FileStream(_chartConfig.OutFile, FileMode.Create))
                {
                    _chart.SaveImage(filewriter, ChartImageFormat.Png);
                };
            }
        }
    }
}

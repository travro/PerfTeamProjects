using PerfRoleGraphing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.IO;

namespace PerfRoleGraphing.Charting
{
    public class PerfChart
    {
        private Chart _chart = new Chart();

        public PerfChart(IEnumerable<PerfRecordItem> records, string role, string yAxisTitle, int fullLoadTime = 0)
        {
            var font = new Font("Arial", 14, FontStyle.Bold);
            _chart.ClientSize = new Size(1900, 800);

            var titleText = $"{role} at Highest Concurrency";

            var title = new Title()
            {
                Text = (fullLoadTime != 0) ? titleText + $"for {fullLoadTime} minutes" : titleText,
                Font = font
            };
            _chart.Titles.Add(title);

            var chartArea = new ChartArea();    
            chartArea.AxisX.TitleFont = font;
            chartArea.AxisX.Interval = 0.0;
            chartArea.AxisX.LabelStyle.Format = "{hh:mm:ss}";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Title = yAxisTitle;
            chartArea.AxisY.TitleFont = font;
            chartArea.AxisY.Maximum = 100.0;
            chartArea.AxisY.Interval = 10.0;
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

        public void SaveChart(string outpath)
        {
            if (_chart != null)
            {
                using (var filewriter = new FileStream(outpath, FileMode.Create))
                {
                    _chart.SaveImage(filewriter, ChartImageFormat.Png);
                };
            }
        }
    }
}

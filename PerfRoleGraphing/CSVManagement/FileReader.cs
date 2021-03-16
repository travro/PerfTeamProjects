using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using PerfRoleGraphing.Models;


namespace PerfRoleGraphing.CSVManagement
{
    public class FileReader
    {
        private string _filepath;
        /// <summary>
        /// Returns a list of objects containing the Timestamps and Total CPU Time of the Perfmon File
        /// </summary>
        /// <returns></returns>
        private IEnumerable<PerfRecordItem> GetFullTestRecords<T>() where T: PerfRecordMap
        {
            using (var reader = new StreamReader(_filepath))
            {
                using (var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<T>();
                    return csvReader.GetRecords<PerfRecordItem>().ToList();
                }
            }
        }
        public FileReader(string filePath) { _filepath = filePath; }
        public IEnumerable<PerfRecordItem> GetTotalProcessorTime()
        {
            return GetFullTestRecords<TotalProcMap>();
        }
        public IEnumerable<PerfRecordItem> GetCommittedMemoryBytes()
        {
            return GetFullTestRecords<ComBytesClassMap>();
        }
    }
}

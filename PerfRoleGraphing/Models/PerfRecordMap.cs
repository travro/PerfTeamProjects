using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace PerfRoleGraphing.Models
{
    internal class PerfRecordMap : ClassMap<PerfRecordItem>
    {
        public PerfRecordMap(string name)
        {
            Map(member => member.TimeStamp)
                .Index(0)
                .TypeConverter<DateTimeConverter>();
            Map(member => member.Value)
                .Name(name)
                .Default(0.0)
                .Convert(d =>
                {
                    if (Double.TryParse(d.Row.GetField(name), out double result))
                    {
                        return result;
                    }
                    else
                    {
                        return 0.0;
                    }
                });
        }
    }

}

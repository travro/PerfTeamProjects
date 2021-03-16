using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace PerfRoleGraphing.Models
{
    public abstract class PerfRecordMap : ClassMap<PerfRecordItem>
    {
        public PerfRecordMap(int index)
        {
            Map(member => member.TimeStamp)
                .Index(0)
                .TypeConverter<DateTimeConverter>();
            Map(member => member.Value)
                .Index(index)
                .Default(0.0)
                .Convert(d =>
                {
                    if (Double.TryParse(d.Row.GetField(index), out double result))
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

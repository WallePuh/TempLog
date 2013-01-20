using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TempLog.TdTool.Result
{
    public class SensorResult
    {
        public SensorResult()
        {

        }

        public SensorResult(List<string> columns)
        {
            Protocol = columns[0];
            Model = columns[1];
            SensorId = Int32.Parse(columns[2]);
            Temp = ParseTemp(columns[3]);
            Humidity = ParseHumidity(columns[4]);
            LastUpdated = DateTime.Parse(columns[5]);
        }

        public string Protocol { get; set; }
        public string Model { get; set; }
        public int SensorId { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public DateTime LastUpdated { get; set; }

        public static double ParseTemp(string text)
        {
            return Double.Parse(Regex.Replace(text, @"[^\d\.]", ""), CultureInfo.InvariantCulture);
        }

        public static int ParseHumidity(string text)
        {
            return Int32.Parse(Regex.Replace(text, @"\D", ""), CultureInfo.InvariantCulture);
        }
    }
}

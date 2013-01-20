using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TempLog.TdTool.Result;

namespace TempLog.TdTool.Ssh.Deserializer
{
    public interface ISensorListDeserializer
    {
        List<SensorResult> Deserialize(string text);
        string GetSensorTextBlock(string text);
    }

    public class SensorListDeserializer : ISensorListDeserializer
    {
        public List<SensorResult> Deserialize(string text)
        {
            var sensors = text.Split('\n')
                .Where(row => !String.IsNullOrWhiteSpace(row))
                .Select(row =>
                {
                    var columns = row.Split('\t').Select(col => col.Trim()).ToList();
                    return new SensorResult(columns);
                });
            return sensors.ToList();
        }

        public string GetSensorTextBlock(string text)
        {
            var sensorText = string.Join("\n", text.Split('\n').Where(str => str.StartsWith("fineoffset"))) + "\n";

            return sensorText;
        }
    }
}

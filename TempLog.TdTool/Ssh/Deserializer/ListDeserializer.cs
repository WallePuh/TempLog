using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLog.TdTool.Ssh.Deserializer
{
    public class ListDeserializer
    {
        readonly ISensorListDeserializer sensorDeserializer;

        public ListDeserializer(ISensorListDeserializer _sensorDeserializer)
        {
            sensorDeserializer = _sensorDeserializer;
        }

        public Result.ListResult Deserialize(string text)
        {
            var result = new Result.ListResult();

            var sensorText = sensorDeserializer.GetSensorTextBlock(text);
            result.SensorResults = sensorDeserializer.Deserialize(sensorText);

            return result;
        }
    }
}

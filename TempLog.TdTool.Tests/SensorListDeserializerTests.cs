using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TempLog.TdTool.Result;
using TempLog.TdTool.Ssh.Deserializer;

namespace TempLog.TdTool.Tests
{
    [TestClass]
    public class SensorListDeserializerTests
    {
        public string TestText1 { get { return "Number of devices: 2\n1\tUppe\tOFF\n2\tNere\tOFF\n\n\nSENSORS:\n\nPROTOCOL            \tMODEL               \tID   \tTEMP \tHUMIDITY\tLAST UPDATED        \nfineoffset          \ttemperaturehumidity \t221  \t9.0°\t16%     \t2013-01-19 13:36:03 \nfineoffset          \ttemperaturehumidity \t189  \t6.5°\t255%    \t2013-01-19 13:35:41 \nfineoffset          \ttemperaturehumidity \t87   \t6.6°\t255%    \t2013-01-19 13:35:39 \nfineoffset          \ttemperaturehumidity \t93   \t7.2°\t1%      \t2012-11-18 00:09:51 \nfineoffset          \ttemperaturehumidity \t39   \t6.6°\t255%    \t2013-01-12 02:05:03 \nfineoffset          \ttemperaturehumidity \t255  \t-20.9°\t255%    \t2013-01-10 08:41:49 \nfineoffset          \ttemperaturehumidity \t23   \t6.6°\t255%    \t2013-01-12 01:29:51 \n\n"; } }

        public string TestTextSensors1 { get { return "fineoffset          \ttemperaturehumidity \t221  \t9.0°\t16%     \t2013-01-19 13:36:03 \n"; } }
        public List<SensorResult> Sensors1
        {
            get
            {
                return new List<SensorResult> { 
            new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 221, Temp = 9, Humidity = 16, LastUpdated = new DateTime(2013, 01, 19, 13, 36, 03) } };
            }
        }
        public string TestTextSensors2 { get { return "fineoffset          \ttemperaturehumidity \t221  \t9.0°\t16%     \t2013-01-19 13:36:03 \nfineoffset          \ttemperaturehumidity \t189  \t6.5°\t255%    \t2013-01-19 13:35:41 \nfineoffset          \ttemperaturehumidity \t87   \t6.6°\t255%    \t2013-01-19 13:35:39 \nfineoffset          \ttemperaturehumidity \t93   \t7.2°\t1%      \t2012-11-18 00:09:51 \nfineoffset          \ttemperaturehumidity \t39   \t6.6°\t255%    \t2013-01-12 02:05:03 \nfineoffset          \ttemperaturehumidity \t255  \t-20.9°\t255%    \t2013-01-10 08:41:49 \nfineoffset          \ttemperaturehumidity \t23   \t6.6°\t255%    \t2013-01-12 01:29:51 \n"; } }
        public List<SensorResult> Sensors2
        {
            get
            {
                return new List<SensorResult> { 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 221, Temp = 9, Humidity = 16, LastUpdated = new DateTime(2013, 01, 19, 13, 36, 03) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 189, Temp = 6.5, Humidity = 255, LastUpdated = new DateTime(2013, 01, 19, 13, 35, 41) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 87, Temp = 6.6, Humidity = 255, LastUpdated = new DateTime(2013, 01, 19, 13, 35, 39) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 93, Temp = 7.2, Humidity = 1, LastUpdated = new DateTime(2012, 11, 18, 00, 09, 51) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 39, Temp = 6.6, Humidity = 255, LastUpdated = new DateTime(2013, 01, 12, 02, 05, 03) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 255, Temp = 20.9, Humidity = 255, LastUpdated = new DateTime(2013, 01, 10, 08, 41, 49) }, 
                    new SensorResult { Protocol = "fineoffset", Model = "temperaturehumidity", SensorId = 23, Temp = 6.6, Humidity = 255, LastUpdated = new DateTime(2013, 01, 12, 01, 29, 51) } 
                };
            }
        }

        [TestMethod]
        public void GetSensorTextBlock_CorrectTextString_StringWithSensorInfoOnly()
        {
            var text = TestText1;
            var expectedText = TestTextSensors2;
            var deserializer = new SensorListDeserializer();

            var actualText = deserializer.GetSensorTextBlock(text);

            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void Deserialize_SensorTextString_ListofSensors()
        {
            var text = TestTextSensors1;
            var expectedSensors = Sensors1;
            var deserializer = new SensorListDeserializer();

            var actualSensors = deserializer.Deserialize(text);

            Assert.AreEqual(expectedSensors.Count, actualSensors.Count);
            for (int i = 0; i < Math.Min(expectedSensors.Count, actualSensors.Count); i++)
            {
                Assert.AreEqual(expectedSensors[i].Protocol, actualSensors[i].Protocol);
                Assert.AreEqual(expectedSensors[i].Model, actualSensors[i].Model);
                Assert.AreEqual(expectedSensors[i].SensorId, actualSensors[i].SensorId);
                Assert.AreEqual(expectedSensors[i].Temp, actualSensors[i].Temp);
                Assert.AreEqual(expectedSensors[i].Humidity, actualSensors[i].Humidity);
                Assert.AreEqual(expectedSensors[i].LastUpdated, actualSensors[i].LastUpdated);
            }
        }

        [TestMethod]
        public void Deserialize_SensorTextString2_ListofSensors()
        {
            var text = TestTextSensors2;
            var expectedSensors = Sensors2;
            var deserializer = new SensorListDeserializer();

            var actualSensors = deserializer.Deserialize(text);

            Assert.AreEqual(expectedSensors.Count, actualSensors.Count);
            for (int i = 0; i < Math.Min(expectedSensors.Count, actualSensors.Count); i++)
            {
                Assert.AreEqual(expectedSensors[i].Protocol, actualSensors[i].Protocol);
                Assert.AreEqual(expectedSensors[i].Model, actualSensors[i].Model);
                Assert.AreEqual(expectedSensors[i].SensorId, actualSensors[i].SensorId);
                Assert.AreEqual(expectedSensors[i].Temp, actualSensors[i].Temp);
                Assert.AreEqual(expectedSensors[i].Humidity, actualSensors[i].Humidity);
                Assert.AreEqual(expectedSensors[i].LastUpdated, actualSensors[i].LastUpdated);
            }
        }
    }
}

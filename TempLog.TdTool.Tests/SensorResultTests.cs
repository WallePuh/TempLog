using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TempLog.TdTool.Result;

namespace TempLog.TdTool.Tests
{
	[TestClass]
	public class SensorResultTests
	{
		[TestMethod]
		public void ParseTemp_CorrectTempString_ADoubleTempValue()
		{
            var tempText = "8.9°";
            var expectedTemp = 8.9;

            var actualTemp = SensorResult.ParseTemp(tempText);

            Assert.AreEqual(expectedTemp, actualTemp);
		}

        [TestMethod]
        public void ParseHumidity_CorrectHumidityString_AInteger0To255()
        {
            var humidityText = "128%";
            var expectedHumidity = 128;

            var actualHumidity = SensorResult.ParseHumidity(humidityText);

            Assert.AreEqual(expectedHumidity, actualHumidity);
        }
	}
}

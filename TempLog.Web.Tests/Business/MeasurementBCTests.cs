using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TempLog.Web.Models;
using System.Collections.Generic;
using TempLog.Web.Business;

namespace TempLog.Web.Tests.Business
{
    [TestClass]
    public class MeasurementBCTests
    {
        [TestMethod]
        public void GetTimeDiffOfNearestMeasurement_ListWithOneTwoHoursOldMeasurement_TwoHours()
        {
            var measurementBc = new MeasurementBC(null);
            var dt = new DateTime(2013, 01, 01, 12, 00, 00);
            var measurementList = new List<Measurement>
            {
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 10, 00, 00) }
            };
            var expectedTimeSpan = new TimeSpan(2, 0, 0); // 2h

            var actualTimeSpan = measurementBc.GetTimeDiffOfNearestMeasurement(measurementList, dt);

            Assert.AreEqual(expectedTimeSpan, actualTimeSpan);
        }

        [TestMethod]
        public void GetTimeDiffOfNearestMeasurement_ListWithOneFutureTwoHoursMeasurement_TwoHours()
        {
            var measurementBc = new MeasurementBC(null);
            var dt = new DateTime(2013, 01, 01, 12, 00, 00);
            var measurementList = new List<Measurement>
            {
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 14, 00, 00) }
            };
            var expectedTimeSpan = new TimeSpan(2, 0, 0); // 2h

            var actualTimeSpan = measurementBc.GetTimeDiffOfNearestMeasurement(measurementList, dt);

            Assert.AreEqual(expectedTimeSpan, actualTimeSpan);
        }
        [TestMethod]
        public void GetTimeDiffOfNearestMeasurement_ListWithTwoOlderMeasurement_TwoHours()
        {
            var measurementBc = new MeasurementBC(null);
            var dt = new DateTime(2013, 01, 01, 12, 00, 00);
            var measurementList = new List<Measurement>
            {
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 10, 00, 00) },
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 08, 00, 00) },
            };
            var expectedTimeSpan = new TimeSpan(2, 0, 0); // 2h

            var actualTimeSpan = measurementBc.GetTimeDiffOfNearestMeasurement(measurementList, dt);

            Assert.AreEqual(expectedTimeSpan, actualTimeSpan);
        }

        [TestMethod]
        public void GetTimeDiffOfNearestMeasurement_ListWithOneFutureAndOneOldMeasurement_TwoHours()
        {
            var measurementBc = new MeasurementBC(null);
            var dt = new DateTime(2013, 01, 01, 12, 00, 00);
            var measurementList = new List<Measurement>
            {
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 14, 00, 00) },
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 08, 00, 00) }
            };
            var expectedTimeSpan = new TimeSpan(2, 0, 0); // 2h

            var actualTimeSpan = measurementBc.GetTimeDiffOfNearestMeasurement(measurementList, dt);

            Assert.AreEqual(expectedTimeSpan, actualTimeSpan);
        }

        [TestMethod]
        public void GetTimeDiffOfNearestMeasurement_ListWithTwoFutureMeasurement_TwoHours()
        {
            var measurementBc = new MeasurementBC(null);
            var dt = new DateTime(2013, 01, 01, 12, 00, 00);
            var measurementList = new List<Measurement>
            {
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 16, 00, 00) },
                new Measurement { LastUpdated = new DateTime(2013, 01, 01, 14, 00, 00) }
            };
            var expectedTimeSpan = new TimeSpan(2, 0, 0); // 2h

            var actualTimeSpan = measurementBc.GetTimeDiffOfNearestMeasurement(measurementList, dt);

            Assert.AreEqual(expectedTimeSpan, actualTimeSpan);
        }
    }
}

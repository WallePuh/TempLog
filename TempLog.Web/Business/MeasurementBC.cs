using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TempLog.Web.Models;

namespace TempLog.Web.Business
{
    public interface IMeasurementBC
    {
        IQueryable<Measurement> GetAll();
        void AddMeasurement(Measurement measurement);
    }

    public class MeasurementBC : BaseBC, IMeasurementBC
    {
        public MeasurementBC(ISensorBC sensorBC)
        {
            SensorBC = sensorBC;
        }

        public ISensorBC SensorBC { get; set; }

        public void AddMeasurement(Measurement measurement)
        {
            var modyfied = false;
            var sensor = SensorBC.GetSensor(measurement.SensorId);

            if (sensor == null)
            {
                sensor = new Sensor { TdSensorId = measurement.SensorId, Measurements = new List<Measurement>() };
                DbContext.Sensors.Add(sensor);
                modyfied = true;
            }

            var timeDiff = GetTimeDiffOfNearestMeasurement(sensor.Measurements, measurement.LastUpdated);

            if (timeDiff.TotalHours > 1) // TODO: get from application settings
            {
                sensor.Measurements.Add(measurement);
                modyfied = true;
            }

            if (modyfied)
                DbContext.SaveChanges();
        }

        public TimeSpan GetTimeDiffOfNearestMeasurement(ICollection<Measurement> measurements, DateTime dateTime)
        {
            if (measurements == null || !measurements.Any())
            {
                return TimeSpan.MaxValue;
            }

            var nearestOldMeasurement = measurements.Min(m => m.LastUpdated > dateTime ? m.LastUpdated - dateTime : dateTime - m.LastUpdated);

            return nearestOldMeasurement;
        }

        public IQueryable<Measurement> GetAll()
        {
            var all = DbContext.Measurements;
            return all;
        }
    }
}
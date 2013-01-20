using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TempLog.Web.Business
{
    public interface ISensorBC
    {
        IQueryable<Models.Sensor> GetSensors();
        IQueryable<Models.Sensor> GetSensors(Expression<Func<Models.Sensor, bool>> predicate);
        Models.Sensor GetSensor(int sensorId);
        Models.Sensor UpdateSensor(Models.Sensor sensor);
    }

    public class SensorBC : BaseBC, ISensorBC
    {
        public IQueryable<Models.Sensor> GetSensors()
        {
            return DbContext.Sensors;
        }

        public IQueryable<Models.Sensor> GetSensors(Expression<Func<Models.Sensor, bool>> predicate)
        {
            return DbContext.Sensors.Where(predicate);
        }

        public Models.Sensor GetSensor(int sensorId)
        {
            return DbContext.Sensors.SingleOrDefault(s => s.TdSensorId == sensorId);
        }

        public Models.Sensor UpdateSensor(Models.Sensor sensor)
        {
            DbContext.Sensors.Attach(sensor);
            DbContext.SaveChanges();

            return sensor;
        }
    }
}
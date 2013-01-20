using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TempLog.Web.Business;
using TempLog.Web.Models;

namespace TempLog.Web.Controllers
{
    /// <summary>
    /// A sensor controller that only can post new sensor readings, get all sensor readings and sensor readings for one of the sensors. 
    /// </summary>
    public class SensorController : ApiController
    {
        public ISensorBC SensorBC { get; set; }

        public SensorController()
        {
            SensorBC = new SensorBC();
        }

        public SensorController(ISensorBC sensorBC)
        {
            SensorBC = SensorBC;
        }

        public IQueryable<Sensor> Get()
        {
            return SensorBC.GetSensors();
        }

        public Sensor GetBySensorId(int id)
        {
            return Get().SingleOrDefault(s => s.TdSensorId == id);
        }

        public Sensor Post(Sensor sensor)
        {
            return null;
        }
    }
}

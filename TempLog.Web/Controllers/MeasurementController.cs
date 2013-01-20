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
    public class MeasurementController : ApiController
    {
        public IMeasurementBC MeasurementBC { get; set; }

        public MeasurementController()
        {
            MeasurementBC = new MeasurementBC(new SensorBC());
        }

        public MeasurementController(IMeasurementBC measurementBc)
        {
            MeasurementBC = measurementBc;
        }

        public IQueryable<Measurement> Get()
        {
            return MeasurementBC.GetAll();
        }

        public void Post(Measurement measurement)
        {
            if (measurement == null)
            {
                measurement = new Measurement { SensorId = 1, LastUpdated = DateTime.Now, Temp = 10 };
            }

            MeasurementBC.AddMeasurement(measurement);
        }
    }
}

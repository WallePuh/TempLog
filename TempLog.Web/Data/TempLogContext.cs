using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TempLog.Web.Data
{
    public class TempLogContext:DbContext
    {
        public DbSet<Models.Sensor> Sensors { get; set; }
        public DbSet<Models.Measurement> Measurements { get; set; }
        public DbSet<Models.Device> Devices { get; set; }
    }
}
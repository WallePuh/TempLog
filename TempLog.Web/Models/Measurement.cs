using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TempLog.Web.Models
{
    public class Measurement
    {
        public Measurement()
        {

        }

        [Key]
        public int Id { get; set; }
        public int SensorId { get; set; }
        [JsonIgnore]
        public virtual Sensor Sensor { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

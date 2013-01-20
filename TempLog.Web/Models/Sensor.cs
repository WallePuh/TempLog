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
    public class Sensor
    {
        public Sensor()
        {

        }

        public Sensor(List<string> columns)
        {
        }

        [Key]
        public int Id { get; set; }
        public int TdSensorId { get; set; }
        public string Protocol { get; set; }
        public string Model { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}

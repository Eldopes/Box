using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Box.Models.Sensors;

namespace Box.Models
{
    public class Indication
    {
        public int IndicationID { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double IndicationData { get; set; }

        public int SensorID { get; set; }
       // public Sensor Sensor { get; set; }
    }
}

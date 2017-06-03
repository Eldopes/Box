using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Box.Models.Sensors;

namespace Box.Models
{
    public class Sensor
    { 
        public int SensorID { get; set; }
        public string Name { get; set; }
        public string Scale { get; set; } 
        public bool Enabled { get; set; }   
        
        public List<Indication> Indications { get; set; }
    }
}

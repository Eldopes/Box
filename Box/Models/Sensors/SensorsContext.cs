using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Box.Models.Sensors
{
    public class SensorsContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public SensorsContext(DbContextOptions<SensorsContext> options) : base(options)
        { }
    }
}

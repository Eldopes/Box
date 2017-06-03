using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Box.Models;
using Box.Models.Sensors;
using Box.Helpers;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;

namespace Box.Controllers
{
    [Route("api/[controller]")]
    public class SensorsController : Controller
    {    
        SensorsContext db;
        public SensorsController(SensorsContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Sensor> Get()
        {
            return db.Sensors.ToList();
        }

        // GET api/Sensors/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sensor sensor = db.Sensors.FirstOrDefault(x => x.SensorID == id);
            if (sensor == null)
                return NotFound();
            return new ObjectResult(sensor);
        }

        // POST api/Sensors
        [HttpPost]
        public IActionResult Post([FromBody]Sensor sensor)
        {           
            if (Validator.Validate(sensor) == false)
            { // if json is invalid or null, bad request is returned
                return BadRequest();
            }

            db.Sensors.Add(sensor);
            db.SaveChanges();
            return Ok(sensor);
        }

        // PUT api/Sensors/
        [HttpPut]
        public IActionResult Put([FromBody]Sensor sensor)
        {
            if (sensor == null)
            {
                return BadRequest();
            }
            if (!db.Sensors.Any(x => x.SensorID == sensor.SensorID))
            {
                return NotFound();
            }

            db.Update(sensor);
            db.SaveChanges();
            return Ok(sensor);
        }

        // DELETE api/sensors/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Sensor sensor = db.Sensors.FirstOrDefault(x => x.SensorID == id);
            if (sensor == null)
            {
                return NotFound();
            }
            db.Sensors.Remove(sensor);
            db.SaveChanges();
            return Ok(sensor);
        }
    }
}
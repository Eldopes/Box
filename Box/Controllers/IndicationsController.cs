using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Box.Models;
using Box.Models.Sensors;
using Box.Helpers;

namespace Box.Controllers
{
    [Route("api/[controller]")]
    public class IndicationsController : Controller
    {
        SensorsContext db;
        public IndicationsController(SensorsContext context)
        {
            db = context;
            if (!db.Indications.Any())
            {
                db.Indications.Add(new Indication { IndicationData = 38.5, SensorID = 2 });
                // db.Indications.Add(new Indication { IndicationData = 38.7, SensorID = 10 }); // must not work
                db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Indication> Get()
        {
            return db.Indications.ToList();
        }

        // GET api/Indications/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Indication indication = db.Indications.FirstOrDefault(x => x.IndicationID == id);
            if (indication == null)
                return NotFound();

            return new ObjectResult(indication);
        }

        // POST api/Indications
        [HttpPost]
        public IActionResult Post([FromBody]Indication indication)
        {
            if (Validator.Validate(indication) == false)
            { // if json is invalid or null, bad request is returned
                return BadRequest();
            }

            db.Indications.Add(indication);
            db.SaveChanges();
            return Ok(indication);
        }
    }
}
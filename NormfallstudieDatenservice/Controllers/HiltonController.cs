using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{
    [Route("api/hotel/[controller]")]
    [ApiController]
    public class HiltonController : ControllerBase
    {

        private readonly HiltonContext _context;

        public HiltonController(HiltonContext context)
        {
            
            _context = context;
            /*
            var Destinations = _context.Destinations.ToList();
            if (Destinations.Count != 5)
            {
                if (Destinations != null)
                {
                    foreach (var Destination in Destinations)
                    {
                        _context.Destinations.Remove(Destination);
                    }

                    _context.SaveChanges();
                }

                _context.Destinations.Add(new Destination { Name = "Zürich"} );
                _context.Destinations.Add(new Destination { Name = "Hong Kong"} );
                _context.Destinations.Add(new Destination { Name = "Berlin"} );
                _context.Destinations.Add(new Destination { Name = "London"} );
                _context.Destinations.Add(new Destination { Name = "New York"} );
                _context.SaveChanges();

            }
            */
        }
        
        // GET: api/hotel/hilton
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HiltonNight>>> GetHiltonNights()
        {
            return await _context.HiltonNights.ToListAsync();
        }
        
        // GET: api/hotel/hilton/1
        [HttpGet("{id}")]
        public async Task<ActionResult<HiltonNight>> GetHiltonNight(int id)
        {
            var hiltonNight = await _context.HiltonNights.FindAsync(id);

            if (hiltonNight == null)
            {
                return NotFound();
            }

            return hiltonNight;

        }
        
        // POST: api/hotel/hilton
        [HttpPost]
        public async Task<ActionResult<HiltonNight>> PostHiltonNight(HiltonNight hiltonNight)
        {
            _context.HiltonNights.Add(hiltonNight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHiltonNight), new {id = hiltonNight.HiltonNightId}, hiltonNight);
        }
        
        // PUT: api/hotel/hilton/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHiltonNight(long id, HiltonNight hiltonNight)
        {
            if (id != hiltonNight.HiltonNightId)
            {
                return BadRequest();
            }

            _context.Entry(hiltonNight).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // DELETE: api/hotel/hilton/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHiltonNight(long id)
        {
            var hiltonNight = await _context.HiltonNights.FindAsync(id);

            if (hiltonNight == null)
            {
                return NotFound();
            }

            _context.HiltonNights.Remove(hiltonNight);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
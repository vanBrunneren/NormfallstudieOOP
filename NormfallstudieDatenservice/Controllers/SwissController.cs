using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{
    [Route("api/airline/[controller]")]
    [ApiController]
    public class SwissController : ControllerBase
    {

        private static SwissContext _context;

        public SwissController(SwissContext context)
        {
            _context = context;

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

        }
        
        // GET: api/airline/swiss
        [HttpGet]
        public static async Task<ActionResult<IEnumerable<SwissFlight>>> GetSwissFlights()
        {
            return await _context.SwissFlights.ToListAsync();
        }
        
        // GET: api/airline/swiss/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SwissFlight>> GetSwissFlight(int id)
        {
            var swissFlight = await _context.SwissFlights.FindAsync(id);

            if (swissFlight == null)
            {
                return NotFound();
            }

            return swissFlight;

        }
        
        // POST: api/airline/swiss
        [HttpPost]
        public async Task<ActionResult<SwissFlight>> PostSwissFlight(SwissFlight swissFlight)
        {
            _context.SwissFlights.Add(swissFlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSwissFlight), new {id = swissFlight.SwissFlightId}, swissFlight);
        }
                
        // PUT: api/airline/swiss/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSwissFlight(long id, SwissFlight swissFlight)
        {
            if (id != swissFlight.SwissFlightId)
            {
                return BadRequest();
            }

            _context.Entry(swissFlight).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // DELETE: api/airline/swiss/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSwissFlight(long id)
        {
            var swissFlight = await _context.SwissFlights.FindAsync(id);

            if (swissFlight == null)
            {
                return NotFound();
            }

            _context.SwissFlights.Remove(swissFlight);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
    
}
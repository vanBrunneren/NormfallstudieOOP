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
    public class EasyjetController : ControllerBase
    {

        private readonly EasyjetContext _context;

        public EasyjetController(EasyjetContext context)
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
        
        // GET: api/airline/easyjet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EasyjetFlight>>> GetEasyjetFlights()
        {
            return await _context.EasyjetFlights.ToListAsync();
        }
        
        // GET: api/airline/easyjet/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EasyjetFlight>> GetEasyjetFlight(int id)
        {
            var easyjetFlight = await _context.EasyjetFlights.FindAsync(id);

            if (easyjetFlight == null)
            {
                return NotFound();
            }

            return easyjetFlight;

        }
        
        // POST: api/airline/easyjet
        [HttpPost]
        public async Task<ActionResult<EasyjetFlight>> PostEasyjetFlight(EasyjetFlight easyjetFlight)
        {
            _context.EasyjetFlights.Add(easyjetFlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEasyjetFlight), new {id = easyjetFlight.EasyjetFlightId}, easyjetFlight);
        }
                
        // PUT: api/airline/easyjet/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEasyjetFlight(long id, EasyjetFlight easyjetFlight)
        {
            if (id != easyjetFlight.EasyjetFlightId)
            {
                return BadRequest();
            }

            _context.Entry(easyjetFlight).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // DELETE: api/airline/easyjet/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEasyjetFlight(long id)
        {
            var easyjetFlight = await _context.EasyjetFlights.FindAsync(id);

            if (easyjetFlight == null)
            {
                return NotFound();
            }

            _context.EasyjetFlights.Remove(easyjetFlight);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
    
}
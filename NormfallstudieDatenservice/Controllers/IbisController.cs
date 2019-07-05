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
    public class IbisController : ControllerBase
    {

        private readonly IbisContext _context;

        public IbisController(IbisContext context)
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
        
        // GET: api/hotel/ibis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IbisNight>>> GetIbisNights()
        {
            return await _context.IbisNights.ToListAsync();
        }
        
        // GET: api/hotel/ibis/1
        [HttpGet("{id}")]
        public async Task<ActionResult<IbisNight>> GetIbisNight(int id)
        {
            var ibisNight = await _context.IbisNights.FindAsync(id);

            if (ibisNight == null)
            {
                return NotFound();
            }

            return ibisNight;

        }
        
        // POST: api/hotel/ibis
        [HttpPost]
        public async Task<ActionResult<HiltonNight>> PostIbisNight(IbisNight ibisNight)
        {
            _context.IbisNights.Add(ibisNight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIbisNight), new {id = ibisNight.IbisNightId}, ibisNight);
        }
        
        // PUT: api/hotel/ibis/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIbisNight(long id, IbisNight ibisNight)
        {
            if (id != ibisNight.IbisNightId)
            {
                return BadRequest();
            }

            _context.Entry(ibisNight).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        // DELETE: api/hotel/ibis/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIbisNight(long id)
        {
            var ibisNight = await _context.IbisNights.FindAsync(id);

            if (ibisNight == null)
            {
                return NotFound();
            }

            _context.IbisNights.Remove(ibisNight);
            await _context.SaveChangesAsync();

            return NoContent();

        }

    }
}
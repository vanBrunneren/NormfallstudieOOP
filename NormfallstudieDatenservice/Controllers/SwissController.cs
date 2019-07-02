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

        private readonly SwissContext _context;

        public SwissController(SwissContext context)
        {
            _context = context;
        }
        
        // GET: api/airline/swiss
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwissFlight>>> GetSwissItem()
        {           
            SwissFlight newFlight = new SwissFlight();
            newFlight.Date = "2019-07-02";
            newFlight.StartDestination = _context.SwissDestinations.Single( d => d.Name == "Zürich" );
            newFlight.EndDestination = _context.SwissDestinations.Single(d => d.Name == "Hong Kong");
            newFlight.EmptyPlaces = 240;
            
            _context.SwissFlights.Add(newFlight);
            _context.SaveChanges();
            
            return await _context.SwissFlights.ToListAsync();
        }

    }
}
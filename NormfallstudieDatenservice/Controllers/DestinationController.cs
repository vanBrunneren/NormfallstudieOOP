/*
using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{
    [Route("api/destination/[controller]") ]
    [ApiController]
    public class DestinationController : ControllerBase
    {

        private readonly SwissContext _swissContext;
        private readonly EasyjetContext _easyjetContext;

        public DestinationController(SwissContext context)
        {
            _swissContext = context;
        }

        public DestinationController(EasyjetContext context)
        {
            _easyjetContext = context;
        }
        
        // GET: api/destination
        [HttpGet]
        public async Task<IActionResult> GetDestinations()
        {
            
            SwissDestination
            
            return NoContent();
        }

    }
}
*/
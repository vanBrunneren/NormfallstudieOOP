using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastminuteController : ControllerBase
    {

        // GET api/lastminute
        [HttpGet]
        public async Task<Task<IEnumerable<SwissFlight>>> GetLastminuteOffers()
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            
            HttpResponseMessage response = await client.GetAsync("/api/airline/swiss");
            response.EnsureSuccessStatusCode();
            
            var swissFlights = response.Content.ReadAsAsync<IEnumerable<SwissFlight>>();

            response = await client.GetAsync("/api/airline/easyjet");
            response.EnsureSuccessStatusCode();

            var easyjetFlights = response.Content.ReadAsAsync<IEnumerable<EasyjetFlight>>();
            
            return swissFlights;

        }
        
    }

  
}
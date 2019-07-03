using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{

    public class LastminuteOffer
    {
        public int Id { get; set; }
        
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class LastminuteController : ControllerBase
    {
        
        static HttpClient client = new HttpClient();
        
        static async Task<LastminuteOffer> GetLastminuteOfferAsync(string path)
        {
            LastminuteOffer offer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                offer = await response.Content.ReadAsAsync<LastminuteOffer>();
            }
            return offer;
        }

        // GET api/lastminute
        [HttpGet]
        public async Task GetLastminuteOffers()
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            LastminuteOffer offer = new LastminuteOffer();
            
            try
            {
                offer = await GetLastminuteOfferAsync("/api/airline/easyjet");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            
            HttpResponseMessage response = await client.GetAsync("/api/airline/swiss");
            response.EnsureSuccessStatusCode();
            
            var swissFlights = response.Content.ReadAsAsync<IEnumerable<SwissFlight>>();
            
            
            response = await client.GetAsync("/api/airline/easyjet");
            response.EnsureSuccessStatusCode();

            var easyjetFlights = response.Content.ReadAsAsync<IEnumerable<EasyjetFlight>>();
            
            return swissFlights;
            */

        }
        
    }

  
}
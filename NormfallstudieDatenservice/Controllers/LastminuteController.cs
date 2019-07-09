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
using Newtonsoft.Json;
using NormfallstudieDatenservice.Models;

namespace NormfallstudieDatenservice.Controllers
{

    public class LastminuteOffer
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }     
        public Night Night { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class LastminuteController : ControllerBase
    {
        
        static IHttpClientFactory _httpClientFactory;

        public LastminuteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        static async Task<string> GetLastminuteOfferAsync(string path)
        {
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            
            return null;
        }

        // GET api/lastminute
        [HttpGet]
        public async Task<List<LastminuteOffer>> GetLastminuteOffers()
        {

            string swissFlightsJson = await GetLastminuteOfferAsync("api/airline/swiss");
            string easyjetFlightsJson = await GetLastminuteOfferAsync("api/airline/easyjet");

            string ibisNightsJson = await GetLastminuteOfferAsync("/api/hotel/ibis");
            string hiltonNightsJson = await GetLastminuteOfferAsync("/api/hotel/hilton");

            List<SwissFlight> swissFlights = JsonConvert.DeserializeObject<List<SwissFlight>>(swissFlightsJson);
            List<EasyjetFlight> easyjetFlights = JsonConvert.DeserializeObject<List<EasyjetFlight>>(easyjetFlightsJson);

            List<IbisNight> ibisNights = JsonConvert.DeserializeObject<List<IbisNight>>(ibisNightsJson);
            List<HiltonNight> hiltonNights = JsonConvert.DeserializeObject<List<HiltonNight>>(hiltonNightsJson);

            List<LastminuteOffer> lastminuteOffers = new List<LastminuteOffer>();
            
            
            
            int id = 0;
            foreach (var swissFlight in swissFlights)
            {
                
                    lastminuteOffers.Add(new LastminuteOffer { Id = id, Flight = swissFlight});
                    id++;
                
                
            }
            
            //lastminuteOffers.Find(lastMinuteOffer => lastMinuteOffer.Id == 5);

            return lastminuteOffers.ToList();

        }
    
        /*
        // GET api/lastminute/2019-07-02
        [HttpGet("{date}")]
        public async Task<List<LastminuteOffer>> GetLastminuteOffersByDate(string date)
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string swissFlightsJson = await GetLastminuteOfferAsync("api/airline/swiss");
            string easyjetFlightsJson = await GetLastminuteOfferAsync("api/airline/easyjet");

            string ibisNightsJson = await GetLastminuteOfferAsync("/api/hotel/ibis");
            string hiltonNightsJson = await GetLastminuteOfferAsync("/api/hotel/hilton");

            List<SwissFlight> swissFlights = JsonConvert.DeserializeObject<List<SwissFlight>>(swissFlightsJson);
            
            
            
        }
        */
        
    }

  
}
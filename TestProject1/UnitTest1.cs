using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NormfallstudieDatenservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using NormfallstudieDatenservice.Models;

namespace TestProject1
{
    [TestClass]
    public class SwissControllerTests
    {
        
        private static SwissContext _context;
        
        [TestMethod]
        public async Task GetSwissFlightsTests()
        {
            
            SwissController sc = new SwissController(_context);
            
            var swissFlights = await sc.GetSwissFlight(1);
            Assert.IsNotNull(swissFlights);
        }
        
        
    }
}
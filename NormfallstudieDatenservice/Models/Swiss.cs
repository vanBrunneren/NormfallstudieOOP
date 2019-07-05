using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace NormfallstudieDatenservice.Models
{
    public class SwissContext : DbContext
    {

        public DbSet<SwissFlight> SwissFlights { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Swiss.db");
        }
        
    }

    public class SwissFlight : Flight
    {
        public int SwissFlightId { get; set; }
    }

}
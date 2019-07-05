using Microsoft.EntityFrameworkCore;

namespace NormfallstudieDatenservice.Models
{
    public class EasyjetContext : DbContext
    {

        public DbSet<EasyjetFlight> EasyjetFlights { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Easyjet.db");
        }
        
    }

    public class EasyjetFlight : Flight
    {
        public int EasyjetFlightId { get; set; }
    }

}
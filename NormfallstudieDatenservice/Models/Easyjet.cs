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

    public class EasyjetFlight
    {
        public int EasyjetFlightId { get; set; }
        public Destination StartDestination { get; set; }
        public Destination EndDestination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }  
    }

}
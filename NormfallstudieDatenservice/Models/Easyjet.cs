using Microsoft.EntityFrameworkCore;

namespace NormfallstudieDatenservice.Models
{
    public class EasyjetContext : DbContext
    {

        public DbSet<EasyjetFlight> EasyjetFlights { get; set; }
        public DbSet<EasyjetDestination> EasyjetDestinations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Easyjet.db");
        }
        
    }

    public class EasyjetFlight
    {
        public int EasyjetFlightId { get; set; }
        public EasyjetDestination StartDestination { get; set; }
        public EasyjetDestination EndDestination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }  
    }

    public class EasyjetDestination
    {
        public int EasyjetDestinationId { get; set; }
        public string Name { get; set; }
    }
    
}
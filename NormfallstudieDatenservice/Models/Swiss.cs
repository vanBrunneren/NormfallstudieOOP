using Microsoft.EntityFrameworkCore;

namespace NormfallstudieDatenservice.Models
{
    public class SwissContext : DbContext
    {

        public DbSet<SwissFlight> SwissFlights { get; set; }
        public DbSet<SwissDestination> SwissDestinations { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Swiss.db");
        }
        
    }

    public class SwissFlight
    {
        public int SwissFlightId { get; set; }
        public SwissDestination StartDestination { get; set; }
        public SwissDestination EndDestination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }  
    }

    public class SwissDestination
    {
        public int SwissDestinationId { get; set; }
        public string Name { get; set; }
    }
    
}
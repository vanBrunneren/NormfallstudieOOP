using Microsoft.EntityFrameworkCore;

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

    public class SwissFlight
    {
        public int SwissFlightId { get; set; }
        public Destination StartDestination { get; set; }
        public Destination EndDestination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }  
    }

}
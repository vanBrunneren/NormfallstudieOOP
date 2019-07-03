using Microsoft.EntityFrameworkCore;

namespace NormfallstudieDatenservice.Models
{
    public class IbisContext : DbContext
    {
        public DbSet<IbisNight> IbisNights { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Ibis.db");
        }
        
    }

    public class IbisNight
    {
        public int IbisNightId { get; set; }
        public Destination Destination { get; set; }
        public string Date { get; set; }
        public int EmptyPlaces { get; set; }
    }
    
}
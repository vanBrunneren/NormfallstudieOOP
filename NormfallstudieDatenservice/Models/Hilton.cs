using Microsoft.EntityFrameworkCore;

namespace NormfallstudieDatenservice.Models
{
    public class HiltonContext : DbContext
    {
        public DbSet<HiltonNight> HiltonNights { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Hilton.db");
        }
        
    }

    public class HiltonNight : Night
    {
        public int HiltonNightId { get; set; }
    }
    
}
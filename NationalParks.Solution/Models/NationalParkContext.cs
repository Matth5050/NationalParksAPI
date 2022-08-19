using Microsoft.EntityFrameworkCore;

namespace NationalPark.Models
{
    public class NationalParkContext : DbContext
    {
        public NationalParkContext(DbContextOptions<NationalParkContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Park>()
            .HasData(
                new Park { ParkId = 1, Name = "Zion", State = "Utah" },
                new Park { ParkId = 2, Name = "YellowStone", State = "Wyoming" },
                new Park { ParkId = 3, Name = "Sequoia", State = "California" },
                new Park { ParkId = 4, Name = "Everglades", State = "Florida" },
                new Park { ParkId = 5, Name = "Arches", State = "Colorado" }
            );
        }
        public DbSet<Park> Parks { get; set; }
    }
}
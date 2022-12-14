using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NationalPark.Models
{
    public class NationalParkContext : IdentityDbContext
    {
        public NationalParkContext(DbContextOptions<NationalParkContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        base.OnModelCreating(builder);
        builder.Entity<Park>()
            .HasData(
                new Park { ParkId = 1, Name = "Zion", State = "Utah" },
                new Park { ParkId = 2, Name = "YellowStone", State = "Wyoming" },
                new Park { ParkId = 3, Name = "Sequoia", State = "California" },
                new Park { ParkId = 4, Name = "Everglades", State = "Florida" },
                new Park { ParkId = 5, Name = "Arches", State = "Colorado" }
            );

        builder.Entity<Region>()
        .HasData(
            new Region{ RegionId = 1, Name = "West" }
            );
        }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
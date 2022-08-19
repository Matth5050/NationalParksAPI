using Microsoft.EntityFrameworkCore;

namespace NationalPark.Models
{
    public class NationalParkContext : DbContext
    {
        public NationalParkContext(DbContextOptions<NationalParkContext> options)
            : base(options)
        {
        }

        public DbSet<Park> Parks { get; set; }
    }
}
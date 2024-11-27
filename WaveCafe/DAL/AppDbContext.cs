using Microsoft.EntityFrameworkCore;
using WaveCafe.Models;

namespace WaveCafe.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CoffeeType> CoffeeTypes { get; set; }
        public DbSet<Cofee> Cofees { get; set; }


    }
}

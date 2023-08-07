using Microsoft.EntityFrameworkCore;
using Planer_zakupowy.Backend.DataAccess.Configurations;
using Planer_zakupowy.Backend.DataAccess.Models;

namespace Planer_zakupowy.Backend.DataAccess
{
    public class Planer_zakupowyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public Planer_zakupowyDbContext(DbContextOptions<Planer_zakupowyDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }
    }
}

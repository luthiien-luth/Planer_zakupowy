using Microsoft.EntityFrameworkCore;
using Planer_zakupowy.Backend.DataAccess.Configurations;
using Planer_zakupowy.Backend.DataAccess.Models;

namespace Planer_zakupowy.Backend.DataAccess
{
    public class PlanerZakupowyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsList> ProductsLists { get; set; }

        public PlanerZakupowyDbContext(DbContextOptions<PlanerZakupowyDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new ShoppingListConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsListConfiguration());
        }
    }
}

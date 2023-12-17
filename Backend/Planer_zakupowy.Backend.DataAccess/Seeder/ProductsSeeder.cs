using Planer_zakupowy.Backend.DataAccess.Models;
using Planer_zakupowy.Backend.DataAccess.Models.Enums;

namespace Planer_zakupowy.Backend.DataAccess.Seeder
{
    public class ProductsSeeder
    {
        private readonly PlanerZakupowyDbContext _context;

        public ProductsSeeder(PlanerZakupowyDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (await _context.Database.CanConnectAsync())
            {
                if (!_context.Products.Any())
                {
                    var products = new List<Product>()
                    {
                        new Product() { Name = "Chleb jasny", Category = ProductsCategories.Bread, CreationDate = DateTime.Now },
                        new Product() { Name = "Jabłko", Category = ProductsCategories.Fruits, CreationDate = DateTime.Now },
                        new Product() { Name = "Marchewka", Category = ProductsCategories.Vegetables, CreationDate = DateTime.Now },
                        new Product() { Name = "Prince polo", Category = ProductsCategories.SweetsSnacks, CreationDate = DateTime.Now },
                        new Product() { Name = "Mleko", Category = ProductsCategories.Dairy, CreationDate = DateTime.Now },
                        new Product() { Name = "Ryż", Category = ProductsCategories.Loose, CreationDate = DateTime.Now },
                        new Product() { Name = "Szpinak mrożony", Category = ProductsCategories.Frozen, CreationDate = DateTime.Now },
                        new Product() { Name = "Sól", Category = ProductsCategories.SpicesSauses, CreationDate = DateTime.Now },
                        new Product() { Name = "Herbata", Category = ProductsCategories.CoffeeTeaCoca, CreationDate = DateTime.Now },
                        new Product() { Name = "Woda mineralna", Category = ProductsCategories.Water, CreationDate = DateTime.Now },
                        new Product() { Name = "Sprite", Category = ProductsCategories.Beverages, CreationDate = DateTime.Now },
                        new Product() { Name = "Proszek do prania", Category = ProductsCategories.HouseholdChemicals, CreationDate = DateTime.Now },
                        new Product() { Name = "Żel pod prysznic", Category = ProductsCategories.Hygiene, CreationDate = DateTime.Now }
                    };

                    _context.Products.AddRange(products);
                    _context.SaveChanges();
                }
            }
        }
    }
}

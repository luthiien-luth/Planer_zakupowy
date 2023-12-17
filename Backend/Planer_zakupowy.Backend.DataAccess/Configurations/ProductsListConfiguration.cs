using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planer_zakupowy.Backend.DataAccess.Models;

namespace Planer_zakupowy.Backend.DataAccess.Configurations
{
    public class ProductsListConfiguration : IEntityTypeConfiguration<ProductsList>
    {
        public void Configure(EntityTypeBuilder<ProductsList> builder)
        {
            builder
                .HasKey(pl => new { pl.ProductId, pl.ShoppingListId });

            builder
                .HasOne(pl => pl.Product)
                .WithMany(p => p.ProductsLists)
                .HasForeignKey(pl => pl.ProductId);

            builder
                .HasOne(pl => pl.ShoppingList)
                .WithMany(l => l.ProductsLists)
                .HasForeignKey(pl => pl.ShoppingListId);
        }
    }
}

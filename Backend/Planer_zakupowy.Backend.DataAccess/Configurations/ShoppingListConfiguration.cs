using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planer_zakupowy.Backend.DataAccess.Models;

namespace Planer_zakupowy.Backend.DataAccess.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder
                .HasOne(l => l.User)
                .WithMany(u => u.ShoppingLists)
                .HasForeignKey(l => l.UserId);
        }
    }
}

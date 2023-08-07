using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planer_zakupowy.Backend.DataAccess.Models;

namespace Planer_zakupowy.Backend.DataAccess.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShoppingCenterproject.Data_DB.Configuration
{
    public class RoleForUsersConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Name = "Castomer",
                NormalizedName = "Castomer".ToUpper(),
            },
            new IdentityRole
            {
                Name = "Company",
                NormalizedName = "Company".ToUpper(),
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
            });
        }
    }
}

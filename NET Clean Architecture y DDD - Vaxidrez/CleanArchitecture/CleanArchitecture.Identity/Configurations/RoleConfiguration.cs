using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "80c54e82-e852-4907-907c-fa74fb5ab7f0",
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                },
                new IdentityRole
                {
                    Id = "1049094e-6dd2-4d87-ba7e-faef5e239262",
                    Name = "Operator",
                    NormalizedName = "Operator".ToUpper()
                }
            );
        }
    }
}

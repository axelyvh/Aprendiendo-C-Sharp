using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string> { 
                    RoleId = "80c54e82-e852-4907-907c-fa74fb5ab7f0",
                    UserId = "0d87d27c-c7d7-493f-a397-91852fe6c23e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "1049094e-6dd2-4d87-ba7e-faef5e239262",
                    UserId = "d2ab811b-91ad-413d-a9ee-5b739c8f8dec"
                }
            );
        }
    }
}

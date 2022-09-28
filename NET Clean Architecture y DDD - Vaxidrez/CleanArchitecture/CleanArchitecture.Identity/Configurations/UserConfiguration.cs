using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser { 
                    Id = "0d87d27c-c7d7-493f-a397-91852fe6c23e",
                    Email = "axelvasquezherrera@outlook.com",
                    NormalizedEmail = "axelvasquezherrera@outlook.com".ToUpper(),
                    Nombre = "Axel",
                    Apellidos = "Vasquez",
                    UserName = "axelyvh",
                    NormalizedUserName = "axelyvh".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Teclado123."),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "d2ab811b-91ad-413d-a9ee-5b739c8f8dec",
                    Email = "yoliston@outlook.com",
                    NormalizedEmail = "yoliston@outlook.com".ToUpper(),
                    Nombre = "Yoliston",
                    Apellidos = "Herrera",
                    UserName = "yoliston",
                    NormalizedUserName = "yoliston".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Teclado123."),
                    EmailConfirmed = true
                }
            );
        }
    }
}

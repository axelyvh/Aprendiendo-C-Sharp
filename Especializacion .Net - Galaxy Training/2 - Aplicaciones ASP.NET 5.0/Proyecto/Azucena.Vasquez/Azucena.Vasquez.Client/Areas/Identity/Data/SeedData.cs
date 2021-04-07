using Azucena.Vasquez.Client.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Azucena.Vasquez.Client.Areas.Identity.Data
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            EnsureRolesAsync(roleManager).Wait();

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            EnsureUsersAsync(userManager).Wait();
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {

            bool alreadyExists = await roleManager.RoleExistsAsync(Roles.Administrator);
            if (!alreadyExists)
            {
                var role = new IdentityRole(Roles.Administrator);
                await roleManager.CreateAsync(role);
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Create));
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Delete));
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Edit));
            }

            alreadyExists = await roleManager.RoleExistsAsync(Roles.Profesor);
            if (!alreadyExists)
            {
                var role = new IdentityRole(Roles.Profesor);
                await roleManager.CreateAsync(role);
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Create));
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Delete));
                await roleManager.AddClaimAsync(role, new Claim("GrantAccess", GrantAccess.Edit));
            }

            alreadyExists = await roleManager.RoleExistsAsync(Roles.Alumno);
            if (!alreadyExists)
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Alumno));
            }

        }

        private static async Task EnsureUsersAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = await userManager.Users.Where(x => x.UserName == "admin@todo.local").SingleOrDefaultAsync();
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@todo.local",
                    Email = "admin@todo.local",
                    FirstName = "Azucena",
                    LastName = "Vasquez",
                };
                await userManager.CreateAsync(admin, "P@ssword1234");
                string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(admin);
                await userManager.ConfirmEmailAsync(admin, emailConfirmationToken);
                await userManager.AddToRoleAsync(admin, Roles.Administrator);
            }

            var powerUser = await userManager.Users.Where(x => x.UserName == "profesor01@todo.local").SingleOrDefaultAsync();
            if (powerUser == null)
            {
                powerUser = new ApplicationUser
                {
                    UserName = "profesor01@todo.local",
                    Email = "profesor01@todo.local",
                    FirstName = "Profesor01",
                    LastName = "Vasquez",
                };
                await userManager.CreateAsync(powerUser, "P@ssword1234");
                string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(powerUser);
                await userManager.ConfirmEmailAsync(powerUser, emailConfirmationToken);
                await userManager.AddToRoleAsync(powerUser, Roles.Profesor);
            }

            var user = await userManager.Users.Where(x => x.UserName == "alumno01@todo.local").SingleOrDefaultAsync();
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "alumno01@todo.local",
                    Email = "alumno01@todo.local",
                    FirstName = "Alumno01",
                    LastName = "Vasquez",
                };
                await userManager.CreateAsync(user, "P@ssword1234");
                string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                await userManager.ConfirmEmailAsync(user, emailConfirmationToken);
                await userManager.AddToRoleAsync(user, Roles.Alumno);
            }

        }

    }
}

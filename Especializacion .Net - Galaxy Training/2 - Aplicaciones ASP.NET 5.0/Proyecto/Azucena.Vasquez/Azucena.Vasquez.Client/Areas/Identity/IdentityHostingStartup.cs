using System;
using Azucena.Vasquez.Client.Areas.Identity.Data;
using Azucena.Vasquez.Client.Data;
using Azucena.Vasquez.Client.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Azucena.Vasquez.Client.Areas.Identity.IdentityHostingStartup))]
namespace Azucena.Vasquez.Client.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

                services.AddDbContext<SecurityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecurityConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<SecurityContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

                services.AddAuthorization(opt =>
                {
                    opt.AddPolicy(Policies.CreateUser, policy => policy.RequireClaim("GrantAccess", GrantAccess.Create));
                    opt.AddPolicy(Policies.EditUser, policy => policy.RequireClaim("GrantAccess", GrantAccess.Edit));
                    opt.AddPolicy(Policies.DeleteUser, policy => policy.RequireClaim("GrantAccess", GrantAccess.Delete));
                });

            });
        }
    }
}
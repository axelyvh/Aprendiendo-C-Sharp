using Azucena.Vasquez.Client.Areas.Identity.Data;
using Azucena.Vasquez.Client.Services;
using Azucena.Vasquez.Infrastructure.Data.Audit.Repositories;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories;
using Azucena.Vasquez.Infrastructure.Helper.Error;
using Azucena.Vasquez.Infrastructure.Helper.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azucena.Vasquez.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
                        
            services.AddHttpContextAccessor();
            services.AddUniversityRepositories(Configuration);
            services.AddServices();
            services.AddAuditRepositories(Configuration);
            services.AddScoped<LogFilter>();

            services.AddControllersWithViews(opt => {
                opt.Filters.Add(new AuthorizeFilter());
            }).AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandlerMiddleware();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            SeedData.Initialize(scope.ServiceProvider);

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}

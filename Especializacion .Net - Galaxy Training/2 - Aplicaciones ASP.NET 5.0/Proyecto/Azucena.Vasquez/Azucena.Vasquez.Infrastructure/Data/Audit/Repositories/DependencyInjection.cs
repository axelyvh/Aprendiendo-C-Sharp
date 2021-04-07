using Azucena.Vasquez.Infrastructure.Data.Audit.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azucena.Vasquez.Infrastructure.Data.Audit.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuditRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IAuditLogRepository, AuditLogRepository>();
            services.AddScoped<AuditContext>();
            services.AddScoped<AuditUnitOfWork>();

            services.AddDbContext<AuditContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("AuditConnection"));
            });
            return services;
        }
    }
}

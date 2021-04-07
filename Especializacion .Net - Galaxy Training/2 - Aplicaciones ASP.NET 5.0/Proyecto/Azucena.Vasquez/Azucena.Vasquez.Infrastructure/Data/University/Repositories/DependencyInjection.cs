using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Implementations;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUniversityRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<UniversityUnitOfWork>();

            services.AddDbContext<UniversityContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("UniversityConnection"));
            });
            return services;
        }
    }
}

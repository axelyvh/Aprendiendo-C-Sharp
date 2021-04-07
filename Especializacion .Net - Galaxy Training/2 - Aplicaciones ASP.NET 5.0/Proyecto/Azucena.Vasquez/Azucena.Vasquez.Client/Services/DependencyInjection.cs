using Microsoft.Extensions.DependencyInjection;

namespace Azucena.Vasquez.Client.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUniversityService, UniversityService>();

            return services;
        }
    }
}

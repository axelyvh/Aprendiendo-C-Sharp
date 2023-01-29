namespace Microservice.Demo.Report.Infrastructure.Configuration
{
    public static class Extensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            var servicesUrl = configuration.GetSection("ServicesUrl");
            services.Configure<ServicesUrl>(servicesUrl);

            return services;

        }
    }
}

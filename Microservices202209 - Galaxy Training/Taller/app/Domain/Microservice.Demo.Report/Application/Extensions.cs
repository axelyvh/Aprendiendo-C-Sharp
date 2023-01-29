namespace Microservice.Demo.Report.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<PolicyApplicationService>();
            return services;
        }
    }
}

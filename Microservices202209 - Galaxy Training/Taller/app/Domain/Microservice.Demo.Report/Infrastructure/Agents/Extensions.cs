using Microservice.Demo.Report.Infrastructure.Agents.Policy;
using Microservice.Demo.Report.Infrastructure.Agents.Product;

namespace Microservice.Demo.Report.Infrastructure.Agents
{
    public static class Extensions
    {
        public static IServiceCollection AddRestClients(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IPolicyClient), typeof(PolicyClient));
            services.AddSingleton(typeof(IPolicyAgent), typeof(PolicyAgent));

            services.AddSingleton(typeof(IProductClient), typeof(ProductClient));
            services.AddSingleton(typeof(IProductAgent), typeof(ProductAgent));

            return services;
        }
    }
}

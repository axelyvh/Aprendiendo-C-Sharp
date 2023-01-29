using Microservice.Demo.Report.Infrastructure.Agents.Product.Queries;
using Microservice.Demo.Report.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Polly;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace Microservice.Demo.Report.Infrastructure.Agents.Product
{
    public class ProductClient : IProductClient
    {

        private readonly IProductClient client;
        public readonly ServicesUrl _servicesUrl;

        private static IAsyncPolicy retryPolicy = Polly.Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public ProductClient(IOptions<ServicesUrl> servicesUrl, IDiscoveryClient discoveryClient)
        {
            _servicesUrl = servicesUrl.Value;
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            //Certificado no valido
            handler.ServerCertificateCustomValidationCallback = delegate { return true; };
            var httpClient = new HttpClient(handler, false)
            {
                BaseAddress = new Uri(_servicesUrl.ProductApiUrl)
            };
            client = RestClient.For<IProductClient>(httpClient);
        }

        public Task<ProductQueryResult> GetByCode(string code)
        {
            try
            {
                return retryPolicy.ExecuteAsync(async () => await client.GetByCode(code));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using Microservice.Demo.Report.Infrastructure.Agents.Policy.Queries;
using Microservice.Demo.Report.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Polly;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace Microservice.Demo.Report.Infrastructure.Agents.Policy
{
    public class PolicyClient : IPolicyClient
    {

        private readonly IPolicyClient client;
        public readonly ServicesUrl _servicesUrl;

        private static IAsyncPolicy retryPolicy = Polly.Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(retryCount: 3, sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(3));

        public PolicyClient(IOptions<ServicesUrl> servicesUrl, IDiscoveryClient discoveryClient)
        {
            _servicesUrl = servicesUrl.Value;
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            //Certificado no valido
            handler.ServerCertificateCustomValidationCallback = delegate { return true; };
            var httpClient = new HttpClient(handler, false)
            {
                BaseAddress = new Uri(_servicesUrl.PolicyApiUrl)
            };
            client = RestClient.For<IPolicyClient>(httpClient);
        }

        public Task<List<PolicyListQueryResult>> GetAll()
        {
            try
            {
                return retryPolicy.ExecuteAsync(async () => await client.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

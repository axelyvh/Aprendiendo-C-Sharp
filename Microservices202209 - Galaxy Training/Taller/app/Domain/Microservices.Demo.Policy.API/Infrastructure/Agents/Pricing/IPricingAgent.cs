using Microservices.Demo.Policy.API.Domain.Entities;
using Microservices.Demo.Policy.API.Infrastructure.Data.Entities;

namespace Microservices.Demo.Policy.API.Infrastructure.Agents.Pricing
{
    public interface IPricingAgent
    {
        Task<Price> CalculatePrice(PricingParams pricingParams);
    }

    public class PricingParams
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

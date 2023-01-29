using Microservice.Demo.Report.Infrastructure.Agents.Product.Queries;
using RestEase;

namespace Microservice.Demo.Report.Infrastructure.Agents.Product
{
    public interface IProductClient
    {
        [Get("{code}")]
        Task<ProductQueryResult> GetByCode([Path("code")] string code);
    }
}

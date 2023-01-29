using Microservice.Demo.Report.Infrastructure.Agents.Product.Queries;

namespace Microservice.Demo.Report.Infrastructure.Agents.Product
{
    public interface IProductAgent
    {
        Task<ProductQueryResult> GetByCode(string code);
    }
}

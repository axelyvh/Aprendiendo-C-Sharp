using Microservice.Demo.Report.Infrastructure.Agents.Product.Queries;

namespace Microservice.Demo.Report.Infrastructure.Agents.Product
{
    public class ProductAgent : IProductAgent
    {
        private readonly IProductClient productClient;

        public ProductAgent(IProductClient productClient)
        {
            this.productClient = productClient;
        }

        public async Task<ProductQueryResult> GetByCode(string code)
        {
            var result = await productClient.GetByCode(code);
            return result;
        }
    }
}

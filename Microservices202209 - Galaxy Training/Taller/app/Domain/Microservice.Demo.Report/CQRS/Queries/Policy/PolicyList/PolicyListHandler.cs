using MediatR;
using Microservice.Demo.Report.Infrastructure.Agents.Policy;
using Microservice.Demo.Report.Infrastructure.Agents.Product;

namespace Microservice.Demo.Report.CQRS.Queries.Policy.PolicyList
{
    public class PolicyListHandler : IRequestHandler<PolicyListQuery, List<PolicyListQueryResult>>
    {

        private readonly IPolicyAgent _policyAgent;
        private readonly IProductAgent _productAgent;

        public PolicyListHandler(IPolicyAgent policyAgent, IProductAgent productAgent)
        {
            _policyAgent = policyAgent;
            _productAgent = productAgent;
        }

        public async Task<List<PolicyListQueryResult>> Handle(PolicyListQuery request, CancellationToken cancellationToken)
        {
            var policys = await _policyAgent.GetAll();
            return await ConstructResult(policys);
        }

        private async Task<List<PolicyListQueryResult>> ConstructResult(List<Infrastructure.Agents.Policy.Queries.PolicyListQueryResult> policys)
        {

            var result = new List<PolicyListQueryResult>();

            if (policys != null && policys.Count > 0)
            {

                foreach (var item in policys)
                {

                    var policyVm = new PolicyListQueryResult
                    {
                        policyId = item.policyId,
                        productCode = item.productCode,
                        status = item.status,
                        creationDate = item.creationDate
                    };

                    var product = await _productAgent.GetByCode(policyVm.productCode);
                    policyVm.product = product.Description;

                    result.Add(policyVm);
                }

            }

            return result;

        }

    }
}

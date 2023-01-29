using MediatR;
using Microservices.Demo.Policy.API.Domain;
using Microservices.Demo.Policy.API.Infrastructure.Data.UnitOfWork;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.PolicyList
{
    public class PolicyListHandler : IRequestHandler<PolicyListQuery, List<PolicyListQueryResult>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public PolicyListHandler(IUnitOfWork unitOfWork, PolicyDomainService policyDomainService)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PolicyListQueryResult>> Handle(PolicyListQuery request, CancellationToken cancellationToken)
        {
            var policys = await _unitOfWork.Policies.GetAll();
            return ConstructResult(policys);
        }

        private List<PolicyListQueryResult> ConstructResult(List<API.Infrastructure.Data.Entities.Policy> policys)
        {

            var result = new List<PolicyListQueryResult>();

            if (policys != null && policys.Count > 0) {

                foreach (var item in policys)
                {
                    var policyVm = new PolicyListQueryResult
                    {
                        policyId = item.PolicyId,
                        productCode = item.ProductCode,
                        status = item.PolicyStatus == null ? string.Empty : item.PolicyStatus.Description,
                        creationDate = item.CreationDate == null ? string.Empty : item.CreationDate.Value.ToString("dd/MM/yyyy hh:mm:ss")
                    };

                    result.Add(policyVm);
                }

            }

            return result;

        }

    }
}

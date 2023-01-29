using MediatR;
using Microservice.Demo.Report.CQRS.Queries.Policy.PolicyList;

namespace Microservice.Demo.Report.Application
{
    public class PolicyApplicationService
    {
        private readonly IMediator _mediator;
        public PolicyApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<PolicyListQueryResult>> GetAll()
        {
            var result = await _mediator.Send(new PolicyListQuery());
            return result;
        }
    }
}

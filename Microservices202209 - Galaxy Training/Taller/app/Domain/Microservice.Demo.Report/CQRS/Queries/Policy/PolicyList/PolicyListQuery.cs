using MediatR;

namespace Microservice.Demo.Report.CQRS.Queries.Policy.PolicyList
{
    public class PolicyListQuery : IRequest<List<PolicyListQueryResult>>
    {
    }
}

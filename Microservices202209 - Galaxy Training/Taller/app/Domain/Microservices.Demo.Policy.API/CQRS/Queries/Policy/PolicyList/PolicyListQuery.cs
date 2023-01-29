using MediatR;

namespace Microservices.Demo.Policy.API.CQRS.Queries.Policy.PolicyList
{
    public class PolicyListQuery : IRequest<List<PolicyListQueryResult>>
    {
    }
}

using Microservice.Demo.Report.Infrastructure.Agents.Policy.Queries;
using RestEase;

namespace Microservice.Demo.Report.Infrastructure.Agents.Policy
{
    public interface IPolicyClient
    {
        [Get("GetAll")]
        Task<List<PolicyListQueryResult>> GetAll();
    }
}

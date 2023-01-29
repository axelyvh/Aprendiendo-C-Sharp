using Microservice.Demo.Report.Infrastructure.Agents.Policy.Queries;

namespace Microservice.Demo.Report.Infrastructure.Agents.Policy
{
    public interface IPolicyAgent
    {
        Task<List<PolicyListQueryResult>> GetAll();
    }
}

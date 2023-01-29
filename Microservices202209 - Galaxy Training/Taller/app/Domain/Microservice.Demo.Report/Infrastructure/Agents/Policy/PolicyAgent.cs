using Microservice.Demo.Report.Infrastructure.Agents.Policy.Queries;

namespace Microservice.Demo.Report.Infrastructure.Agents.Policy
{
    public class PolicyAgent : IPolicyAgent
    {

        private readonly IPolicyClient policyClient;

        public PolicyAgent(IPolicyClient policyClient)
        {
            this.policyClient = policyClient;
        }

        public async Task<List<PolicyListQueryResult>> GetAll()
        {
            var result = await policyClient.GetAll();
            return result;
        }
    }
}

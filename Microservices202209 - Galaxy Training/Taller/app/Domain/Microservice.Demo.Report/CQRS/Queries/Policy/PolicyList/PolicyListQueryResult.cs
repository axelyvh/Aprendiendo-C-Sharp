namespace Microservice.Demo.Report.CQRS.Queries.Policy.PolicyList
{
    public class PolicyListQueryResult
    {
        public int policyId { get; set; }
        public string productCode { get; set; }
        public string product { get; set; }
        public string status { get; set; }
        public string creationDate { get; set; }
    }
}

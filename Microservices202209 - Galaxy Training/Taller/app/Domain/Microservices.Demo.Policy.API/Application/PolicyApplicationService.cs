﻿using MediatR;
using Microservices.Demo.Policy.API.CQRS.Commands.Policy.CreatePolicy;
using Microservices.Demo.Policy.API.CQRS.Commands.Policy.TerminatePolicy;
using Microservices.Demo.Policy.API.CQRS.Queries.Policy.GetPolicyDetails;
using Microservices.Demo.Policy.API.CQRS.Queries.Policy.PolicyList;

namespace Microservices.Demo.Policy.API.Application
{
    public class PolicyApplicationService
    {
        private readonly IMediator _mediator;
        public PolicyApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<CreatePolicyResult> CreatePolicyAsync(CreatePolicyCommand command)
        {
            var policyResult = await _mediator.Send(command);
            return policyResult;
        }
        public async Task<GetPolicyDetailsQueryResult> GetPolicyDetails(string policyNumber)
        {
            var result = await _mediator.Send(new GetPolicyDetailsQuery { PolicyNumber = policyNumber });
            return result;
        }
        public async Task<List<PolicyListQueryResult>> GetAll()
        {
            var result = await _mediator.Send(new PolicyListQuery());
            return result;
        }
        public async Task<TerminatePolicyResult> TerminatePolicy(TerminatePolicyCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}

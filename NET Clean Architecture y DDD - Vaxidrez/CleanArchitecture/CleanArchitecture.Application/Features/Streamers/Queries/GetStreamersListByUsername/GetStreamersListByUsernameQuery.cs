using CleanArchitecture.Application.Features.Streamers.Queries.Vms;
using MediatR;

namespace CleanArchitecture.Application.Features.Streamers.Queries.GetStreamersListByUsername
{
    public class GetStreamersListByUsernameQuery : IRequest<List<StreamersVm>>
    {
        public string? Username { get; set; }
        public GetStreamersListByUsernameQuery(string? username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}

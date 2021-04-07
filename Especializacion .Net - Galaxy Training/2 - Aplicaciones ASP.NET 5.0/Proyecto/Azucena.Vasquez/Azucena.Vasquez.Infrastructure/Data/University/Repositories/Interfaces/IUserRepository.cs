using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using System.Collections.Generic;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Users GetUser(string Id);
        List<Users> GetUsers();
        List<Users> GetUsersBy_Role(string Role);
    }
}

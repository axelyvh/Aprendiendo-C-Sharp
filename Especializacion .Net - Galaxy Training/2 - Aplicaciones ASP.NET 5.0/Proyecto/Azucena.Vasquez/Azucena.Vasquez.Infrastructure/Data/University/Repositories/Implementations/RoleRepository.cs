using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Implementations
{
    public class RoleRepository : GenericRepository<Roles>, IRoleRepository
    {
        public RoleRepository(UniversityContext context) : base(context)
        {

        }
    }
}

using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Implementations
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {

        private new readonly UniversityContext _context;
        public UserRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public Users GetUser(string Id)
        {
            return (from us in _context.Users
                    where us.Id.Equals(Id)
                    select new Users
                    {
                        Id = us.Id,
                        UserName = us.UserName,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        Email = us.Email,
                        UserRoles = _context.UserRoles.Where(x => x.UserId.Equals(us.Id)).ToList()
                    }).SingleOrDefault();
        }

        public List<Users> GetUsers()
        {
            return (from us in _context.Users
                    select new Users
                    {
                        Id = us.Id,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        Email = us.Email,
                        UserRoles = (from us_rol in _context.UserRoles
                                     join rol in _context.Roles on us_rol.RoleId equals rol.Id
                                     where us_rol.UserId.Equals(us.Id)
                                     select new UserRoles { 
                                        RoleId = us_rol.RoleId,
                                        Role = rol
                                     }).ToList()
                    }).ToList();
        }

        public List<Users> GetUsersBy_Role(string Role)
        {
            return (from us in _context.Users
                    join us_rol in _context.UserRoles on us.Id equals us_rol.UserId
                    join rol in _context.Roles on us_rol.RoleId equals rol.Id
                    where rol.NormalizedName.Equals(Role.ToUpper())
                    select new Users
                    {
                        Id = us.Id,
                        FirstName = us.FirstName,
                        LastName = us.LastName,
                        Email = us.Email
                    }).ToList();
        }
    }
}

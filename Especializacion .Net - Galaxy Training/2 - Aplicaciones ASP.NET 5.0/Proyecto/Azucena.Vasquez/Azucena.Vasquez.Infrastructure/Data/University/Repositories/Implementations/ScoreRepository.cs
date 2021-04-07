using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Implementations
{
    public class ScoreRepository : GenericRepository<Scores>, IScoreRepository
    {

        private new readonly UniversityContext _context;
        public ScoreRepository(UniversityContext context) : base(context)
        {
            _context = context;
        }

        public List<Scores> GetScoresBy_User(string UserId)
        {

            bool IsAlumno = (from us in _context.Users
                             join rol_us in _context.UserRoles on us.Id equals rol_us.UserId
                             join rol in _context.Roles on rol_us.RoleId equals rol.Id
                             where us.Id.Equals(UserId) && rol.NormalizedName.Equals("ALUMNO")
                             select rol).Any();

            return (from sc in _context.Scores
                    join us in _context.Users on sc.UserId equals us.Id
                    join rol_us in _context.UserRoles on us.Id equals rol_us.UserId
                    join rol in _context.Roles on rol_us.RoleId equals rol.Id
                    join cour in _context.Courses on sc.CourseId equals cour.Id
                    where
                    (IsAlumno == false || us.Id.Equals(UserId))
                    select new Scores
                    {
                        Id = sc.Id,
                        Score = sc.Score,
                        User = us,
                        Course = cour
                    }).ToList();
        }

    }
}

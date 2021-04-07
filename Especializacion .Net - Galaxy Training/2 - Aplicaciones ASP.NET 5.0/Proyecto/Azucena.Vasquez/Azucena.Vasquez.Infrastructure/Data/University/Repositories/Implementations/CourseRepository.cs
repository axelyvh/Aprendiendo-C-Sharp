using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Implementations
{
    public class CourseRepository : GenericRepository<Courses>, ICourseRepository
    {
        public CourseRepository(UniversityContext context) : base(context)
        {

        }
    }
}

using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Contexts;
using Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces;
using System;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories
{
    public class UniversityUnitOfWork : IUnitOfWork<UniversityUnitOfWork>
    {

        private UniversityContext _context;
        public IScoreRepository _scoreRepository { get; }
        public ICourseRepository _courseRepository { get; }
        public IUserRepository _userRepository { get; }
        public IRoleRepository _roleRepository { get; }

        public UniversityUnitOfWork(
            UniversityContext context,
            IScoreRepository scoreRepository,
            ICourseRepository courseRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository
        )
        {
            _context = context;
            _scoreRepository = scoreRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

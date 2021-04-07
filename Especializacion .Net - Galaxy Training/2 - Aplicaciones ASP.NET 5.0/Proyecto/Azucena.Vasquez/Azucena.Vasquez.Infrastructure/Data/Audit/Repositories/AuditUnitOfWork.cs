using Azucena.Vasquez.Infrastructure.Data.Audit.Contexts;
using Azucena.Vasquez.Infrastructure.Data.Base;
using System;

namespace Azucena.Vasquez.Infrastructure.Data.Audit.Repositories
{
    public class AuditUnitOfWork : IUnitOfWork<AuditContext>
    {
        public IAuditLogRepository AuditLogRepository { get; }
        private AuditContext _context;

        public AuditUnitOfWork(
            AuditContext context,
            IAuditLogRepository auditLogRepository
        )
        {
            _context = context;
            AuditLogRepository = auditLogRepository;
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

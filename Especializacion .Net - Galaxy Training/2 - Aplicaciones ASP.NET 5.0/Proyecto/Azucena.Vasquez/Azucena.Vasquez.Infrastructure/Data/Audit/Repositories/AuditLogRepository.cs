using Azucena.Vasquez.Infrastructure.Data.Audit.Contexts;
using Azucena.Vasquez.Infrastructure.Data.Audit.Entities;
using Azucena.Vasquez.Infrastructure.Data.Base;

namespace Azucena.Vasquez.Infrastructure.Data.Audit.Repositories
{
    public class AuditLogRepository : GenericRepository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(AuditContext context) : base(context)
        {

        }
    }
}

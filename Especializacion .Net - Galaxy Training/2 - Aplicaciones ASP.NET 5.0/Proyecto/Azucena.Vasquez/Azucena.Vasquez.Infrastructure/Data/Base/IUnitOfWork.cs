using System;

namespace Azucena.Vasquez.Infrastructure.Data.Base
{
    public interface IUnitOfWork<DBContext> : IDisposable
    {
        void Save();
    }
}

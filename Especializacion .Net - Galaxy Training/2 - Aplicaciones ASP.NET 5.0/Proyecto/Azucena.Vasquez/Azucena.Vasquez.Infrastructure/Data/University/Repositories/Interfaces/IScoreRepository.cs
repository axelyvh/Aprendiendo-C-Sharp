using Azucena.Vasquez.Infrastructure.Data.Base;
using Azucena.Vasquez.Infrastructure.Data.University.Entities;
using System.Collections.Generic;

namespace Azucena.Vasquez.Infrastructure.Data.University.Repositories.Interfaces
{
    public interface IScoreRepository : IGenericRepository<Scores>
    {
        List<Scores> GetScoresBy_User(string UserId);
    }
}

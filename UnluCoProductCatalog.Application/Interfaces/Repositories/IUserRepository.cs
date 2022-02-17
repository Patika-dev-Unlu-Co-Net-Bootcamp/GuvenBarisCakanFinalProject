using System.Collections.Generic;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<OperationClaim> GetClaims(int userId);
    }
}

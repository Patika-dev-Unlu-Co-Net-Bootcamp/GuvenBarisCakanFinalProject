using System.Collections.Generic;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        IEnumerable<OperationClaim> GetClaims(int userId);
        void Create(User user);
        User GetByMail(string email);
    }
}

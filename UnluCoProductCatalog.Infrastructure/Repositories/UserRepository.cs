using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        private readonly ProductCatalogDbContext _context;
        public UserRepository(ProductCatalogDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<OperationClaim> GetClaims(int userId)
        {
            var result = from o in _context.OperationClaims
                where o.Users.Any(c => c.Id == userId)
                select o;

            return result;
        }
    }
}

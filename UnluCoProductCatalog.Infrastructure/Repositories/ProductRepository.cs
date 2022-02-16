using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(ProductCatalogDbContext context) : base(context)
        {
        }


    }
}

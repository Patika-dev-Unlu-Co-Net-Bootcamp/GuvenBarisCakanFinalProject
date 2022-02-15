using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class OfferRepository : RepositoryBase<Offer>,IOfferRepository
    {
        public OfferRepository(ProductCatalogDbContext context) : base(context)
        {
        }
    }
}
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductCatalogDbContext _context;


        public IColorRepository Color { get; }
        public IOfferRepository Offer { get; }
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }
        public IBrandRepository BrandRepository { get; }
        public IUsingStatusRepository UsingStatus { get; }
        public IAccountDetailRepository AccountDetail { get; }


        public UnitOfWork(IColorRepository color, IOfferRepository offer, IProductRepository product,
            ICategoryRepository category, IBrandRepository brandRepository, IUsingStatusRepository usingStatus,
            IAccountDetailRepository accountDetail, ProductCatalogDbContext context)
        {
            Color = color;
            Offer = offer;
            Product = product;
            Category = category;
            BrandRepository = brandRepository;
            UsingStatus = usingStatus;
            AccountDetail = accountDetail;
            _context = context;
        }

        public bool SaveChanges() => _context.SaveChanges() > 0;
    }
}

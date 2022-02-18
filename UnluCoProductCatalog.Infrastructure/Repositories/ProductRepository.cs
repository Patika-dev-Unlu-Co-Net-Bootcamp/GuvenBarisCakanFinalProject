using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Infrastructure.Contexts;

namespace UnluCoProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        private readonly ProductCatalogDbContext _context;
        
        public ProductRepository(ProductCatalogDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            var result = _context.Products.Include(c => c.Brand).Include(c => c.Color)
                .Include(u => u.Users).Include(u => u.UsingStatus).Where(c=>c.CategoryId == id);

            return result.ToList();
        }

        public IEnumerable<Product> GetProductsByCategories()
        {
            var result = _context.Products.Include(c => c.Brand).Include(c => c.Color)
                .Include(u => u.Offers).Include(u => u.UsingStatus);

            return result.ToList();
        }
    }
}

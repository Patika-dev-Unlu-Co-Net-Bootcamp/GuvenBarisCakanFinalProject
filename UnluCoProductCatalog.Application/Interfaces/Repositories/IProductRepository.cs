using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;


namespace UnluCoProductCatalog.Application.Interfaces.Repositories
{
    
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public IEnumerable<Product> GetProductsByCategoryId(int id);
        public IEnumerable<Product> GetProductsByCategories();
    }
}

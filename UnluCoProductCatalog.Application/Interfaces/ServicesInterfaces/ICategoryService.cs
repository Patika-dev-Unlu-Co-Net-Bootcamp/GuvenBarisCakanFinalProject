using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.CategoryViewModels;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAll();
        IEnumerable<GetProductViewModel> GetProductsByCategoryId(int id);
        void Create(CategoryViewModel entity);
        void Update(CategoryViewModel entity,int id);
        void Delete(int id);
    }
}



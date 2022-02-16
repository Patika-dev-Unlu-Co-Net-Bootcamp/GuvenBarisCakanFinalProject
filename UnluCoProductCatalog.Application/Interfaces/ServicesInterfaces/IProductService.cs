using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IProductService
    {
        IEnumerable<GetProductViewModel> GetAll();
        void RetractTheOffer(int productId, int userId);
        void SellProduct(int productId, int userId, double price);
        void Create(CreateProductViewModel entity);
        void Delete(int id);
    }
}
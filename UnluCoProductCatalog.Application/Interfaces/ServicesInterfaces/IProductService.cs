using System.Collections.Generic;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IProductService
    {
        IEnumerable<GetProductViewModel> GetAll();
        void RetractTheOffer(int productId, string userId);
        void SellProduct(int productId, string userId, double price);
        Task Create(CreateProductViewModel entity);
        void Delete(int id);
    }
}
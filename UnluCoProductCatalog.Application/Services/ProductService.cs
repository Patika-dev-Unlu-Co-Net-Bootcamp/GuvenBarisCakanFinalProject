using System.Collections.Generic;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable< GetProductViewModel> GetAll()
        {
            var products = _unitOfWork.Product.GetAll();

            return _mapper.Map<IEnumerable<GetProductViewModel>>(products);
        }

        public void RetractTheOffer(int productId,int userId)
        {
            var product = _unitOfWork.Product.GetById(productId);

            if (product.UserId != userId) return;
            if (product.IsOfferable)
            {
                product.IsOfferable = false;
                _unitOfWork.Product.Update(product);
                _unitOfWork.SaveChanges();
            }
            else
                throw new NotFoundExceptions("Product",productId);
        }

        public void SellProduct(int productId, int userId,double price)
        {
            var product = _unitOfWork.Product.GetById(productId);
            if (!(product.Price > price)) return;
            product.IsSold = true;
            _unitOfWork.Product.Update(product);
            _unitOfWork.SaveChanges();
        }

        public void Create(CreateProductViewModel entity)
        {
            var product = _mapper.Map<Product>(entity);
            product.IsSold = false;
            product.IsOfferable = false;

            _unitOfWork.Product.Create(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }

        public void Delete(int id)
        {
            var product = _unitOfWork.Product.GetById(id);
            product.IsDeleted = true;

            _unitOfWork.Product.Update(product);
            if (!_unitOfWork.SaveChanges())
            {
                throw new NotSavedExceptions("Product");
            }
        }
    }
}

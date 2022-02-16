using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<GetProductViewModel, Product>();
            CreateMap<Product, CreateProductViewModel>();
        }
    }
}

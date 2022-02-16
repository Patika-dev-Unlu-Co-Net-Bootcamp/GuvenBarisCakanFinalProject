using System.Collections.Generic;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection< BrandViewModel> GetAll()
        {
            return _mapper.Map<ICollection<BrandViewModel>>(_unitOfWork.Brand.GetAll());
        }

        public void Update(BrandViewModel entity)
        {
            var brand =_mapper.Map<Brand>(entity);
            _unitOfWork.Brand.Update(brand);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var brand =  _unitOfWork.Brand.GetById(id);
            if (brand is null)
            {
                throw new NotFoundExceptions("Brand", id);
            }

            brand.IsDeleted = true;
            _unitOfWork.Brand.Update(brand);
            _unitOfWork.SaveChanges();
        }
    }
}

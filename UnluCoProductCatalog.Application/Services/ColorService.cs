using System.Collections.Generic;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class ColorService : IColorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection<ColorViewModel> GetAll()
        {
            return _mapper.Map<ICollection<ColorViewModel>>(_unitOfWork.Color.GetAll());
        }


        public void Update(ColorViewModel entity)
        {
            var validator = new ColorViewModelValidator();
            validator.Validate(entity);

            var color = _mapper.Map<Color>(entity);
            _unitOfWork.Color.Update(color);
            _unitOfWork.SaveChanges();
        }

        public void Create(ColorViewModel entity)
        {
            var validator = new ColorViewModelValidator();
            validator.Validate(entity);

            var color = _mapper.Map<Color>(entity);
            _unitOfWork.Color.Create(color);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var color = _unitOfWork.Color.GetById(id);
            if (color is null)
            {
                throw new NotFoundExceptions("Color", id);
            }

            color.IsDeleted = true;
            _unitOfWork.Color.Update(color);
            _unitOfWork.SaveChanges();
        }
    }
}
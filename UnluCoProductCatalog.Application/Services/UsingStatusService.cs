using System.Collections.Generic;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Services
{
    public class UsingStatusService : IUsingStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsingStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ICollection<UsingStatusViewModel> GetAll()
        {
            return _mapper.Map<ICollection<UsingStatusViewModel>>(_unitOfWork.UsingStatus.GetAll());
        }

        public void Update(UsingStatusViewModel entity)
        {
            var usingStatus = _mapper.Map<UsingStatus>(entity);
            _unitOfWork.UsingStatus.Update(usingStatus);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var usingStatus = _unitOfWork.UsingStatus.GetById(id);
            if (usingStatus is null)
            {
                throw new NotFoundExceptions("UsingStatus", id);
            }

            usingStatus.IsDeleted = true;
            _unitOfWork.UsingStatus.Update(usingStatus);
            _unitOfWork.SaveChanges();
        }
    }
}
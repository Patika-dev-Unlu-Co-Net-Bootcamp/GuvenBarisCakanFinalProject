using System;
using System.Threading.Tasks;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.Validations.OfferValidation;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;
using UnluCoProductCatalog.Domain.Entities;


namespace UnluCoProductCatalog.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task Create(CreateOfferViewModel entity)
        {
            var validator = new CreateOfferViewModelValidator();
            await validator.ValidateAsync(entity);

            var product =  _unitOfWork.Product.GetById(entity.ProductId);

            if (!product.IsOfferable)
            {
                throw new InvalidOperationException("Product status is not offered");
            }

 
            var offeredPrice = (product.Price * entity.Percent) / 100;

            if (entity.OfferPrice > offeredPrice)
            {
              throw new InvalidOperationException("Offer is much higher to for price");
            }
            
            var offer = _mapper.Map<Offer>(entity);
            offer.OfferedPrice = offeredPrice;

            _unitOfWork.Offer.Create(offer);

            if (!_unitOfWork.SaveChanges())
            {
                throw new InvalidOperationException("Offer can not be created");
            }
        }

        public void Delete(int id)
        {
            var offer = _unitOfWork.Offer.GetById(id);

            if (offer is null)
                throw new NotFoundExceptions("Offer", id);

            offer.IsDeleted = false;

            _unitOfWork.Offer.Update(offer);
            
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Offer");
        }

        public async Task Update(UpdateOfferViewModel entity,int id)
        {
            var validator = new UpdateOfferViewModelValidator();
            await validator.ValidateAsync(entity);

            //var offer =  _unitOfWork.Offer.GetById(id);
            var offer = _mapper.Map<Offer>(entity);

            if (offer is null)
            {
                throw new NotFoundExceptions("Offer", id);
            }
            
            _unitOfWork.Offer.Update(offer);
            if (!_unitOfWork.SaveChanges())
                throw new NotSavedExceptions("Offer");

        }

        public void OfferApprove(int offerId)
        {
            var offer = _unitOfWork.Offer.GetById(offerId);
            if (offer.IsApproved)
            {
                offer.IsSold = true;
            }

            offer.IsSold = false;
        }
    }
}

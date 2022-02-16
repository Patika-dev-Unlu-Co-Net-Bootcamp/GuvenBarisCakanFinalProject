using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
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


        public IEnumerable<GetOfferQueryViewModel> GetUserOffer(int userId)
        {
            var offers = _unitOfWork.AccountDetail.Get(a => a.UserId == userId)
                .SelectMany(o => o.Offers).Where(o =>o.IsSold == false);

            return _mapper.Map<IEnumerable<GetOfferQueryViewModel>>(offers);
        }

        public IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(int userId)
        {

            var offers = _unitOfWork.AccountDetail.Get(a => a.UserId == userId)
                .SelectMany(x => x.Products).SelectMany(x=>x.Offers).Where(o => o.IsSold == false); ;

            return _mapper.Map<IEnumerable<GetOfferQueryViewModel>>(offers);
        }

        public void Create(CreateOfferViewModel entity)
        {
            if (entity.OfferPrice < 0)
            {
                //Validasyon eklenecek
                throw new InvalidOperationException("Price is not valid");
            }

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

        public void OfferApprove(UpdateOfferViewModel entity,int offerId)
        {
            var offer = _unitOfWork.Offer.GetById(offerId);
            if (entity.IsApproved)
            {
                offer.IsSold = true;
            }

            offer.IsSold = false;
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
    }
}

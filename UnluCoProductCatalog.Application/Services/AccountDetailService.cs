using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Services
{
    public class AccountDetailService :IAccountDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GetOfferUserViewModel> GetUserOffers(string userId)
        {

            return _unitOfWork.Offer.GetUserOffers(userId);
        }

        public IEnumerable<GetOfferUserViewModel> GetOffersOnUserProducts(string userId)
        {
            //IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(string userId);
            //var offers = _unitOfWork.AccountDetail.Get(a => a.UserId == userId)
            //    .SelectMany(x => x.Products).SelectMany(x => x.Offers).Where(o => o.IsSold == false); ;

            //return _mapper.Map<IEnumerable<GetOfferUserViewModel>>(offers);

            return _unitOfWork.Offer.GetOffersOnUserProducts(userId);
        }
    }
}

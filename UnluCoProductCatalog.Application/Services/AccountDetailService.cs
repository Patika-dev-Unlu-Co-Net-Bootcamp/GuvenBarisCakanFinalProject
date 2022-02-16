using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Services
{
    public class AccountDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<GetOfferQueryViewModel> GetUserOffer(int userId)
        {
            var offers = _unitOfWork.AccountDetail.Get(a => a.UserId == userId)
                .SelectMany(o => o.Offers).Where(o => o.IsSold == false);

            return _mapper.Map<IEnumerable<GetOfferQueryViewModel>>(offers);
        }

        public IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(int userId)
        {

            var offers = _unitOfWork.AccountDetail.Get(a => a.UserId == userId)
                .SelectMany(x => x.Products).SelectMany(x => x.Offers).Where(o => o.IsSold == false); ;

            return _mapper.Map<IEnumerable<GetOfferQueryViewModel>>(offers);
        }
    }
}

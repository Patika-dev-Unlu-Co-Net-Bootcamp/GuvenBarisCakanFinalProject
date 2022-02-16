using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IOfferService
    {
        IEnumerable<GetOfferQueryViewModel> GetUserOffer(int userId);
        IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(int userId);
        void Create(CreateOfferViewModel entity);
        void OfferApprove(UpdateOfferViewModel entity,int offerId);
        void Delete(int entity);
    }
}

using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IAccountDetailService
    {
        IEnumerable<GetOfferQueryViewModel> GetUserOffer(int userId);
        IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(int userId);
    }
}

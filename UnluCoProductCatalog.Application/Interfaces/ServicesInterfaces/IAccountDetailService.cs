﻿using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IAccountDetailService
    {
        IEnumerable<GetOfferQueryViewModel> GetUserOffer(string userId);
        IEnumerable<GetOfferQueryViewModel> GetOffersOnUserProducts(string userId);
    }
}

using AutoMapper;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.Mapping
{
    public class OfferProfile :Profile
    {
        public OfferProfile()
        {
            CreateMap<GetOfferQueryViewModel, Offer>();
        }
    }
}

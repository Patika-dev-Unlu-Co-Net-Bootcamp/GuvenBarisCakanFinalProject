using System.Security.Principal;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IOfferService
    {
        void Create(CreateOfferViewModel entity);
        void Delete(int entity);
        void OfferApprove( int offerId);
        void Update(UpdateOfferViewModel entity,int id);
    }
}

using System.Security.Principal;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IOfferService
    {
        Task Create(CreateOfferViewModel entity);
        void Delete(int entity);
        void OfferApprove( int offerId);
        Task Update(UpdateOfferViewModel entity,int id);
    }
}

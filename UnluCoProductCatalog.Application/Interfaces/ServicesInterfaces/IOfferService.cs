using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.OfferViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IOfferService
    {
        IEnumerable<OfferViewModel> GetAll();
        IEnumerable<OfferViewModel> GetById(int id);
        void Create(OfferViewModel entity);
        void Update(OfferViewModel entity);
        void Delete(OfferViewModel entity);
    }
}

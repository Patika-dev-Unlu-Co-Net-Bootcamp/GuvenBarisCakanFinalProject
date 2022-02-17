using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.BrandViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IBrandService
    {
        ICollection<BrandViewModel> GetAll();
        void Update(BrandViewModel entity);
        void Create(BrandViewModel entity);
        void Delete(int id);
    }

}
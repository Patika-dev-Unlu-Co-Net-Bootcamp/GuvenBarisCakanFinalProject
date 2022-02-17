using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.UsingStatusViewModels;

namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IUsingStatusService
    {
        ICollection<UsingStatusViewModel> GetAll();
        void Update(UsingStatusViewModel entity);
        void Create(UsingStatusViewModel entity);
        void Delete(int id);
    }
}
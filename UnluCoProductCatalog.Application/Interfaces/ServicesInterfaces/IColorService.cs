using System.Collections.Generic;
using UnluCoProductCatalog.Application.ViewModels.ColorViewModels;


namespace UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces
{
    public interface IColorService
    {
        ICollection<ColorViewModel> GetAll();
        void Update(ColorViewModel entity);
        void Create(ColorViewModel entity);
        void Delete(int id);
    }
}


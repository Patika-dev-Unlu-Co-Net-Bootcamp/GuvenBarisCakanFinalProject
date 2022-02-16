
using System.Collections.Generic;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class CreateProductViewModel 
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string UserName { get; set; }
        public string UsingStatus { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}

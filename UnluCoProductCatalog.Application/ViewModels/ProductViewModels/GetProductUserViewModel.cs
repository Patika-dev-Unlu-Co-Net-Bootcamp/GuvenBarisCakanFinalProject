using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class GetProductUserViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
  public class GetOfferUserViewModel
    {
        public int PercentRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public GetProductUserViewModel Product { get; set; }
        public double OfferedPrice { get; set; }
        public bool IsApproved { get; set; }
    }
}

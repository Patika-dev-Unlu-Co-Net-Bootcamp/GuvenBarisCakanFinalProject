using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
    public class UpdateOfferViewModel
    {
        public int Percent { get; set; }
        public double OfferPrice { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
    }
}

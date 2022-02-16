using System;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
    public class GetOfferQueryViewModel
    {
        public int Percent { get; set; }
        public DateTime CreatedTime { get; set; }
        public Product Product { get; set; }
        public string UserName { get; set; }
    }
}

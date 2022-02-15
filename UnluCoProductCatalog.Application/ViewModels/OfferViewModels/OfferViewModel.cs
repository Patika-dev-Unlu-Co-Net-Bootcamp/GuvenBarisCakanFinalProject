using System;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
    public class OfferViewModel
    {
        public float Percent { get; set; }
        public DateTime CreatedTime { get; set; }
        public Product Product { get; set; }
        public string UserName { get; set; }
    }
}


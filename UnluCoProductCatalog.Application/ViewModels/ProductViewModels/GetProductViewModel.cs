﻿
using System.Collections.Generic;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Application.ViewModels.ProductViewModels
{
    public class GetProductViewModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsOfferable { get; set; } = false;
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public List<Offer> Offers { get; set; }
        public string UserName { get; set; }
        public string UsingStatus { get; set; }
    }
}

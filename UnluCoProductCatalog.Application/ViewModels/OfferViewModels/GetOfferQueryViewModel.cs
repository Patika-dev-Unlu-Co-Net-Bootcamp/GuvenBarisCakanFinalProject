﻿using System;
using UnluCoProductCatalog.Application.ViewModels.ProductViewModels;

namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
    public class GetOfferQueryViewModel
    {
        public int PercentRate { get; set; }
        public DateTime CreatedTime { get; set; }
        public GetProductViewModel Product { get; set; }
        public double OfferedPrice { get; set; }
        public bool IsApproved { get; set; }
    }
}

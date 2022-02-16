using System;


namespace UnluCoProductCatalog.Application.ViewModels.OfferViewModels
{
    public class CreateOfferViewModel
    {
        public int Percent { get; set; }
        public double OfferPrice { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}

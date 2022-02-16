
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

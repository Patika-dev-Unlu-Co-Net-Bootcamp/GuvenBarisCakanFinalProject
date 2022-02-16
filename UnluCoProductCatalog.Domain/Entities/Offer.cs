namespace UnluCoProductCatalog.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public int Percent { get; set; } = 40;
        public bool IsApproved { get; set; }
        public bool IsSold { get; set; } = false;
        public  double OfferedPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
namespace UnluCoProductCatalog.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public float Percent { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
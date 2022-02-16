using System.Collections.Generic;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class AccountDetail : BaseEntity
    {
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Product> Products { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
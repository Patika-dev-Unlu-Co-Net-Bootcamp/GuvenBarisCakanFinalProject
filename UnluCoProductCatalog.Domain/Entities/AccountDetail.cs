using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class AccountDetail : BaseEntity
    {
        public ICollection<Offer> Offers { get; set; }
        public ICollection<Product> Products { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
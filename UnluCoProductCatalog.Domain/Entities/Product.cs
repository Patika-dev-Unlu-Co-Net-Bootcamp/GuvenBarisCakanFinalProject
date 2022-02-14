using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnluCoProductCatalog.Domain.Entities
{
    public class Product : BaseEntity 
    {
        public string ProductName { get; set; } 
        public string Description { get; set; }
        public bool IsOfferable { get; set; } = false;
        public bool IsSold { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category> Categories { get; set; }
        public  ICollection<Color> Colors { get; set; }
        public  ICollection<Brand> Brands { get; set; }
        public  ICollection<Offer> Offers { get; set; }
        public ICollection<User> Users { get; set; }
        [Required]
        public ICollection<UsingStatus> UsingStatuses { get; set; }
        [Required]
        public string Image { get; set; }
        public double Price { get; set; }

    }
}
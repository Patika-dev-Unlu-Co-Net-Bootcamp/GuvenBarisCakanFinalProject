using Microsoft.EntityFrameworkCore;
using UnluCoProductCatalog.Domain.Entities;

namespace UnluCoProductCatalog.Infrastructure.Contexts
{
    public class ProductCatalogDbContext : DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options ): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UsingStatus> UsingStatuses { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Interfaces.Repositories;
using UnluCoProductCatalog.Application.Interfaces.UnitOfWorks;
using UnluCoProductCatalog.Infrastructure.Contexts;
using UnluCoProductCatalog.Infrastructure.Repositories;
using UnluCoProductCatalog.Infrastructure.UnitOfWorks;

namespace UnluCoProductCatalog.Infrastructure.DependencyContainers
{
    public static class DependencyContainer 
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProductCatalogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUsingStatusRepository, UsingStatusRepository>();
            services.AddScoped<IAccountDetailRepository, AccountDetailRepository>();
        
        }
    }
}

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Jwt;
using UnluCoProductCatalog.Domain.Entities;
using UnluCoProductCatalog.Domain.Jwt;

namespace UnluCoProductCatalog.Application.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<TokenGenarator>();

        }
    }
}

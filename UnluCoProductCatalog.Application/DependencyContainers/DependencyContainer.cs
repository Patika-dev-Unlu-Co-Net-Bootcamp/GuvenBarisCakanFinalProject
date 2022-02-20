using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using UnluCoProductCatalog.Application.Jwt;
using UnluCoProductCatalog.Application.RabbitMQ;
using UnluCoProductCatalog.Application.Services.Mail;

namespace UnluCoProductCatalog.Application.DependencyContainers
{
    public static class DependencyContainer
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<TokenGenarator>();
            services.AddScoped<IRabbitMqService,RabbitMqService>();
            services.AddScoped<IPusblisherService, PusblisherService>();
            //services.AddScoped<ISmtpServer, SmtpServer>();


        }
    }
}

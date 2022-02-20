using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace UnluCoProductCatalog.Application.RabbitMQ
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConfiguration _configuration;

        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new()
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }

}

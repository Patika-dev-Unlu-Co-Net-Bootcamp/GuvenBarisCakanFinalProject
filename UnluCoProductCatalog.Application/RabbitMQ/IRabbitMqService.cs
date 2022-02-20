using RabbitMQ.Client;

namespace UnluCoProductCatalog.Application.RabbitMQ
{
    public interface IRabbitMqService
    {
        IConnection GetRabbitMqConnection();
    }
}

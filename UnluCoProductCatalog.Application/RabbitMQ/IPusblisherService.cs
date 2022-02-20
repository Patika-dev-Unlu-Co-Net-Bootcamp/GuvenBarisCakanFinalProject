using UnluCoProductCatalog.Application.Services.Mail;

namespace UnluCoProductCatalog.Application.RabbitMQ
{
    public interface IPusblisherService
    {
        void Publish(Email email, string queueName);
    }
}

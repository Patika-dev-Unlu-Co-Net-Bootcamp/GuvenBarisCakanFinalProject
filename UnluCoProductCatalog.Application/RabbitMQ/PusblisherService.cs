using System.Text;
using RabbitMQ.Client;
using UnluCoProductCatalog.Application.Interfaces;
using UnluCoProductCatalog.Application.Services.Mail;

namespace UnluCoProductCatalog.Application.RabbitMQ
{
    public class PusblisherService : IPusblisherService
    {
        private readonly IRabbitMqService _rabbitMqService;


        public PusblisherService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void Publish(Email email,string queueName)
        {
            using var connection = _rabbitMqService.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, false, false, false, null);
            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(email));

            channel.BasicPublish("", queueName, null, body: body);

        }
    }
}


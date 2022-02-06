using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQSample
{
    public class Consumer
    {
        private readonly RabbitMQService _rabbitMQService;
 
        public Consumer(string queueName)
        {
            _rabbitMQService = new RabbitMQService();
 
            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    // Received event'i sürekli listen modunda olacaktır.
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
 
                        Console.WriteLine("{0} isimli queue üzerinden gelen mesaj: \"{1}\"", queueName, message);
                    };
 
                    channel.BasicConsume(queueName, true, consumer);
                    Console.ReadLine();
                }
            }
        }
    }
}

using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQSample
{
    public class RabbitMQService
    {   
        private readonly string _hostname = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = _hostname
            };

            return connectionFactory.CreateConnection();
        }
    }
}

using RabbitMQ.Client;

namespace QueueService
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

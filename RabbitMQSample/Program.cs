using System;

namespace RabbitMQSample
{
    class Program
    {
        private static readonly string _queueName = "ABDURRAHMANISIK";
        private static Publisher _publisher;
        private static Consumer _consumer;

        static void Main(string[] args)
        {
            _publisher = new Publisher(_queueName, "Hello world!");
              
            _consumer = new Consumer(_queueName);
        }
    }
}

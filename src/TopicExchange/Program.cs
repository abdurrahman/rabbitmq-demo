using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Topic Exchange - RabbitMQ");

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

Console.WriteLine("Create a topic");
var exchangeName = Console.ReadLine();
channel.ExchangeDeclare(exchangeName, ExchangeType.Topic,false ,false);

Console.WriteLine("Give us a queue name:");
var queueName = Guid.NewGuid().ToString()[0..8];
Console.WriteLine($"QueueName: {queueName}");

channel.QueueDeclare(queueName, true, true, true);
channel.QueueBind(queueName, exchangeName, string.Empty);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, eventArgs) =>
{
    var text = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
    Console.WriteLine($"{eventArgs.Exchange} - {text}");
};

channel.BasicConsume(queueName, true, consumer);

var input = Console.ReadLine();
while (input != string.Empty)
{
    var bytes = Encoding.UTF8.GetBytes(input);
    channel.BasicPublish(exchangeName, string.Empty, null, bytes);
    input = Console.ReadLine();
}
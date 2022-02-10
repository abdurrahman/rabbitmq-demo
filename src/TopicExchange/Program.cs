// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
var connection = factory.CreateConnection();
var channel = connection.CreateModel();
         
var exchangeName = "chat";
var queueName = System.Guid.NewGuid().ToString();
            
channel.ExchangeDeclare(exchangeName, ExchangeType.Fanout);
channel.QueueDeclare(queueName, true, true, true);
channel.QueueBind(queueName, exchangeName, string.Empty);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (sender, eventArgs) =>
{
    var text = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
    Console.WriteLine(text);
};

channel.BasicConsume(queueName, true, consumer);

var input = Console.ReadLine();
while (input != string.Empty)
{
    Console.SetCursorPosition(0, Console.CursorTop - 1);

    var bytes = Encoding.UTF8.GetBytes(input);
    channel.BasicPublish(exchangeName, string.Empty, null, bytes);
    input = Console.ReadLine();
}
            
channel.Close();
connection.Close();
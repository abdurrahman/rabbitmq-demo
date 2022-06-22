using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ;

internal class ExchangeQueueDeclareBehavior : IQueueDeclareBehavior<ExchangeQueueInstanceOption>
{
    public void Declare(IModel channel, ExchangeQueueInstanceOption option)
    {
        channel.ExchangeDeclare(
            exchange: option.Exchange,
            type: option.Type,
            autoDelete: false);

        var queueName = channel.QueueDeclare(
            queue: option.QueueName,
            exclusive: option.Exclusive,
            autoDelete: option.AutoDelete).QueueName;

        var routes = option.Routes.Any()
            ? option.Routes
            : new List<string>() { string.Empty };

        foreach (var routingKey in routes)
        {
            channel.QueueBind(
                queue: queueName,
                exchange: option.Exchange,
                routingKey: routingKey
            );
        }
    }
}

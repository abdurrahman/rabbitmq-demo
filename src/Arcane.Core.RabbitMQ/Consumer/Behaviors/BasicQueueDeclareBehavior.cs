using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ;

internal class BasicQueueDeclareBehavior : IQueueDeclareBehavior<BasicQueueInstanceOption>
{
    public void Declare(IModel channel, BasicQueueInstanceOption option)
    {
        channel.QueueDeclare(queue: option.QueueName,
            durable: option.Durable,
            exclusive: option.Exclusive,
            autoDelete: option.AutoDelete,
            arguments: null);
    }
}

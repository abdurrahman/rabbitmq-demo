using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Arcane.Core.RabbitMQ;

internal class BasicMessageReceiveBehavior : IMessageReceiveBehavior
{
    public Task OnReceive(IModel channel, BasicDeliverEventArgs arg, Func<byte[], DeliverProperties, Task> consumer)
    {
        throw new NotImplementedException();
    }
}
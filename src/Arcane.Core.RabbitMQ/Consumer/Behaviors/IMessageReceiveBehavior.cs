using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Arcane.Core.RabbitMQ;

internal interface IMessageReceiveBehavior
{
    Task OnReceive(IModel channel,
        BasicDeliverEventArgs arg,
        Func<ReadOnlyMemory<byte>, DeliverProperties, Task> consumer);
}

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Arcane.Core.RabbitMQ;

internal class BasicMessageReceiveBehavior : IMessageReceiveBehavior
{
    private readonly bool _autoAck;
    
    public BasicMessageReceiveBehavior(bool autoAck)
    {
        _autoAck = autoAck;
    }
    
    public async Task OnReceive(IModel channel,
        BasicDeliverEventArgs arg,
        Func<ReadOnlyMemory<byte>, DeliverProperties, Task> consumer)
    {
        await consumer(arg.Body, arg.ConvertToDeliverProperties());
        if (!_autoAck)
        {
            channel.BasicAck(arg.DeliveryTag, multiple: false);
        }
    }
}

using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ.Publisher;

public class BasicPublisherService : IPublisherService
{
    private readonly IModel _channel;
    private readonly BasicQueueInstanceOption _option;

    public BasicPublisherService(IModel channel, BasicQueueInstanceOption option)
    {
        _channel = channel;
        _option = option;
    }

    public async Task PublishAsync(object data, BasicDeliverProperties? publishProperties = null)
    {
        await Task.Run(() => _channel.BasicPublish(
            exchange: string.Empty,
            routingKey: _option.QueueName,
            basicProperties: publishProperties?.ConvertToBasicProperties(_channel) ?? _channel.CreateBasicProperties(),
            body: data.SerializeToByteArray()
            )
        );
    }
}
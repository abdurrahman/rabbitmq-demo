using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ.Publisher;

public class ExchangePublisherService : IPublisherService
{
    private readonly IModel _channel;
    private readonly ExchangeQueueInstanceOption _option;
    
    public ExchangePublisherService(IModel channel, ExchangeQueueInstanceOption option)
    {
        channel.ExchangeDeclare(
            exchange: option.Exchange,
            type: option.Type,
            autoDelete: false);
        
        _channel = channel;
        _option = option;
    }
    
    public Task PublishAsync(object data, BasicDeliverProperties? publishProperties = null)
    {
        throw new NotImplementedException();
    }
}
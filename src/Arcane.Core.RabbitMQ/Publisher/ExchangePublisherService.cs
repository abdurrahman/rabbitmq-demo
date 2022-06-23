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
    
    public async Task PublishAsync(object data, BasicDeliverProperties? publishProperties = null)
    {
        var basicProperties = publishProperties?.ConvertToBasicProperties(_channel) ?? _channel.CreateBasicProperties();

        var routes = _option.Routes.Any()
            ? _option.Routes
            : new List<string>() {string.Empty};

        var byteData = data.SerializeToByteArray();

        if (_option.Routes.Count() == 1)
        {
            await Task.Run(() => _channel.BasicPublish(
                exchange: _option.Exchange,
                routingKey: _option.Routes.First(),
                basicProperties: basicProperties,
                body: byteData
            ));
        }
        else
        {
            var publishBatch = _channel.CreateBasicPublishBatch();
            foreach (var route in routes)
            {
                // Todo: Use non-obsolete method
                publishBatch.Add(
                    exchange: _option.Exchange,
                    routingKey: _option.Routes.First(),
                    mandatory: false,
                    properties: basicProperties,
                    body: byteData
                );
            }

            await Task.Run(() => publishBatch.Publish());
        }
    }
}

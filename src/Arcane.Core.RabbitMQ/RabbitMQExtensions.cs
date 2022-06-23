using Arcane.Core.RabbitMQ.Models;
using Arcane.Core.RabbitMQ.Publisher;
using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ;

public static class RabbitMQExtensions
{
    public static void UseRabbitMQ(
        this IPublisherServiceOptionBuilder<ExchangeQueueInstanceOption> publisherServiceBuilder,
        ConnectionInfo connectionInfo)
    {
        publisherServiceBuilder.SetPublisherServiceOptions((sp, option) =>
            new ExchangePublisherService(
                channel: CreateChannel(connectionInfo),
                option: option)
            ,
            null
        );
    }

    private static IModel CreateChannel(ConnectionInfo connectionInfo)
        => ConnectionContainer.GetConnection(connectionInfo).CreateModel();

    private static Func<byte[], DeliverProperties, Task> GetConsumerAction(
        Type bodyType, Func<object, DeliverProperties, Task> consumerAction)
        => (body, properties) => consumerAction(body.DeserializeFromByteArray(bodyType), properties);
}

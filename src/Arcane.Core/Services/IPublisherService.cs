namespace Arcane.Core;

public interface IPublisherService
{
    Task PublishAsync(object data, BasicDeliverProperties? publishProperties = null);
}
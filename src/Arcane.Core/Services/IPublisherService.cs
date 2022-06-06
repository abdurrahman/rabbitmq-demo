namespace Arcane.Core;

public interface IPublisherService
{
    Task PublishAsync(object data, object? publishProperties = null);
}
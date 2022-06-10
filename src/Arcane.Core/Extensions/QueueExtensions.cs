using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core.Extensions;

public static class QueueExtensions
{
    public static IServiceCollection AddQueuePublishers(this IServiceCollection services,
        Action<IPublisherServiceProviderBuilder> publisherServiceProviderBuilderAction)
    {
        var publisherServiceProviderBuilder = new PublisherServiceProviderBuilder(services);
        publisherServiceProviderBuilderAction(publisherServiceProviderBuilder);
        var injection = publisherServiceProviderBuilder.Build();

        services.AddSingleton(injection);
        return services;
    }
}
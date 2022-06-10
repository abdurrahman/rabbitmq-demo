using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

internal class PublisherServiceProviderBuilder : IPublisherServiceProviderBuilder
{
    private readonly IServiceCollection _services;
    private readonly IDictionary<string, Func<IServiceProvider, IPublisherService>> _publisherServiceProviders;

    public PublisherServiceProviderBuilder(IServiceCollection services)
    {
        _services = services;
        _publisherServiceProviders = new Dictionary<string, Func<IServiceProvider, IPublisherService>>();
    }
    
    public IPublisherServiceProviderBuilder AddPublisher<TOption>(
        string tag,
        TOption option,
        Action<IPublisherServiceOptionBuilder<TOption>> serviceBuilderAction)
        where TOption : BasicQueueInstanceOption
    {
        var publisherServiceOptionBuilder = new PublisherServiceOptionBuilder<TOption>();
        serviceBuilderAction?.Invoke(publisherServiceOptionBuilder);
        var publisherServiceOption = publisherServiceOptionBuilder.Build(option);
        publisherServiceOption.QueueServiceInjection?.Invoke(_services);
        _publisherServiceProviders.Add(tag, publisherServiceOption.QueueServiceFactory);

        return this;
    }

    public IPublisherServiceProviderBuilder AddBasicPublisher(
        string tag,
        BasicQueueInstanceOption option,
        Action<IPublisherServiceOptionBuilder<BasicQueueInstanceOption>> serviceBuilderAction) 
        => AddPublisher(tag, option, serviceBuilderAction);

    public IPublisherServiceProviderBuilder AddExchangePublisher(
        string tag,
        ExchangeQueueInstanceOption option,
        Action<IPublisherServiceOptionBuilder<ExchangeQueueInstanceOption>> serviceBuilderAction)
        => AddPublisher(tag, option, serviceBuilderAction);

    public Func<IServiceProvider, IPublisherServiceProvider> Build() =>
        sp => new PublisherServiceProvider(_publisherServiceProviders.ToDictionary(c => c.Key, c => c.Value(sp)));
}
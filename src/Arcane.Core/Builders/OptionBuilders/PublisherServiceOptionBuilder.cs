using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

internal class PublisherServiceOptionBuilder<TOption> : IPublisherServiceOptionBuilder<TOption>
    where TOption : BasicQueueInstanceOption
{
    private Func<IServiceProvider, TOption, IPublisherService>? _publisherServiceFactory = null;
    private Action<IServiceCollection>? _injection;
    
    public void SetPublisherServiceOptions(
        Func<IServiceProvider, TOption, IPublisherService> publisherServiceFactory,
        Action<IServiceCollection>? injection)
    {
        _publisherServiceFactory = publisherServiceFactory;
        _injection = injection;
    }

    public QueueServiceOption<IPublisherService> Build(TOption option)
    {
        if (_publisherServiceFactory == null)
        {
            throw new NullReferenceException($"No service for {typeof(TOption).Name.ToLower()} option is set");
        }

        return new QueueServiceOption<IPublisherService>(
            sp => _publisherServiceFactory(sp, option),
            _injection);
    }
}
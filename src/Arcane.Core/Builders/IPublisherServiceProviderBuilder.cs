namespace Arcane.Core;

public interface IPublisherServiceProviderBuilder
{
    public IPublisherServiceProviderBuilder AddPublisher<TOption>(
        string tag,
        TOption option,
        Action<IPublisherServiceOptionBuilder<TOption>> serviceBuilderAction)
        where TOption : BasicQueueInstanceOption;

    public IPublisherServiceProviderBuilder AddBasicPublisher(
        string tag,
        BasicQueueInstanceOption option,
        Action<IPublisherServiceOptionBuilder<BasicQueueInstanceOption>> serviceBuilderAction);

    public IPublisherServiceProviderBuilder AddExchangePublisher(
        string tag,
        ExchangeQueueInstanceOption option,
        Action<IPublisherServiceOptionBuilder<ExchangeQueueInstanceOption>> serviceBuilderAction);
}
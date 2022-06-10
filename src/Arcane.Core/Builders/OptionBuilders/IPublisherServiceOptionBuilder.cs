using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

public interface IPublisherServiceOptionBuilder<TOption>
    where TOption : BasicQueueInstanceOption
{
    void SetPublisherServiceOptions(
        Func<IServiceProvider, TOption, IPublisherService> publisherServiceFactory,
        Action<IServiceCollection>? injection
    );
}
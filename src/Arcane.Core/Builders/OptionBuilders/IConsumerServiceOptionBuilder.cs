using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

public interface IConsumerServiceOptionBuilder
{
    void SetConsumerServiceOptions(
        Func<ConsumerServiceOption, IConsumerService> consumerServiceFactory,
        Action<IServiceCollection>? injection);
}
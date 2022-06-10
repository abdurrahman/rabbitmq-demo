using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

internal class ConsumerServiceOptionBuilder : IConsumerServiceOptionBuilder
{
    private Func<ConsumerServiceOption, IConsumerService>? _consumerServiceFactory = null;
    private Action<IServiceCollection>? _injection;
    
    public void SetConsumerServiceOptions(
        Func<ConsumerServiceOption, IConsumerService> consumerServiceFactory,
        Action<IServiceCollection>? injection)
    {
        _consumerServiceFactory = consumerServiceFactory;
        _injection = injection;
    }

    public QueueServiceOption<IConsumerService> Build(
        Type bodyType,
        object option,
        Func<IServiceProvider, Func<object, DeliverProperties, Task>> consumerActionFactory)
    {
        if (_consumerServiceFactory == null)
        {
            throw new NullReferenceException("No service option is set");
        }

        return new QueueServiceOption<IConsumerService>(
            sp =>
            {
                var serviceScopeFactory = sp.GetService<IServiceScopeFactory>();
                var consumerServiceOption = new ConsumerServiceOption(
                    sp, option, bodyType, consumerAction: async (body, properties) =>
                    {
                        using (var scope = serviceScopeFactory.CreateScope())
                        {
                            var consumerAction = consumerActionFactory(scope.ServiceProvider);
                            await consumerAction(body, properties);
                        }
                    });
                return _consumerServiceFactory(consumerServiceOption);
            }, 
            _injection
        );
    }
}
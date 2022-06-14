using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core.Factories;

public static class ConsumerFactory
{
    private static readonly ConcurrentDictionary<Guid, IConsumerService> ConsumerServices
        = new ConcurrentDictionary<Guid, IConsumerService>();

    public static Guid CreateConsumer(
        Type consumerType,
        IStartup startup,
        object option,
        Action<IConsumerServiceOptionBuilder> serviceBuilderAction)
    {
        var consumerServiceOptionBuilder = new ConsumerServiceOptionBuilder();
        serviceBuilderAction(consumerServiceOptionBuilder);
        var consumerMethod = consumerType.GetMethod(nameof(IConsumer<object>.ConsumeAsync));
        var bodyType = consumerMethod?.GetParameters().First().ParameterType;
        var consumerServiceOption = consumerServiceOptionBuilder.Build(bodyType, option, sp =>
            {
                var consumer = sp.GetService(consumerType);
                return (body, properties) => (Task) consumerMethod.Invoke(consumer, new[] {body, properties});
            }
        );

        var services = ServiceCollectionFactory.CreateServiceCollection(startup.InitConfiguration, startup.Configure);
        services.AddScoped(consumerType);
        consumerServiceOption.QueueServiceInjection?.Invoke(services);
        var serviceProvider = services.BuildServiceProvider();
        startup.ConfigureServices(serviceProvider);
        var consumerService = consumerServiceOption.QueueServiceFactory(serviceProvider);
        var id = Guid.NewGuid();
        ConsumerServices[id] = consumerService;
        consumerService.RunAsync();
        return id;
    }

    public static void DestroyConsumer(Guid id)
    {
        if (!ConsumerServices.TryRemove(id, out var consumerService))
        {
            return;
        }
        consumerService.Dispose();
    }
}
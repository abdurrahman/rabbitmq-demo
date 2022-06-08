using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

public class QueueServiceOption<TQueueService>
{
    public Action<IServiceCollection>? QueueServiceInjection { get; set; }
    public Func<IServiceProvider, TQueueService> QueueServiceFactory { get; set; }

    public QueueServiceOption(
        Func<IServiceProvider, TQueueService> queueServiceFactory,
        Action<IServiceCollection>? queueServiceInjection = null)
    {
        QueueServiceInjection = queueServiceInjection;
        QueueServiceFactory = queueServiceFactory;
    }
}

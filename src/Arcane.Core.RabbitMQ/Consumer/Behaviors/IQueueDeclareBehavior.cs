using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ;

internal interface IQueueDeclareBehavior<TOption> 
    where TOption : BasicQueueInstanceOption
{
    void Declare(IModel channel, TOption option);
}
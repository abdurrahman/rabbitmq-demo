namespace Arcane.Core;

public class BasicQueueInstanceOption
{
    public virtual string QueueName { get; set; }
    public virtual bool AutoDelete { get; set; }
    public virtual bool Durable { get; set; }
    public virtual bool Exclusive { get; set; }

    public BasicQueueInstanceOption(string queueName)
    {
        QueueName = queueName;
    }
}
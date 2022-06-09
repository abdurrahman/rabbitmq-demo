namespace Arcane.Core;

public class MultipleQueueInstanceOption : BasicQueueInstanceOption
{
    public uint PrefetchSizeGlobal { get; set; }
    public uint PrefetchSizePerConsumer { get; set; }
    public ushort PrefetchCountGlobal { get; set; }
    public ushort PrefetchCountPerConsumer { get; set; } = 1;
    
    public MultipleQueueInstanceOption(string queueName) 
        : base(queueName)
    {
    }
}
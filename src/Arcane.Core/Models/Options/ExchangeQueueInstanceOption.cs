namespace Arcane.Core;

public class ExchangeQueueInstanceOption : BasicQueueInstanceOption
{
    public virtual string Type { get; set; }
    public virtual string Exchange { get; set; }
    public virtual IEnumerable<string> Routes { get; set; }
    
    public ExchangeQueueInstanceOption(string queueName, string exchange, string type = ExchangeType.Fanout) 
        : base(queueName)
    {
        Exchange = exchange;
        Routes = new List<string>();
        Type = type;
    }
}
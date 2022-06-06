namespace Arcane.Core;

public class DeliverProperties
{
    public string? ConsumerTag { get; set; }
    public ulong DeliveryTag { get; set; }
    public string? Exchange { get; set; }
    public bool Redelivered { get; set; }
    public string? Route { get; set; }
    public BasicDeliverProperties BasicProperties { get; set; }

    public DeliverProperties()
    {
        BasicProperties = new BasicDeliverProperties();
    }
    
}
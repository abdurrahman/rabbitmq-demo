namespace Arcane.Core;

public class BasicDeliverProperties
{
    public virtual string? UserId { get; set; }
    public virtual string? ReplyTo { get; set; }
    public virtual byte Priority { get; set; }
    public virtual bool Persistent { get; set; }
    public virtual string? MessageId { get; set; }
    public virtual IDictionary<string, object> Headers { get; set; } = new Dictionary<string, object>();
    public virtual string? Expiration { get; set; }
    public virtual byte DeliveryMode { get; set; }
    public virtual string? ContentType { get; set; }
    public virtual string? ContentEncoding { get; set; }
    public virtual string? ClusterId { get; set; }
    public virtual string? AppId { get; set; }
    public virtual string? Type { get; set; }
}
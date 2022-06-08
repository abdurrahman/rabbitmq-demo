namespace Arcane.Core;

public class ConsumerServiceOption
{
    public IServiceProvider ServiceProvider { get; set; }
    public object Option { get; set; }
    public Type bodyType { get; set; }
    public Func<object, DeliverProperties, Task> ConsumerAction { get; set; }
}
namespace Arcane.Core;

public class ConsumerServiceOption
{
    public IServiceProvider ServiceProvider { get; set; }
    public object Option { get; set; }
    public Type BodyType { get; set; }
    public Func<object, DeliverProperties, Task> ConsumerAction { get; set; }

    public ConsumerServiceOption(
        IServiceProvider serviceProvider,
        object option,
        Type bodyType,
        Func<object, DeliverProperties, Task> consumerAction)
    {
        ServiceProvider = serviceProvider;
        Option = option;
        BodyType = bodyType;
        ConsumerAction = consumerAction;
    }
}
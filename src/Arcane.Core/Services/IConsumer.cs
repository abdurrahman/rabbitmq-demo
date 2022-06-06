namespace Arcane.Core;

public interface IConsumer<TBody>
{
    Task ConsumeAsync(TBody body, DeliverProperties deliverProperties);
}
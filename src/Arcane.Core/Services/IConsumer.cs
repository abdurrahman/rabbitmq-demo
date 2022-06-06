namespace Arcane.Core;

public interface IConsumer<TBody>
{
    Task ConsumeAsync(TBody body, object deliverProperties);
}
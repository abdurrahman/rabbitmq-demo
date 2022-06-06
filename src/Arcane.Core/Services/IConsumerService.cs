namespace Arcane.Core;

public interface IConsumerService : IDisposable
{
    Task RunAsync();
}
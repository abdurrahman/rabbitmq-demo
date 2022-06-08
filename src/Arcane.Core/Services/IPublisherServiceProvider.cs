namespace Arcane.Core;

public interface IPublisherServiceProvider
{
    bool TryGetPublisherService(string tag, out IPublisherService? publisherService);

    IPublisherService GetPublisherService(string tag);
}

public class PublisherServiceProvider : IPublisherServiceProvider
{
    private readonly Dictionary<string, IPublisherService> _publisherServices;
    
    public PublisherServiceProvider(Dictionary<string, IPublisherService> publisherServices)
    {
        _publisherServices = publisherServices;
    }

    public bool TryGetPublisherService(string tag, out IPublisherService? publisherService)
        => _publisherServices.TryGetValue(tag, out publisherService);

    public IPublisherService GetPublisherService(string tag)
        => _publisherServices[tag];
}
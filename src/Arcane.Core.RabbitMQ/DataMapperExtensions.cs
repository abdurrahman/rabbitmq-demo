using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Arcane.Core.RabbitMQ;

internal static class DataMapperExtensions
{
    public static byte[] SerializeToByteArray(this object data)
        => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
    
    public static TModel? DeserializeFromByteArray<TModel>(this byte[] data)
        => JsonConvert.DeserializeObject<TModel>(Encoding.UTF8.GetString(data));
    
    public static object? DeserializeFromByteArray(this byte[] data, Type type)
        => JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), type);

    public static IBasicProperties ConvertToBasicProperties(this BasicDeliverProperties arg, IModel channel)
    {
        var properties = channel.CreateBasicProperties();
        // Todo: Add mapper
        return properties;
    }
    
    public static DeliverProperties ConvertToDeliverProperties(this BasicDeliverEventArgs arg)
        => throw new NotImplementedException(); //.Map<BasicDeliverEventArgs, DeliverProperties>(arg);
}

using System.Text;
using Newtonsoft.Json;

namespace Arcane.Core.RabbitMQ;

internal static class DataMapperExtensions
{
    public static byte[] SerializeObject(this object data)
        => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
    
    public static TModel? DeserializeFromByteArray<TModel>(this byte[] data)
        => JsonConvert.DeserializeObject<TModel>(Encoding.UTF8.GetString(data));
    public static object? DeserializeFromByteArray(this byte[] data, Type type)
        => JsonConvert.DeserializeObject(Encoding.UTF8.GetString(data), type);
}
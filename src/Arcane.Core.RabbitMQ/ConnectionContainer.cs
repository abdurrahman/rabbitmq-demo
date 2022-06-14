using Arcane.Core.RabbitMQ.Models;
using RabbitMQ.Client;

namespace Arcane.Core.RabbitMQ;

internal static class ConnectionContainer
{
    private static readonly IDictionary<string, IConnection> ConnectionInfoDict = new Dictionary<string, IConnection>(); 

    public static IConnection GetConnection(ConnectionInfo connectionInfo)
    {
        var key = connectionInfo.ToString();
        lock (ConnectionInfoDict)
        {
            if (!ConnectionInfoDict.TryGetValue(key, out var connection))
            {
                ConnectionInfoDict[key] = connection = new ConnectionFactory
                {
                    HostName = connectionInfo.HostName,
                    UserName = connectionInfo.UserName,
                    Password = connectionInfo.Password
                }.CreateConnection();
            }

            return connection;
        }
    }
}

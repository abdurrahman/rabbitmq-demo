namespace Arcane.Core.RabbitMQ.Models;

public class ConnectionInfo
{
    public string HostName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public ConnectionInfo(string hostName, string userName, string password)
    {
        HostName = hostName;
        UserName = userName;
        Password = password;
    }

    public override string ToString() => $"{HostName}_{UserName}_{Password}";
}
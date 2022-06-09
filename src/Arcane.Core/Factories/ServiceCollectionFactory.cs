using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core.Factories;

internal class ServiceCollectionFactory
{
    public static IServiceCollection CreateServiceCollection(
        Action<IConfigurationBuilder>? configurationInjection,
        Action<IConfiguration, IServiceCollection>? serviceInjection)
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.json", true, true);
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (!string.IsNullOrEmpty(environment))
        {
            configurationBuilder.AddJsonFile($"appsettings.{environment}.json", true, true);
        }
        configurationInjection?.Invoke(configurationBuilder);
        
        var configuration = configurationBuilder.Build();
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        serviceInjection?.Invoke(configuration, services);
        
        return services;
    }
}
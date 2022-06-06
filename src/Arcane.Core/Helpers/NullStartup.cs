using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

public class NullStartup : IStartup
{
    public void InitConfiguration(IConfigurationBuilder configurationBuilder)
    {
    }

    public void Configure(IConfiguration configuration, IServiceCollection services)
    {
    }

    public void ConfigureServices(IServiceProvider serviceProvider)
    {
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arcane.Core;

public interface IStartup
{
    void InitConfiguration(IConfigurationBuilder configurationBuilder);
    void Configure(IConfiguration configuration, IServiceCollection services);
    void ConfigureServices(IServiceProvider serviceProvider);
}

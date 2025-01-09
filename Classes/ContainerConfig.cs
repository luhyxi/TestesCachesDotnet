using Enyim.Caching.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TesteMemcached.Classes;

public class ContainerConfig
{
    public static IServiceProvider Configure()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddEnyimMemcached(o => 
            o.Servers = new List<Server> { new Server { Address = "localhost", Port = 11211 } });
 
        return services.BuildServiceProvider();
    }
}
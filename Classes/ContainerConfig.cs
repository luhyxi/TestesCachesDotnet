using Enyim.Caching.Configuration;
using Aerospike.Client;
using Aerospike;
using Microsoft.Extensions.DependencyInjection;

namespace TesteMemcached.Classes;

public class ContainerConfig
{
    /*
     * The type of input determines the cache type to be used
     * 0 - MemCached
     * 1 - Aerospike
     * 2 - HazelCast
     */
    public static IServiceProvider Configure()
    {
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddEnyimMemcached(o
            => o.Servers = new List<Server> { new Server { Address = "localhost", Port = 11211 } });

        services.AddSingleton<ICacheProvider, CacheProvider>();
        services.AddSingleton<ICacheRepository, MemCacheRepository>();

        return services.BuildServiceProvider();
    }
}
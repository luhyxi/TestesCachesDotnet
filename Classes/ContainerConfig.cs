using Enyim.Caching.Configuration;
using Aerospike.Client;
using Aerospike;
using Microsoft.Extensions.DependencyInjection;

namespace TesteMemcached.Classes;

public class ContainerConfig
{

    public static IServiceProvider Configure(int i)
    {
        var services = new ServiceCollection();
        services.AddLogging();

        services.AddEnyimMemcached(o
            => o.Servers = new List<Server> { new Server { Address = "localhost", Port = 11211 } });

        services.AddSingleton<ICacheProvider, CacheProvider>();
        
        ChoosingRepo(i, services);

        return services.BuildServiceProvider();
    }
    
    /*
     * The type of input determines the cache type to be used
     * 0 - MemCached
     * 1 - Aerospike
     * 2 - HazelCast
     */
    private static void ChoosingRepo(int i, ServiceCollection services)
    {

        
        switch (i)
        {
            case 0:
                services.AddSingleton<ICacheRepository, MemCacheRepository>();
                break;
            case 1:
                services.AddSingleton<IAerospikeClient>(sp =>
                {
                    var clientPolicy = new ClientPolicy { }; 
                    return new AerospikeClient(clientPolicy, "localhost", 3000); // Replace with your Aerospike host and port
                });
                services.AddSingleton<ICacheRepository, AerospikeRepository>();
                break;
            case 2:
                services.AddSingleton<ICacheRepository, HazelcastRepository>();
                break;
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using TesteMemcached;
using TesteMemcached.Classes;

var providerMem = ContainerConfig.Configure(0);
var providerAero = ContainerConfig.Configure(1);
var providerHazel = ContainerConfig.Configure(2);


//MemCacheRepository Test
CacheTest(providerMem);

//HazelcastRepository Test
CacheTest(providerHazel);

//AerospikeRepository Test
CacheTest(providerAero);




// Get cache
Console.ReadLine();



void CacheTest(IServiceProvider serviceProvider)
{
    // Creating repo and provider
    var cacheRepository = serviceProvider.GetService<ICacheRepository>();
    var cacheProvider = serviceProvider.GetService<ICacheProvider>();


    // Setter Upper to set up the setup
    var setterUpper = new SetterUpper(cacheRepository, cacheProvider);

    // Set cache
    setterUpper.SetUp();
}
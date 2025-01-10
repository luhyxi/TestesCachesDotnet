using Enyim.Caching;
using Aerospike.Client;
using Hazelcast;
using Hazelcast.DistributedObjects;

namespace TesteMemcached.Classes;

public interface ICacheRepository
{
    void Set<T>(string key, T value);
}

public class MemCacheRepository : ICacheRepository
{
    private readonly IMemcachedClient _memcachedClient;

    public MemCacheRepository(IMemcachedClient memcachedClient)
    {
        this._memcachedClient = memcachedClient;
    }

    public void Set<T>(string key, T value)
    {
        _memcachedClient.Set(key, value, 10);
    }
}

public class AerospikeRepository:ICacheRepository
{
    private readonly IAerospikeClient _aerospikeClient;
    private WritePolicy _writePolicy { get; set; }
    
    public AerospikeRepository(IAerospikeClient _aerospikeClient)
    {
        this._aerospikeClient = _aerospikeClient;
        _writePolicy = new WritePolicy();
    }
    public void Set<T>(string key, T value)
    {
        var keyStuff = new Key(ns: "test", setName: "set",  key: key);
        Bin bin2 = new Bin("count", 3);
        _aerospikeClient.Add(null, keyStuff, bin2);
    }
}

public class HazelcastRepository : ICacheRepository
{
    private HazelcastOptions  HazelOptions { get; set; }
    private IHazelcastClient HazelcastClient { get; set; }
    
    public HazelcastRepository()
    {
        HazelOptions = new HazelcastOptionsBuilder().Build();
        HazelcastClient = HazelcastClientFactory.StartNewClientAsync(HazelOptions).Result;
    }
    
    public void Set<T>(string key, T value)
    {
        var keyStuff = new KeyValuePair<string, string>(key, value.ToString());
        
        var list = HazelcastClient.GetListAsync<KeyValuePair<string, string>>("my-distributed-list").Result;

        list.AddAsync(keyStuff);
    }
}


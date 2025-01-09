using Enyim.Caching;
using Aerospike.Client;

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
        _memcachedClient.Set(key, value, 60 * 60);
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
        var keyStuff = new Key(ns: key, setName: key,  key: value.ToString());
        
        _aerospikeClient.Put(_writePolicy, keyStuff);
    }
}
using Enyim.Caching;

namespace TesteMemcached.Classes;

public interface ICacheProvider
{
    T GetCache<T>(string key);
}

public class CacheProvider:ICacheProvider
{
    private readonly IMemcachedClient memcachedClient;

    public CacheProvider(IMemcachedClient memcachedClient)
    {
        this.memcachedClient = memcachedClient;
    }

    public T GetCache<T>(string key)
    {
        return memcachedClient.Get<T>(key);
    }
}
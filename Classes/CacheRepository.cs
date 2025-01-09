using Enyim.Caching;

namespace TesteMemcached.Classes;

public interface ICacheRepository
{
    void Set<T>(string key, T value);
}

public class MemCacheRepository : ICacheRepository
{
    private readonly IMemcachedClient memcachedClient;

    public MemCacheRepository(IMemcachedClient memcachedClient)
    {
        this.memcachedClient = memcachedClient;
    }

    public void Set<T>(string key, T value)
    {
        memcachedClient.Set(key, value, 60 * 60);
    }
}

public class MyClass:ICacheRepository
{
    public void Set<T>(string key, T value)
    {
        throw new NotImplementedException();
    }
}
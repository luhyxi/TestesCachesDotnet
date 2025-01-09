using TesteMemcached.Classes;

namespace TesteMemcached;

public class SetterUpper
{
    private int UPPER = 10000;
    
    string content = File.ReadAllText
        ("C:\\Users\\luanar\\Desktop\\WorkStuff\\TestesNoSQL\\TesteMemcached\\request.txt");

    private ICacheRepository CacheRepository { get; set; }
    public ICacheProvider CacheProvider { get; set; }

    public SetterUpper( ICacheRepository cacheRepository, ICacheProvider cacheProvider )
    {
        CacheRepository = cacheRepository;
        CacheProvider = cacheProvider;
    }


    public void SetUp()
    {
        for (int i = 0; i < UPPER; i++)
        {
            CacheRepository.Set($"Key_{i}", content);
        }
    }

    public void DisplayKeys()
    {
        for (int i = 0; i < UPPER; i++)
        {
            Console.WriteLine
                ($"Value from cache {CacheProvider.GetCache<string>($"Key_{i}")}");
        }
    }
}
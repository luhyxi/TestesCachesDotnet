using Microsoft.Extensions.DependencyInjection;
using TesteMemcached;
using TesteMemcached.Classes;

var provider = ContainerConfig.Configure();
 

string content = File.ReadAllText("C:\\Users\\luanar\\Desktop\\WorkStuff\\TestesNoSQL\\TesteMemcached\\request.txt");
var cacheRepository = provider.GetService<ICacheRepository>();
var cacheProvider = provider.GetService<ICacheProvider>();

// Setter Upper to set up the setup

var setterUpper = new SetterUpper(cacheRepository, cacheProvider);

// Set cache
setterUpper.SetUp();
 
// Get cache
setterUpper.DisplayKeys();
Console.ReadLine();
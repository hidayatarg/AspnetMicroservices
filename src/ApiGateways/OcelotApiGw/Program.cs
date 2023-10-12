using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;

// configureAppConfiguration
builder.Configuration.AddJsonFile($"ocelot.{env}.json", false, true);


// logging configuration
builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddOcelot()
    .AddCacheManager(x => x.WithDictionaryHandle());

var app = builder.Build();

app.UseHttpsRedirection();
await app.UseOcelot();
app.UseAuthorization();

app.MapControllers();

app.Run();

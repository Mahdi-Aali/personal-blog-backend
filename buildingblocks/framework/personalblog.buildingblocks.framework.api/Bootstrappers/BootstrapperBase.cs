using System.Reflection;

namespace personalblog.buildingblocks.framework.api.Bootstrappers;

public abstract class BootstrapperBase
{
    public Lazy<Assembly[]> Assemblies { get; private set; }
    public Lazy<IConfiguration> Configurations { get; private set; }

    protected BootstrapperBase()
    {
        Assemblies = new(LoadAssemblies);
        Configurations = new(LoadConfigurations);
    }


    public abstract void ConfigureServices(WebApplicationBuilder builder);

    public virtual async Task Configure(WebApplication app, IWebHostEnvironment env)
    {
        await app.RunAsync();
    }


    private Assembly[] LoadAssemblies()
    {
        return Assembly.GetExecutingAssembly().GetReferencedAssemblies()
            .Where(x => x.Name!.Contains("personalblog", StringComparison.OrdinalIgnoreCase))
            .Select(asm => Assembly.Load(asm))
            .Concat([GetType().Assembly])
            .ToArray();
    }

    private IConfiguration LoadConfigurations()
    {
        var envs = Environment.GetEnvironmentVariables();
        string stage = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

        string fileName = $"appsettings.{stage}.json";

        IConfigurationRoot defaultConfig = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile(fileName)
            .Build();

        string? configServerPath = defaultConfig["configServer"];

        if (!string.IsNullOrEmpty(configServerPath))
        {
            Console.WriteLine($"config server found successfully! {configServerPath}");



            HttpClient client = new();
            var response = client.GetAsync(configServerPath).Result;

            response.EnsureSuccessStatusCode();

            return new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile(fileName)
                .AddJsonStream(response.Content.ReadAsStream())
                .Build();
        }
        else
        {
            throw new InvalidOperationException("Config server not found!");
        }
    }


}

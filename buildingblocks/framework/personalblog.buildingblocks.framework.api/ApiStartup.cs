using personalblog.buildingblocks.framework.api.Bootstrappers;

namespace personalblog.buildingblocks.framework.api;

public abstract class ApiStartup<TBootstrapper> where TBootstrapper : BootstrapperBase
{
    public static async Task RunAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        TBootstrapper bootstrapper = Activator.CreateInstance<TBootstrapper>();
        bootstrapper.ConfigureServices(builder);
        await bootstrapper.Configure(builder.Build(), builder.Environment);
    }
}

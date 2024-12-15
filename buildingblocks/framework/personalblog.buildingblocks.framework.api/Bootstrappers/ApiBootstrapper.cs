
using personalblog.buildingblocks.framework.api.Bootstrappers.Loaders;

namespace personalblog.buildingblocks.framework.api.Bootstrappers;

public class ApiBootstrapper : BootstrapperBase
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        IServiceCollection services = builder.Services;
        BootstrapperServiceLoader.LoadServices(services, Assemblies.Value, Configurations.Value);
    }


}

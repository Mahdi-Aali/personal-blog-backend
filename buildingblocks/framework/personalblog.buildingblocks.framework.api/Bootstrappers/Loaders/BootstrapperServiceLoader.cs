using personalblog.buildingblocks.framework.common.ServiceProvider;
using System.Reflection;

namespace personalblog.buildingblocks.framework.api.Bootstrappers.Loaders;

public sealed class BootstrapperServiceLoader
{
    public static IServiceCollection LoadServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations)
    {
        IEnumerable<Type>? serviceProviders = assemblies.SelectMany(asm => asm.GetTypes()).Where(type => typeof(IFrameworkServiceProvider).IsAssignableFrom(type)
        && !type.IsInterface);
        if (!serviceProviders.Any())
        {
            throw new Exception("No service provider found!");
        }

        foreach (Type sp in serviceProviders)
        {
            IFrameworkServiceProvider serviceProvider = (IFrameworkServiceProvider)Activator.CreateInstance(sp)!;
            serviceProvider.GetServices(services, assemblies, configurations);
        }

        return services;
    }
}

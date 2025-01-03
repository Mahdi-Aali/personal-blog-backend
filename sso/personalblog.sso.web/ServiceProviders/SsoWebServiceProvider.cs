using personalblog.buildingblocks.framework.common.ServiceProvider;
using Serilog;
using System.Reflection;

namespace personalblog.sso.web.ServiceProviders;

public class SsoWebServiceProvider : IFrameworkServiceProvider
{
    public IServiceCollection GetServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations)
    {
        AddSerilog(services);
        AddRazorPages(services);

        return services;
    }

    public void AddSerilog(IServiceCollection services)
    {
        services.AddSerilog();
    }

    public void AddRazorPages(IServiceCollection services)
    {
        services.AddRazorPages();
    }


}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace personalblog.buildingblocks.framework.common.ServiceProvider;

public interface IFrameworkServiceProvider
{
    public IServiceCollection GetServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations);
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using personalblog.buildingblocks.framework.common.ServiceProvider;
using personalblog.sso.infrastructure.Database;
using System.Reflection;

namespace personalblog.sso.infrastructure.ServiceProviders;

public class InfrastructureServiceProvider : IFrameworkServiceProvider
{
    public IServiceCollection GetServices(IServiceCollection services, Assembly[] assemblies, IConfiguration configurations)
    {
        throw new NotImplementedException();
    }


    public void RegisterDbContext(IServiceCollection services, IConfiguration configurations)
    {
        services.AddDbContext<PersonalBlogSsoDbContext>(cfg =>
        {
            cfg.UseSqlServer(configurations.GetConnectionString("Default"), ssopt =>
            {

            });
        });
    }
}


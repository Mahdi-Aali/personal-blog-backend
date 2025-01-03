

using personalblog.buildingblocks.framework.api.Bootstrappers.Loaders;
using personalblog.buildingblocks.logging.Configurations;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace personalblog.buildingblocks.framework.api.Bootstrappers;

public class ApiBootstrapper : BootstrapperBase
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(ElasticSearchSinksConfigurations.LoadOptions(Configurations.Value))
            .MinimumLevel.Warning()
            .CreateLogger();

        IServiceCollection services = builder.Services;
        BootstrapperServiceLoader.LoadServices(services, Assemblies.Value, Configurations.Value);
    }

    public override async Task Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseSerilogRequestLogging();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDefaultControllerRoute();
        app.MapRazorPages();

        await base.Configure(app, env);
    }
}

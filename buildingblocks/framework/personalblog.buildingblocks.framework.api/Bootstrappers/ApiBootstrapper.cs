using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using personalblog.buildingblocks.framework.api.Bootstrappers.Loaders;
using Serilog;

namespace personalblog.buildingblocks.framework.api.Bootstrappers;

public class ApiBootstrapper : BootstrapperBase
{
    public override void ConfigureServices(WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Elasticsearch(new[] { new Uri(Configurations.Value["elastic:url"]!) }, opts =>
            {
                opts.DataStream = new DataStreamName("logs", "personalblog");
                opts.BootstrapMethod = BootstrapMethod.Failure;
            }, transport =>
            {
                transport.Authentication(new BasicAuthentication(Configurations.Value["elastic:username"]!, Configurations.Value["elastic:password"]!));
                transport.ServerCertificateValidationCallback((a, b, c, d) => true);
            })
            .MinimumLevel.Information()
            .CreateLogger();

        IServiceCollection services = builder.Services;
        var assemblies = Assemblies.Value;
        BootstrapperServiceLoader.LoadServices(services, assemblies, Configurations.Value);
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

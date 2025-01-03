using personalblog.buildingblocks.framework.api;
using personalblog.buildingblocks.framework.api.Bootstrappers;

namespace personalblog.sso.web;

public class Program : SsoStartup
{
    public static async Task Main(string[] args)
    {
        await RunAsync(args);
    }
}

public class SsoStartup : ApiStartup<ApiBootstrapper>
{

}
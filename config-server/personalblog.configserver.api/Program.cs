using personalblog.configserver.api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/configs/{service}/{state}/{version}", async (HttpContext context, string service, string state, string version) =>
{
    string path = Path.Combine(ConfigServer.ConfigsPath, service, state, version, "settings.json");
	context.Response.StatusCode = StatusCodes.Status200OK;
	context.Response.ContentType = "application/json";
	if (File.Exists(path))
	{
		await context.Response.WriteAsync(File.ReadAllText(path));
	}
	else
	{
		await context.Response.WriteAsJsonAsync("");
	}
});

app.Run();
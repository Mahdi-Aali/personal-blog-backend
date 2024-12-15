namespace personalblog.configserver.api.Models;

public class ConfigServer
{
    public static string BasePath = Directory.GetCurrentDirectory();
    public static string ConfigsPath = Path.Combine(BasePath, "Configs");
}

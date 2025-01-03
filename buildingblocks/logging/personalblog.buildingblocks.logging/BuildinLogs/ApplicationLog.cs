using personalblog.buildingblocks.logging.Abstractions;
using personalblog.buildingblocks.logging.Builders;
using System.Diagnostics;
using System.Text;

namespace personalblog.buildingblocks.logging.Logs;

public class ApplicationLog : Log
{
    public string Message { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;

    protected ApplicationLog(string message, string stack = "", string ip = "") : base(stack) =>
        (Message, Ip) = (message, ip);


    public static class Factory
    {
        public static ApplicationLog Create(string message, string ip = "")
        {
            StackTrace st = new(true);
            string stack = new StringLogStackBuilder(st).Build();
            return new(message, stack, ip);
        }
    }
}

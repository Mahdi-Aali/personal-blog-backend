using personalblog.buildingblocks.logging.Abstractions;

namespace personalblog.buildingblocks.logging.BuildinLogs;

public class ExceptionLog : Log
{
    public ExceptionLog(string message, string innerException, string stack) : base(stack)
    {
    }

    public string Message { get; set; } = string.Empty;
    public string InnerException { get; set; } = string.Empty;


    public static class Factory
    {
        public static ExceptionLog Create(string message, string innerException, string stackTrace) =>
            new(message, innerException, stackTrace);
    }
}

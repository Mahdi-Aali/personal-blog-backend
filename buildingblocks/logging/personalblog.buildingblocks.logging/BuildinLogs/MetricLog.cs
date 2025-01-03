using personalblog.buildingblocks.logging.Abstractions;
using personalblog.buildingblocks.logging.Builders;
using System.Diagnostics;

namespace personalblog.buildingblocks.logging.BuildinLogs;

public class MetricLog : Log
{
    protected MetricLog(string requestUrl, string parameters, TimeSpan estimated, string stack) : base(stack) =>
        (RequestUrl, Parameters, Estimated) = (requestUrl, parameters, estimated);

    public string RequestUrl { get; set; } = string.Empty;
    public string Parameters { get; set; } = string.Empty;
    public TimeSpan Estimated { get; set; }


    public static class Factory
    {
        public static MetricLog Create(string requestUrl, string parameters, TimeSpan estimated)
        {
            string stack = new StringLogStackBuilder(new StackTrace(true)).Build();
            return new(requestUrl, parameters, estimated, stack);
        }
    }

}

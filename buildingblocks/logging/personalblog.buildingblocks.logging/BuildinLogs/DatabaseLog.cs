using personalblog.buildingblocks.logging.Abstractions;
using personalblog.buildingblocks.logging.Builders;
using System.Diagnostics;

namespace personalblog.buildingblocks.logging.BuildinLogs;

public class DatabaseLog : Log
{
    protected DatabaseLog(string query, TimeSpan estimated, string stack) : base(stack)
    {
    }

    public string Query { get; set; } = string.Empty;
    public TimeSpan Estimated { get; set; }

    public static class Factory
    {
        public static DatabaseLog Create(string query, TimeSpan estimated)
        {
            string stack = new StringLogStackBuilder(new StackTrace(true)).Build();
            return new DatabaseLog(query, estimated, stack);
        }
    }
}

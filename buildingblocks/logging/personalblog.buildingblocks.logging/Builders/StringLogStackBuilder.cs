using System.Diagnostics;
using System.Text;

namespace personalblog.buildingblocks.logging.Builders;

public class StringLogStackBuilder (StackTrace stackTrace)
{
    public string Build()
    {
        StringBuilder sb = new();
        foreach (var frame in stackTrace.GetFrames())
        {
            sb.AppendLine($"fileName: {frame.GetFileName()}, at {frame.GetMethod()}, at: {frame.GetFileLineNumber()}, at {frame.GetMethod()?.Name ?? "No method found!"}");
        }

        return sb.ToString();
    }
}

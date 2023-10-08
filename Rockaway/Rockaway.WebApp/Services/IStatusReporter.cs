using System.Reflection;
using System.Text.Json.Serialization;

namespace Rockaway.WebApp.Services;

public interface IStatusReporter
{
    public ServerStatus GetStatus();
}

public class StatusReporter : IStatusReporter
{
    public ServerStatus GetStatus()
    {
        var assembly = Assembly.GetEntryAssembly() ?? throw new("Couldn't get entry assembly");
        return new()
        {
            Assembly = assembly.FullName ?? "(null)",
            Modified = File.GetLastWriteTimeUtc(assembly.Location),
            Hostname = Environment.MachineName,
            DateTime = DateTimeOffset.UtcNow
        };
    }
}

public class ServerStatus
{
    public string Assembly { get; set; } = String.Empty;
    public DateTimeOffset Modified { get; set; }
    public string Hostname { get; set; } = String.Empty;
    public DateTimeOffset DateTime { get; set; }
}
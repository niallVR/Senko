using Discord;
using Microsoft.Extensions.Logging;

namespace NiallVR.Senko.Discord.Hosting.Extensions; 

public static class DiscordLogExtensions {
    /// <summary>
    /// Converts the Discord Log Severity to Microsoft's Log Level.
    /// </summary>
    /// <param name="logSeverity">The log severity to convert.</param>
    /// <returns>The equivalent log level.</returns>
    public static LogLevel ToLogLevel(this LogSeverity logSeverity) {
        return logSeverity switch {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Trace,
            LogSeverity.Debug => LogLevel.Debug,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
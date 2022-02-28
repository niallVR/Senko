using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Hosting.Hosted.Abstract;

namespace NiallVR.Senko.Discord.Hosting.Services; 

/// <summary>
/// Bridges the Discord.Net and Microsoft logging systems.
/// </summary>
internal class DiscordLogService : HostedService {
    private readonly ILogger<DiscordSocketClient> _logger;

    public DiscordLogService(IServiceProvider services) {
        _logger = services.GetRequiredService<ILogger<DiscordSocketClient>>();
        services.GetRequiredService<DiscordSocketClient>().Log += OnLogMessage;

        var interaction = services.GetService<InteractionService>();
        if (interaction is not null)
            interaction.Log += OnLogMessage;
    }

    /// <summary>
    /// Logs Discord.Net log messages using the ILogger.
    /// </summary>
    private Task OnLogMessage(LogMessage logMessage) {
        var logLevel = logMessage.Severity switch {
            LogSeverity.Critical => LogLevel.Critical,
            LogSeverity.Error => LogLevel.Error,
            LogSeverity.Warning => LogLevel.Warning,
            LogSeverity.Info => LogLevel.Information,
            LogSeverity.Verbose => LogLevel.Trace,
            LogSeverity.Debug => LogLevel.Debug,
            _ => throw new ArgumentOutOfRangeException()
        };

        if (logMessage.Exception is GatewayReconnectException) {
            _logger.LogInformation("Server requested a reconnect");
            return Task.CompletedTask;
        }

        _logger.Log(logLevel, logMessage.Exception, logMessage.Message);
        return Task.CompletedTask;
    }
}
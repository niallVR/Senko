using System.Net.WebSockets;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Bootstrap.Hosted.Abstract;
using NiallVR.Senko.Discord.Hosting.Extensions;
using NiallVR.Senko.Discord.Hosting.Models;

namespace NiallVR.Senko.Discord.Hosting.Services; 

/// <summary>
/// Bridges the Discord.Net and Microsoft logging systems.
/// </summary>
internal class DiscordClientLogService : HostedService {
    private readonly DiscordSetup _setup;
    private readonly ILogger<DiscordSocketClient> _logger;

    public DiscordClientLogService(DiscordSocketClient discord, DiscordSetup setup, ILogger<DiscordSocketClient> logger) {
        _setup = setup;
        _logger = logger;
        discord.Log += OnLog;
    }

    /// <summary>
    /// Logs Discord.Net log messages using the ILogger.
    /// </summary>
    private Task OnLog(LogMessage logMessage) {
        var logLevel = logMessage.Severity.ToLogLevel();
     
        // Swap a reconnect event to be information instead of an error.
        // They're handled by Discord.Net and not usually a problem.
        if (logMessage.Exception is GatewayReconnectException) {
            _logger.LogInformation("Server requested a reconnect");
            return Task.CompletedTask;
        }

        // Ignore websocket exceptions if we don't want them.
        if (logMessage.Exception is WebSocketException && _setup.IgnoreWebSocketExceptions)
            return Task.CompletedTask;
        
        _logger.Log(logLevel, logMessage.Exception, logMessage.Message);
        return Task.CompletedTask;
    }
}
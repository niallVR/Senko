using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Discord.Hosting.Models;

namespace NiallVR.Senko.Discord.Hosting.Services; 

/// <summary>
/// Manages the life of the Discord client.
/// </summary>
internal class DiscordLauncherService : IHostedService {
    private readonly DiscordSocketClient _discord;
    private readonly DiscordSetup _setup;
    private readonly ILogger<DiscordLauncherService> _logger;

    public DiscordLauncherService(DiscordSocketClient discord, DiscordSetup setup, ILogger<DiscordLauncherService> logger) {
        _discord = discord;
        _setup = setup;
        _logger = logger;
    }

    /// <summary>
    /// Authenticates and connects to the Discord API.
    /// </summary>
    public async Task StartAsync(CancellationToken cancellationToken) {
        _logger.LogInformation("Starting the Discord client");
        await _discord.LoginAsync(TokenType.Bot, _setup.Token);
        await _discord.StartAsync();
    }

    /// <summary>
    /// Disconnects from the Discord API.
    /// </summary>
    public async Task StopAsync(CancellationToken cancellationToken) {
        _logger.LogInformation("Stopping the Discord client");
        await _discord.StopAsync();
    }
}
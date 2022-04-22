using Discord.WebSocket;
using NiallVR.Senko.Bootstrap.Hosted.Abstract;

namespace NiallVR.Senko.Discord.Hosting.Abstract; 

/// <summary>
/// A service which hooks into the Discord lifecycle events.
/// </summary>
public abstract class DiscordService : HostedService {
    protected readonly DiscordSocketClient Discord;
    
    protected DiscordService(DiscordSocketClient discord) {
        Discord = discord;
        Discord.Ready += OnDiscordReady;
        Discord.Disconnected += OnDiscordDisconnected;
    }

    protected virtual Task OnDiscordReady() => Task.CompletedTask;
    protected virtual Task OnDiscordDisconnected(Exception exception) => Task.CompletedTask;
}
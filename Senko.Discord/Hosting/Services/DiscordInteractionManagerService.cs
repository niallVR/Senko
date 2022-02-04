using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NiallVR.Senko.Discord.Hosting.Models;
using NiallVR.Senko.Extensions.Collections;
using NiallVR.Senko.Hosting.Abstract;

namespace NiallVR.Senko.Discord.Hosting.Services; 

internal class DiscordInteractionManagerService : HostedService {
    private ModuleInfo[]? _globalModules;
    private ModuleInfo[]? _globalGuildModules;
    private readonly Dictionary<ulong, ModuleInfo[]> _guildModules = new();
    
    private readonly DiscordSetup _discordConfig;
    private readonly IServiceProvider? _services;
    private readonly DiscordSocketClient? _discord;
    private readonly InteractionService? _interactionService;

    public DiscordInteractionManagerService(IServiceProvider services) {
        _discordConfig = services.GetRequiredService<DiscordSetup>();
        if (!_discordConfig.WantInteraction)
            return;
        
        _services = services;
        _interactionService = services.GetRequiredService<InteractionService>();

        _discord = services.GetRequiredService<DiscordSocketClient>();
        _discord.Ready += OnDiscordReady;
        _discord.JoinedGuild += OnJoinedGuild;
    }

    /// <summary>
    /// Prepares the modules to be registered upon connecting to Discord.
    /// </summary>
    public override async Task StartAsync(CancellationToken _) {
        if (!_discordConfig.WantInteraction)
            return;
        
        _globalModules = new ModuleInfo[_discordConfig.GlobalInteractionModules.Count];
        for (var i = 0; i < _discordConfig.GlobalInteractionModules.Count; i++)
            _globalModules[i] = await _interactionService!.AddModuleAsync(_discordConfig.GlobalInteractionModules[i], _services);

        _globalGuildModules = new ModuleInfo[_discordConfig.GlobalGuildInteractionModules.Count];
        for (var i = 0; i < _discordConfig.GlobalGuildInteractionModules.Count; i++)
            _globalGuildModules[i] = await _interactionService!.AddModuleAsync(_discordConfig.GlobalGuildInteractionModules[i], _services);

        foreach (var (guildId, modules) in _discordConfig.GuildInteractionModules) {
            var moduleArray = _guildModules.AddAndGet(guildId, () => new ModuleInfo[modules.Count]);
            for (var i = 0; i < moduleArray.Length; i++)
                moduleArray[i] = await _interactionService!.AddModuleAsync(modules[i], _services);
        }
    }
    
    /// <summary>
    /// Adds interactions globally and to guilds upon the bot connecting to Discord.
    /// </summary>
    private async Task OnDiscordReady() {
        await _interactionService!.AddModulesGloballyAsync(true, _globalModules);
        foreach (var guild in _discord!.Guilds)
            await RegisterModulesToGuild(guild);
    }

    /// <summary>
    /// Adds interactions to a guild upon the bot joining it.
    /// </summary>
    private async Task OnJoinedGuild(SocketGuild guild) {
        await RegisterModulesToGuild(guild);
    }

    /// <summary>
    /// Registers interactions to a guild.
    /// </summary>
    private async Task RegisterModulesToGuild(IGuild guild) {
        var guildModules = _guildModules.GetValueOrDefault(guild.Id) ?? ArraySegment<ModuleInfo>.Empty;
        var modulesToAdd = _globalGuildModules!.Concat(guildModules).ToArray();
        await _interactionService!.AddModulesToGuildAsync(guild, true, modulesToAdd);
    }
}
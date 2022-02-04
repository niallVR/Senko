using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using NiallVR.Senko.Discord.Hosting.Abstract;
using NiallVR.Senko.Discord.Hosting.Models;
using NiallVR.Senko.Extensions.Collections;

namespace NiallVR.Senko.Discord.Hosting.Services; 

internal class DiscordInteractionManagerService : DiscordService {
    private ModuleInfo[] _globalModules = null!;
    private ModuleInfo[] _globalGuildModules = null!;
    private readonly Dictionary<ulong, ModuleInfo[]> _guildModules = new();
    
    private readonly DiscordSetup _discordConfig;
    private readonly IServiceProvider _services;
    private readonly InteractionService _interactionService;

    public DiscordInteractionManagerService(IServiceProvider services, DiscordSocketClient discord) : base(discord) {
        _services = services;
        _discordConfig = services.GetRequiredService<DiscordSetup>();
        _interactionService = services.GetRequiredService<InteractionService>();
        Discord.JoinedGuild += OnJoinedGuild;
    }

    /// <summary>
    /// Prepares the modules to be registered upon connecting to Discord.
    /// </summary>
    public override async Task StartAsync(CancellationToken _) {
        _globalModules = new ModuleInfo[_discordConfig.GlobalInteractionModules.Count];
        for (var i = 0; i < _discordConfig.GlobalInteractionModules.Count; i++)
            _globalModules[i] = await _interactionService.AddModuleAsync(_discordConfig.GlobalInteractionModules[i], _services);

        _globalGuildModules = new ModuleInfo[_discordConfig.GlobalGuildInteractionModules.Count];
        for (var i = 0; i < _discordConfig.GlobalGuildInteractionModules.Count; i++)
            _globalGuildModules[i] = await _interactionService.AddModuleAsync(_discordConfig.GlobalGuildInteractionModules[i], _services);

        foreach (var (guildId, modules) in _discordConfig.GuildInteractionModules) {
            var moduleArray = _guildModules.AddAndGet(guildId, () => new ModuleInfo[modules.Count]);
            for (var i = 0; i < moduleArray.Length; i++)
                moduleArray[i] = await _interactionService.AddModuleAsync(modules[i], _services);
        }
    }

    /// <summary>
    /// Adds interactions globally and to guilds upon the bot connecting to Discord.
    /// </summary>
    protected override async Task OnDiscordReady() {
        await _interactionService.AddModulesGloballyAsync(true, _globalModules);
        foreach (var guild in Discord.Guilds)
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
        var modulesToAdd = _globalGuildModules.Concat(guildModules).ToArray();
        await _interactionService.AddModulesToGuildAsync(guild, true, modulesToAdd);
    }
}
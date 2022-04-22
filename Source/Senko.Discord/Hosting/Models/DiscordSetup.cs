using Discord.Interactions;
using Discord.WebSocket;
using NiallVR.Senko.Core.Extensions;

namespace NiallVR.Senko.Discord.Hosting.Models; 

public class DiscordSetup {
    /// <summary>
    /// The token to use when authenticating with Discord.
    /// </summary>
    public string Token { get; set; } = "";

    /// <summary>
    /// Configuration of the Discord client.
    /// </summary>
    public DiscordSocketConfig DiscordConfig { get; } = new();

    /// <summary>
    /// Configuration of the interaction service.
    /// </summary>
    /// <remarks>This will only be activated if an interaction module is added.</remarks>
    public InteractionServiceConfig InteractionConfig { get; } = new();

    /// <summary>
    /// Should the Discord client have interaction features?
    /// </summary>
    public bool WantInteraction { get; set; }

    /// <summary>
    /// If enabled, all web socket exceptions thrown by the Discord Client are ignored.
    /// </summary>
    public bool IgnoreWebSocketExceptions { get; set; } = true;
    
    // Internal collection of added modules.
    internal readonly List<Type> GlobalInteractionModules = new();
    internal readonly List<Type> GlobalGuildInteractionModules = new();
    internal readonly Dictionary<ulong, List<Type>> GuildInteractionModules = new();

    /// <summary>
    /// Adds an interaction module which will be available globally.
    /// </summary>
    /// <typeparam name="T">The type of module to add.</typeparam>
    public void AddGlobalInteractionModule<T>() where T : InteractionModuleBase {
        GlobalInteractionModules.Add(typeof(T));
    }

    /// <summary>
    /// Adds an interaction module which will be available in guilds only.
    /// </summary>
    /// <typeparam name="T">The type of module to add.</typeparam>
    public void AddGuildInteractionModule<T>() where T : InteractionModuleBase {
        GlobalGuildInteractionModules.Add(typeof(T));
    }

    /// <summary>
    /// Adds an interaction module which will be available in a single guild.
    /// </summary>
    /// <param name="guildId">The id of the guild the module will be registered to.</param>
    /// <typeparam name="T">The type of module to add.</typeparam>
    public void AddTargetedGuildInteractionModule<T>(ulong guildId) where T : InteractionModuleBase {
        GuildInteractionModules.AddAndGet(guildId, () => new List<Type>()).Add(typeof(T));
    }
}
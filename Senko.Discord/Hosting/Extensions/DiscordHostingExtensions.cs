using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Discord.Hosting.Models;
using NiallVR.Senko.Discord.Hosting.Services;

namespace NiallVR.Senko.Discord.Hosting.Extensions;

/// <summary>
/// Extensions for the <see cref="DiscordSocketClient"/> class.
/// </summary>
public static class DiscordHostingExtensions {
    /// <summary>
    /// Adds a Discord client to the <see cref="IHostBuilder"/>.
    /// </summary>
    /// <param name="builder">The <see cref="IHostBuilder"/> to add the Discord client to.</param>
    /// <param name="config">The configuration of the Discord client.</param>
    /// <returns>The <see cref="IHostBuilder"/> the Discord client was added to.</returns>
    public static IHostBuilder ConfigureDiscordClient(this IHostBuilder builder, Action<IServiceProvider, DiscordSetup> config) {
        return builder.ConfigureServices((_, services) => {
            // Create the setup and prompt the user for their configuration.
            var setup = new DiscordSetup();
            services.AddSingleton(s => {
                config(s, setup);
                return setup;
            });

            // Add in the logging bridge
            services.AddHostedService<DiscordLogService>();

            // Work out if they added any interaction modules
            var globalInteractionModules = setup.GlobalInteractionModules.Any();
            var globalGuildInteractionModules = setup.GlobalGuildInteractionModules.Any();
            var guildInteractionModules = setup.GuildInteractionModules.Any();
            
            // Add the interaction modules if they added a service for it.
            var wantInteractions = globalInteractionModules || globalGuildInteractionModules || guildInteractionModules;
            if (wantInteractions) {
                services.AddSingleton(setup.InteractionConfig);
                services.AddSingleton<InteractionService>();
                services.AddHostedService<DiscordInteractionManagerService>();
                services.AddHostedService<DiscordInteractionHandlerService>();
            }
            
            // Add in the Discord client and its service.
            services.AddSingleton(setup.DiscordConfig);
            services.AddSingleton<DiscordSocketClient>();
            services.AddHostedService<DiscordLauncherService>();
        });
    }
}
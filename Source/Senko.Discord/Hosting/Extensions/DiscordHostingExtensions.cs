using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Discord.Hosting.Models;
using NiallVR.Senko.Discord.Hosting.Services;

namespace NiallVR.Senko.Discord.Hosting.Extensions;

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
            services.AddSingleton(s => { config(s, setup); return setup; });

            // Add in the logging bridge
            services.AddHostedService<DiscordClientLogService>();
            services.AddHostedService<InteractionsServiceLogService>();

            // Right now there's no way to tell if we want interactivity or not.
            // So add the classes and we'll block it during startup.
            services.AddSingleton(s => s.GetRequiredService<DiscordSetup>().InteractionConfig);
            services.AddHostedService<DiscordInteractionManagerService>();
            services.AddHostedService<DiscordInteractionHandlerService>();
            services.AddSingleton(s => {
                var discord = s.GetRequiredService<DiscordSocketClient>();
                var interactionConfig = s.GetRequiredService<InteractionServiceConfig>();
                return new InteractionService(discord, interactionConfig);
            });

            // Add in the Discord client and its service.
            services.AddSingleton(s => s.GetRequiredService<DiscordSetup>().DiscordConfig);
            services.AddSingleton(s => new DiscordSocketClient(s.GetRequiredService<DiscordSocketConfig>()));
            services.AddHostedService<DiscordLauncherService>();
        });
    }
}
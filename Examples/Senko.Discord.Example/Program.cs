using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Bootstrap.Config.Setup;
using NiallVR.Senko.Bootstrap.Config.Validation;
using NiallVR.Senko.Bootstrap.Logging.Extensions;
using NiallVR.Senko.Discord.Hosting.Extensions;
using Senko.Discord.Example.Commands;
using Senko.Discord.Example.Config;

await Host.CreateDefaultBuilder()
    // Configures the Serilog logger.
    .AddAndConfigSerilog((_, config) => {
        config.SetupConsoleSink();
    })
    
    // Mapping the config objects to the config keys.
    .UseConfigValidation(services => {
        services.BindConfig<DiscordConfig>("Discord");
    })
    
    // Add config.yaml, config.Development.yaml and config.Production.yaml to the config configuration.
    .UseYamlConfig("config")
    
    // Configure the Discord bot
    .ConfigureDiscordClient((services, discordSetup) => {
        // Setup the bot user
        var discordConfig = services.GetRequiredService<DiscordConfig>();
        discordSetup.Token = discordConfig.Token;
        
        // Add interactions
        discordSetup.WantInteraction = true;
        discordSetup.InteractionConfig.UseCompiledLambda = true;

        // Add Commands
        discordSetup.AddGuildInteractionModule<GreetingCommands>();
    })
    
    // Run the bot.
    .RunConsoleAsync();
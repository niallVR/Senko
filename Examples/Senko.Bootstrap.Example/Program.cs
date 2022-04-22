using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Bootstrap.Config.Setup;
using NiallVR.Senko.Bootstrap.Config.Validation;
using NiallVR.Senko.Bootstrap.Logging.Extensions;
using Senko.Bootstrap.Example.Config;
using Senko.Bootstrap.Example.Services;

await Host.CreateDefaultBuilder()
    // Configures the Serilog logger.
    // Make sure this is first in your host builder!
    // When the host starts, the logger will be configured.
    .AddAndConfigSerilog((_, config) => {
        config.SetupConsoleSink();
    })
    
    // Mapping the config objects to the config keys.
    // Using this extension also allows you to inject the object instead of IOptions<MyConfigObject>.
    .UseConfigValidation(services => {
        services.BindConfig<MessageConfig>("Message");
    })
    
// Add config.yaml, config.Development.yaml and config.Production.yaml to the config configuration.
    .UseYamlConfig("config")
    
    // Setup your services for the application. 
    .ConfigureServices(services => {
        services.AddHostedService<MessagePrinterService>();
    })
    
    // Run the application.
    .RunConsoleAsync();
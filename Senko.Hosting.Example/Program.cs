using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NiallVR.Senko.Hosting.Config.Extensions;
using NiallVR.Senko.Hosting.Logging.Extensions;
using NiallVR.Senko.Serilog.Extensions;
using Senko.Hosting.Example.Config;
using Senko.Hosting.Example.Services;
using Serilog.Events;

await Host.CreateDefaultBuilder()
    .UseYamlConfig("config")
    .UseConfigValidation(services => {
        services.MapConfig<ExampleConfig>("Example");
    })
    .AddAndConfigSerilog((_, config) => {
        config.SetupConsoleSink();
    })
    .ConfigureServices(services => {
        services.AddHostedService<ExampleService>();
    })
    .RunConsoleAsync();
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Bootstrap.Logging.Services;
using Serilog;

namespace NiallVR.Senko.Bootstrap.Logging.Extensions; 

public static class SerilogHostedExtensions {
    /// <summary>
    /// Adds Serilog to the service collection and configures the Log.Logger.
    /// </summary>
    /// <param name="builder">The builder to add Serilog to.</param>
    /// <param name="config">The logger configuration for Serilog.</param>
    /// <returns>The builder, Serilog was added to.</returns>
    /// <remarks>This should be first in your host builder.</remarks>
    public static IHostBuilder AddAndConfigSerilog(this IHostBuilder builder, Action<LoggerConfiguration> config) {
        return AddAndConfigSerilog(builder, (_, c) => config(c));
    }
    
    /// <summary>
    /// Adds Serilog to the service collection and configures the Log.Logger.
    /// </summary>
    /// <param name="builder">The builder to add Serilog to.</param>
    /// <param name="config">The logger configuration for Serilog.</param>
    /// <returns>The builder, Serilog was added to.</returns>
    /// <remarks>This should be first in your host builder.</remarks>
    public static IHostBuilder AddAndConfigSerilog(this IHostBuilder builder, Action<IServiceProvider, LoggerConfiguration> config) {
        builder.ConfigureServices((_, services) => {
            services.AddHostedService(s => new SerilogLauncherService(s, config));
        });
        return builder.UseSerilog();
    }
}
using Microsoft.Extensions.Hosting;
using Serilog;

namespace NiallVR.Senko.Hosting.Extensions; 

public static class SerilogHostedExtensions {
    /// <summary>
    /// Adds Serilog to the service collection and configures the Log.Logger.
    /// </summary>
    /// <param name="builder">The builder to add Serilog to.</param>
    /// <param name="config">The sink configuration for Serilog.</param>
    /// <returns>The builder Serilog was added to.</returns>
    public static IHostBuilder AddAndConfigSerilog(this IHostBuilder builder, Action<LoggerConfiguration> config) {
        var loggerConfig = new LoggerConfiguration().Enrich.FromLogContext();
        config(loggerConfig);
        Log.Logger = loggerConfig.CreateLogger();
        
        return builder.UseSerilog();
    }
}
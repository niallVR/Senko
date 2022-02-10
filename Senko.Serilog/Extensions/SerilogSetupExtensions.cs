using NiallVR.Senko.Serilog.Globals;
using NiallVR.Senko.Serilog.Interfaces;
using Serilog;
using Serilog.Events;

namespace NiallVR.Senko.Serilog.Extensions; 

public static class SerilogSetupExtensions {
    /// <summary>
    /// Adds a console sink to the logging config, configured with a theme and template.
    /// </summary>
    /// <param name="config">The config to add the console sink to.</param>
    /// <returns>The config the console sink was added to.</returns>
    public static LoggerConfiguration SetupConsoleSink(this LoggerConfiguration config) {
        return config.SetupConsoleSink(LogEventLevel.Verbose);
    }
    
    /// <summary>
    /// Adds a console sink to the logging config, configured with a theme and template.
    /// </summary>
    /// <param name="config">The config to add the console sink to.</param>
    /// <param name="minLevel">The minimum level that will be logged.</param>
    /// <returns>The config the console sink was added to.</returns>
    public static LoggerConfiguration SetupConsoleSink(this LoggerConfiguration config, LogEventLevel minLevel) {
        return config.WriteTo.Console(
            outputTemplate: SerilogConsoleSettings.Template,
            theme: SerilogConsoleSettings.Theme,
            restrictedToMinimumLevel: minLevel
        );
    }
    
    /// <summary>
    /// Adds a Seq sink to the logging config, with the minimum log level set to Debug.
    /// </summary>
    /// <param name="config">The config to add the Seq sink to.</param>
    /// <param name="seqConfig">Connection information for Seq.</param>
    /// <returns>The config the Seq sink was added to.</returns>
    public static LoggerConfiguration SetupSeqSink(this LoggerConfiguration config, ISeqConfig seqConfig) {
        return config.SetupSeqSink(seqConfig, LogEventLevel.Debug);
    }
    
    /// <summary>
    /// Adds a Seq sink to the logging config.
    /// </summary>
    /// <param name="config">The config to add the Seq sink to.</param>
    /// <param name="seqConfig">Connection information for Seq.</param>
    /// <param name="minLevel">The minimum level that will be logged.</param>
    /// <returns>The config the Seq sink was added to.</returns>
    public static LoggerConfiguration SetupSeqSink(this LoggerConfiguration config, ISeqConfig seqConfig, LogEventLevel minLevel) {
        if (!string.IsNullOrWhiteSpace(seqConfig.Host))
            config.WriteTo.Seq(seqConfig.Host, apiKey: seqConfig.Token);
        return config;
    }
}
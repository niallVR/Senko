using NiallVR.Senko.Hosting.Hosted.Abstract;
using Serilog;

namespace NiallVR.Senko.Hosting.Logging.Services; 

public class SerilogLauncherService : HostedService {
    public SerilogLauncherService(IServiceProvider services, Action<IServiceProvider, LoggerConfiguration> config) {
        var logger = new LoggerConfiguration().Enrich.FromLogContext();
        config(services, logger);
        Log.Logger = logger.CreateLogger();
    }

    public override Task StopAsync(CancellationToken _) {
        Log.CloseAndFlush();
        return Task.CompletedTask;
    }
}
using Microsoft.Extensions.Hosting;

namespace NiallVR.Senko.Bootstrap.Hosted.Abstract; 

/// <summary>
/// A small wrapper around <see cref="IHostedService"/>, to avoid the need to specify start/stop methods.
/// </summary>
public abstract class HostedService : IHostedService {
    public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    public virtual Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
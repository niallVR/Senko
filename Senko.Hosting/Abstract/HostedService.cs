using Microsoft.Extensions.Hosting;

namespace NiallVR.Senko.Hosting.Abstract; 

/// <summary>
/// A small wrapper around <see cref="IHostedService"/>, to avoid the need to specify start/stop methods every time.
/// </summary>
public abstract class HostedService : IHostedService {
    public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    public virtual Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
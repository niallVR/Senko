using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NiallVR.Senko.Bootstrap.Hosted.Extensions; 

public static class HostingExtensions {
    /// <summary>
    /// Adds a hosted service to the service collection as itself and as a <see cref="IHostedService"/>.
    /// </summary>
    /// <param name="services">The service collection to add the hosted service to.</param>
    /// <typeparam name="T">The type to add.</typeparam>
    /// <returns>The service collection the hosted service was added to.</returns>
    public static IServiceCollection AddHostedServiceAsSelf<T>(this IServiceCollection services) where T : class, IHostedService {
        services.AddSingleton<T>();
        return services.AddHostedService(s => s.GetRequiredService<T>());
    }
    
    /// <inheritdoc cref="AddHostedServiceAsSelf{T}(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// <param name="services">The service collection to add the hosted service to.</param>
    /// <param name="factory">The function used to generate the instance.</param>
    public static IServiceCollection AddHostedServiceAsSelf<T>(this IServiceCollection services, Func<IServiceProvider, T> factory) where T : class, IHostedService {
        services.AddSingleton(factory);
        return services.AddHostedService(s => s.GetRequiredService<T>());
    }
}
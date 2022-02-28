using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NiallVR.Senko.Hosting.Config.Interfaces;
using NiallVR.Senko.Hosting.Config.Services;

namespace NiallVR.Senko.Hosting.Config.Extensions; 

public static class ConfigValidationExtensions {
    /// <summary>
    /// Adds config validation to the host builder.
    /// </summary>
    /// <param name="builder">The HostBuilder to add the Config Validation service to.</param>
    public static IHostBuilder UseConfigValidation(this IHostBuilder builder) {
        return builder.ConfigureServices((_, services) => { services.UseConfigValidation(); });
    }
    
    /// <inheritdoc cref="UseConfigValidation(Microsoft.Extensions.Hosting.IHostBuilder)"/>
    /// <param name="builder">The HostBuilder to add the Config Validation service to.</param>
    /// <param name="config">The service collection of the HostBuilder to map config objects.</param>
    public static IHostBuilder UseConfigValidation(this IHostBuilder builder, Action<IServiceCollection> config) {
        return builder.ConfigureServices((_, services) => {
            services.UseConfigValidation();
            config(services);
        });
    }
    
    /// <summary>
    /// Adds config validation to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add config validation to.</param>
    public static IServiceCollection UseConfigValidation(this IServiceCollection services) {
        return services.AddHostedService<ConfigValidationService>();
    }
    
    /// <summary>
    /// Maps a type to the service collection, bound to a section of the <see cref="IConfiguration"/>.
    /// </summary>
    /// <param name="services">The service collection to add the type to.</param>
    /// <param name="configSectionPath">The path to the section to map to.</param>
    /// <typeparam name="T">The <see cref="IConfigValidator"/> to map.</typeparam>
    public static IServiceCollection MapConfig<T>(this IServiceCollection services, string configSectionPath) where T : class, IConfigValidator {
        services.AddOptions<T>().BindConfiguration(configSectionPath);
        services.AddSingleton(s => s.GetRequiredService<IOptions<T>>().Value);
        services.AddSingleton<IConfigValidator>(s => s.GetRequiredService<IOptions<T>>().Value);
        return services;
    }
}
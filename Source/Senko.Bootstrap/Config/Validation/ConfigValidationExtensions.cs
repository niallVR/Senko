using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace NiallVR.Senko.Bootstrap.Config.Validation; 

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
    /// Binds a type to a section of the config.
    /// - Allows access to bound type without the <see cref="IOptions{TOptions}"/> interface.
    /// - Signs up the type for config validation if it implements <see cref="IValidatedConfig"/>.
    /// </summary>
    /// <param name="services">The service collection to add the type to.</param>
    /// <param name="configPath">The config path to map the object to.</param>
    /// <typeparam name="T">The <see cref="IValidatedConfig"/> to map.</typeparam>
    public static IServiceCollection BindConfig<T>(this IServiceCollection services, string configPath) where T : class {
        services.AddOptions<T>().BindConfiguration(configPath);
        services.AddSingleton(s => s.GetRequiredService<IOptions<T>>().Value); // Allows you to request DatabaseConfig instead of IOptions<DatabaseConfig>.
        if (typeof(IValidatedConfig).IsAssignableFrom(typeof(T))) 
            services.AddSingleton(s => (IValidatedConfig) s.GetRequiredService<IOptions<T>>().Value);
        return services;
    }
}
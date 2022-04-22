using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace NiallVR.Senko.Bootstrap.Config.Setup; 

public static class ConfigSetupExtensions {
    /// <summary>
    /// Enables the use of YAML files to configure the application.
    /// </summary>
    /// <param name="builder">The host to configure.</param>
    /// <param name="filenamePrefix">The name of the file, prior to the extension.</param>
    /// <returns>The host that was configured.</returns>
    /// <remarks>This expects YAML files with the .yaml file extension.</remarks>
    public static IHostBuilder UseYamlConfig(this IHostBuilder builder, string filenamePrefix = "appsettings") {
        return builder.ConfigureAppConfiguration((_, configurationBuilder) => {
            configurationBuilder.AddYamlFile($"{filenamePrefix}.yaml", optional: false);
            configurationBuilder.AddYamlFile($"{filenamePrefix}.Development.yaml", optional: true);
            configurationBuilder.AddYamlFile($"{filenamePrefix}.Production.yaml", optional: true);
        });
    }
}
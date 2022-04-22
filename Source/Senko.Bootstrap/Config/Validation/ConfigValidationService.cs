using Microsoft.Extensions.DependencyInjection;
using NiallVR.Senko.Bootstrap.Hosted.Abstract;

namespace NiallVR.Senko.Bootstrap.Config.Validation; 

/// <summary>
/// Service which validates all of the <see cref="IValidatedConfig"/> found in the <see cref="IServiceProvider"/>.
/// </summary>
internal class ConfigValidationService : HostedService {
    public ConfigValidationService(IServiceProvider services) {
        foreach (var configValidator in services.GetServices<IValidatedConfig>()) {
            configValidator.Validate();
        }
    }
}
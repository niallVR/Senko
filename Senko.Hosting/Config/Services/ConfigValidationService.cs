using Microsoft.Extensions.DependencyInjection;
using NiallVR.Senko.Hosting.Config.Interfaces;
using NiallVR.Senko.Hosting.Hosted.Abstract;

namespace NiallVR.Senko.Hosting.Config.Services; 

/// <summary>
/// Service which run the validation checking as soon as it's created.
/// </summary>
internal class ConfigValidationService : HostedService {
    public ConfigValidationService(IServiceProvider services) {
        foreach (var configValidator in services.GetServices<IConfigValidator>()) {
            configValidator.Validate();
        }
    }
}
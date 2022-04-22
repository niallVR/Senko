namespace NiallVR.Senko.Bootstrap.Config.Validation; 

/// <summary>
/// Objects which inherit this interface are validated at the start of the application.
/// </summary>
/// <remarks>
/// To enable config validation,
/// call the <see cref="ConfigValidationExtensions.UseConfigValidation(Microsoft.Extensions.Hosting.IHostBuilder)"/> extension.
/// </remarks>
public interface IValidatedConfig {
    /// <summary>
    /// Called at the start of the application to validate this configuration object.
    /// </summary>
    void Validate();
}
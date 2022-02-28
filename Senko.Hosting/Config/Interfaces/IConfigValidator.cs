namespace NiallVR.Senko.Hosting.Config.Interfaces; 

public interface IConfigValidator {
    /// <summary>
    /// Called upon startup to validate this configuration object.
    /// </summary>
    void Validate();
}
using System.ComponentModel.DataAnnotations;
using NiallVR.Senko.Hosting.Config.Interfaces;

namespace NiallVR.Senko.Hosting.Config.Abstract; 

/// <summary>
/// A wrapper around <see cref="IConfigValidator"/> using <see cref="Validator.ValidateObject(object, ValidationContext, bool)"/>.
/// </summary>
public abstract class ConfigValidator : IConfigValidator {
    public void Validate() {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}
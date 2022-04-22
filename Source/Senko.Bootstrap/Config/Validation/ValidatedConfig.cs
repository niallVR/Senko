using System.ComponentModel.DataAnnotations;

namespace NiallVR.Senko.Bootstrap.Config.Validation; 

/// <summary>
/// A wrapper around <see cref="IValidatedConfig"/> using <see cref="Validator.ValidateObject(object, ValidationContext, bool)"/>.
/// </summary>
public abstract class ValidatedConfig : IValidatedConfig {
    public void Validate() {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}
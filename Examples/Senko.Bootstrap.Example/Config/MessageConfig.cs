using System.ComponentModel.DataAnnotations;
using NiallVR.Senko.Bootstrap.Config.Validation;

namespace Senko.Bootstrap.Example.Config; 

public class MessageConfig : ValidatedConfig {
    /// <summary>
    /// The amount of time in seconds to wait for printing the <see cref="Content"/>.
    /// </summary>
    [Required]
    public int Interval { get; set; }
    
    /// <summary>
    /// The message to be printed out after the <see cref="Interval"/>.
    /// </summary>
    [Required]
    public string Content { get; set; }
}
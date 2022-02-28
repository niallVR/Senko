using System.ComponentModel.DataAnnotations;
using NiallVR.Senko.Hosting.Config.Abstract;
using NiallVR.Senko.Hosting.Config.Interfaces;

namespace Senko.Hosting.Example.Config; 

public class ExampleConfig : ConfigValidator {
    [Required]
    public string TestString { get; init; }
}
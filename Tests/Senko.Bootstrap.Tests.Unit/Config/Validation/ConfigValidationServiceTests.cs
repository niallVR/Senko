using System;
using Microsoft.Extensions.DependencyInjection;
using NiallVR.Senko.Bootstrap.Config.Validation;
using NSubstitute;
using Xunit;

namespace Senko.Bootstrap.Tests.Unit.Config.Validation; 

public class ConfigValidationServiceTests {
    private readonly IValidatedConfig _config1 = Substitute.For<IValidatedConfig>();
    private readonly IValidatedConfig _config2 = Substitute.For<IValidatedConfig>();
    private readonly IServiceProvider _services;

    public ConfigValidationServiceTests() {
        _services = new ServiceCollection()
            .AddSingleton(_config1)
            .AddSingleton(_config2)
            .BuildServiceProvider();
    }

    [Fact]
    public void Ctor_Should_ValidateAllConfigs() {
        // Act
        var _ = new ConfigValidationService(_services);

        // Assert
        _config1.Received(1).Validate();
        _config2.Received(1).Validate();
    }
}
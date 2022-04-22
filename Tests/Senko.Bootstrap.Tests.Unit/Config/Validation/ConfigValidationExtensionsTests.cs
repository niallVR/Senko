using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NiallVR.Senko.Bootstrap.Config.Validation;
using Xunit;

namespace Senko.Bootstrap.Tests.Unit.Config.Validation; 

public class ConfigValidationExtensionsTests {
    public class MockConfig {
    }
    
    public class MockValidatedConfig : IValidatedConfig {
        public void Validate() {
        }
    }

    [Fact]
    public void BindConfig_Should_MapConfigAndAddToServices_When_DoesntValidatedConfig() {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());

        // Act
        serviceCollection.BindConfig<MockConfig>("Test");

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IOptions<MockConfig>>().Should().NotBeNull();
        services.GetService<MockConfig>().Should().NotBeNull();
        services.GetService<IValidatedConfig>().Should().BeNull();
    }
    
    [Fact]
    public void BindConfig_Should_MapConfigAndAddToServices_When_ImplementsValidatedConfig() {
        // Arrange
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());

        // Act
        serviceCollection.BindConfig<MockValidatedConfig>("Test");

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IOptions<MockValidatedConfig>>().Should().NotBeNull();
        services.GetService<MockValidatedConfig>().Should().NotBeNull();
        services.GetService<IValidatedConfig>().Should().NotBeNull();
    }
}
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Senko.Bootstrap.Hosted.Abstract;
using NiallVR.Senko.Bootstrap.Hosted.Extensions;
using Xunit;

namespace Senko.Bootstrap.Tests.Unit.Hosted.Extensions; 

public class HostingExtensionsTests {
    public class MockHostedService : HostedService {}

    [Fact]
    public void AddHostedServiceAsSelf_Should_AddServiceAsInterfaceAndType() {
        // Arrange
        var serviceCollection = new ServiceCollection();
        
        // Act
        serviceCollection.AddHostedServiceAsSelf<MockHostedService>();

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IHostedService>().Should().NotBeNull();
        services.GetService<IHostedService>().Should().BeAssignableTo<MockHostedService>();
        services.GetService<MockHostedService>().Should().NotBeNull();
    }
    
    [Fact]
    public void AddHostedServiceAsSelf_Func_Should_AddServiceAsInterfaceAndType() {
        // Arrange
        var serviceCollection = new ServiceCollection();
        
        // Act
        serviceCollection.AddHostedServiceAsSelf(_ => new MockHostedService());

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IHostedService>().Should().NotBeNull();
        services.GetService<IHostedService>().Should().BeAssignableTo<MockHostedService>();
        services.GetService<MockHostedService>().Should().NotBeNull();
    }
}
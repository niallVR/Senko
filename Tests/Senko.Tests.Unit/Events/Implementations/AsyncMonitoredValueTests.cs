using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Events.Implementations;
using Xunit;

namespace Senko.Core.Tests.Unit.Events.Implementations; 

public class AsyncMonitoredValueTests {

    private readonly AsyncMonitoredValue<int> _systemUnderTest = new(0);

    [Fact]
    public async Task SetValueAsync_Should_UpdateStoredValue() {
        // Act
        await _systemUnderTest.SetValueAsync(10);

        // Assert
        _systemUnderTest.Value.Should().Be(10);
    }
    
    [Fact]
    public async Task SetValueAsync_Should_TriggerEvent() {
        // Arrange
        var eventValue = 0;
        _systemUnderTest.OnChanged.Subscribe(e => { eventValue = e; return Task.CompletedTask; });

        // Act
        await _systemUnderTest.SetValueAsync(10);

        // Assert
        eventValue.Should().Be(10);
    }
}
using System;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Async.Events.Entities;
using NiallVR.Senko.Async.Utilities;
using Xunit;

namespace Senko.Async.Tests.Events.Entities; 

public class MonitoredValueTests {

    private readonly MonitoredValue<int> _systemUnderTest = new(1);

    [Fact]
    public void UpdateValue_Should_UpdateStoredValue() {
        _systemUnderTest.UpdateValue(10);

        _systemUnderTest.Value.Should().Be(10);
    }
    
    [Fact]
    public async Task UpdateValue_Should_TriggerEvent() {
        var eventValue = 0;
        _systemUnderTest.OnChanged.Subscribe(e => { eventValue = e; return Task.CompletedTask; });

        _systemUnderTest.UpdateValue(10);
        await TaskUtils.WaitForCondition(() => eventValue == 10, TimeSpan.FromSeconds(2));

        eventValue.Should().Be(10);
    }
}
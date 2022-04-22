using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Core.Events.Implementations;
using Xunit;

namespace Senko.Core.Tests.Unit.Events.Implementations; 

public class AsyncEventTests {
    private readonly Func<int, Task> _listener1 = _ => Task.CompletedTask;
    private readonly Func<int, Task> _listener2 = _ => Task.CompletedTask;
    
    private readonly AsyncEvent<int> _systemUnderTest = new();

    [Fact]
    public void Subscribe_Should_AddListeners() {
        // Act
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener2);
        
        // Assert
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(2);
        listeners.Should().Contain(_listener1);
        listeners.Should().Contain(_listener2);
    }

    [Fact]
    public void Subscribe_Should_AllowMultipleListenersOfTheSameType() {
        // Act
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener1);
        
        // Assert
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(2);
        listeners.All(l => l == _listener1).Should().BeTrue();
    }
    
    [Fact]
    public void Unsubscribe_Should_RemoveOnlyOneListener() {
        // Arrange
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener1);
        
        // Act
        _systemUnderTest.Unsubscribe(_listener1);

        // Assert
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(1);
        listeners.Should().Contain(_listener1);
    }
    
    [Fact]
    public void ClearListeners_Should_RemoveAllListener() {
        // Arrange
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener2);
        
        // Act
        _systemUnderTest.ClearListeners();
        
        // Assert
        _systemUnderTest.GetListeners().Should().BeEmpty();
    }

    [Fact(Timeout = 150)]
    public async Task InvokeAsync_Should_CallListeners() {
        // Arrange
        var calledListeners = new ConcurrentBag<int>(); 
        _systemUnderTest.Subscribe(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledListeners.Add(1); });
        _systemUnderTest.Subscribe(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledListeners.Add(2); });

        // Act
        await _systemUnderTest.InvokeAsync(0);

        // Assert
        calledListeners.Should().HaveCount(2);
        calledListeners.Should().Contain(1);
        calledListeners.Should().Contain(2);
    }
    
    [Fact]
    public async Task InvokeAsync_Should_ThrowListenerExceptions() {
        // Arrange
        _systemUnderTest.Subscribe(_ => throw new ArgumentNullException());
        _systemUnderTest.Subscribe(async _ => { 
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            throw new SystemException();
        });

        // Act
        var act = async () => await _systemUnderTest.InvokeAsync(0);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
        await act.Should().ThrowAsync<SystemException>();
    }
    
    [Fact]
    public async Task InvokeAsync_Should_PassArgumentToListeners() {
        // Arrange
        var providedValue = 0;
        _systemUnderTest.Subscribe(number => { providedValue = number; return Task.CompletedTask; });

        // Act
        await _systemUnderTest.InvokeAsync(10);

        // Assert
        providedValue.Should().Be(10);
    }
}
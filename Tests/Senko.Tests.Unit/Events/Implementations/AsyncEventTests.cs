using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Events.Implementations;
using Xunit;

namespace Senko.Core.Tests.Unit.Events.Implementations; 

public class AsyncEventTests {
    private readonly Func<int, Task> _listener1 = _ => Task.CompletedTask;
    private readonly Func<int, Task> _listener2 = _ => Task.CompletedTask;
    
    private readonly AsyncEvent<int> _systemUnderTest = new();

    [Fact]
    public void Subscribe_Should_AddListeners() {
        // Act
        _systemUnderTest.AddListener(_listener1);
        _systemUnderTest.AddListener(_listener2);
        
        // Assert
        _systemUnderTest.GetListeners().Should().HaveCount(2);
        _systemUnderTest.GetListeners().Should().Contain(_listener1);
        _systemUnderTest.GetListeners().Should().Contain(_listener2);
    }

    [Fact]
    public void Subscribe_Should_AllowMultipleListenersOfTheSameType() {
        // Act
        _systemUnderTest.AddListener(_listener1);
        _systemUnderTest.AddListener(_listener1);
        
        // Assert
        _systemUnderTest.GetListeners().Should().HaveCount(2);
        _systemUnderTest.GetListeners().All(l => l == _listener1).Should().BeTrue();
    }
    
    [Fact]
    public void Unsubscribe_Should_RemoveOnlyOneListener() {
        // Arrange
        _systemUnderTest.AddListener(_listener1);
        _systemUnderTest.AddListener(_listener1);
        
        // Act
        _systemUnderTest.RemoveListener(_listener1);

        // Assert
        _systemUnderTest.GetListeners().Should().HaveCount(1);
        _systemUnderTest.GetListeners().Should().Contain(_listener1);
    }
    
    [Fact]
    public void ClearListeners_Should_RemoveAllListener() {
        // Arrange
        _systemUnderTest.AddListener(_listener1);
        _systemUnderTest.AddListener(_listener2);
        
        // Act
        _systemUnderTest.ClearListeners();
        
        // Assert
        _systemUnderTest.GetListeners().Should().BeEmpty();
    }

    [Fact(Timeout = 100)]
    public async Task InvokeAsync_Should_CallListenersAtSameTime() {
        // Arrange
        var calledListeners = new ConcurrentBag<int>(); 
        _systemUnderTest.AddListener(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(50)); calledListeners.Add(1); });
        _systemUnderTest.AddListener(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(50)); calledListeners.Add(2); });

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
        _systemUnderTest.AddListener(_ => throw new ArgumentNullException());
        _systemUnderTest.AddListener(async _ => { 
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
        _systemUnderTest.AddListener(number => { providedValue = number; return Task.CompletedTask; });

        // Act
        await _systemUnderTest.InvokeAsync(10);

        // Assert
        providedValue.Should().Be(10);
    }
}
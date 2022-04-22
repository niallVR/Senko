using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NiallVR.Senko.Core.Events.Implementations;
using Xunit;

namespace Senko.Core.Tests.Unit.Events.Implementations; 

public class AsyncEventChannelTests : IDisposable {
    private readonly Func<int, Task> _worker1 = _ => Task.CompletedTask;
    private readonly Func<int, Task> _worker2 = _ => Task.CompletedTask;

    private readonly AsyncEventChannel<int> _systemUnderTest = new(new NullLogger<AsyncEventChannel<int>>());

    public void Dispose() => _systemUnderTest.Dispose();
    
    [Fact]
    public void AddWorker_Should_AddListenersToEvent() {
        // Act
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker2);
        
        // Assert
        var listeners = _systemUnderTest.GetWorkers();
        listeners.Should().HaveCount(2);
        listeners.Should().Contain(_worker1);
        listeners.Should().Contain(_worker2);
    }

    [Fact]
    public void AddWorker_Should_AllowMultipleWorkersOfTheSameType() {
        // Act
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker1);
        
        // Assert
        var listeners = _systemUnderTest.GetWorkers();
        listeners.Should().HaveCount(2);
        listeners.All(l => l == _worker1).Should().BeTrue();
    }
    
    [Fact]
    public void RemoveWorker_Should_RemoveOnlyOneListenerFromEvent() {
        // Arrange
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker1);
        
        // Act
        _systemUnderTest.RemoveWorker(_worker1);

        // Assert
        var listeners = _systemUnderTest.GetWorkers();
        listeners.Should().HaveCount(1);
        listeners.Should().Contain(_worker1);
    }
    
    [Fact]
    public void ClearWorkers_Should_RemoveAllListenersFromEvent() {
        // Arrange
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker2);
        
        // Act
        _systemUnderTest.ClearWorkers();
        
        // Assert
        _systemUnderTest.GetWorkers().Should().HaveCount(0);
    }

    [Fact]
    public async Task ProcessEventAsync_Should_QueueAndProcessEvent_When_QueueIsEmpty() {
        // Arrange
        var providedData = 0; 
        _systemUnderTest.AddWorker(i => { providedData = i; return Task.CompletedTask; });

        // Act
        await _systemUnderTest.ProcessEventAsync(10);
        await Task.Delay(TimeSpan.FromMilliseconds(300));

        // Assert
        providedData.Should().Be(10);
    }
    
    [Fact]
    public async Task ProcessEventAsync_Should_QueueEvent_When_QueueIsNotEmpty() {
        // Arrange
        var providedData = new List<int>(); 
        _systemUnderTest.AddWorker(async i => {
            await Task.Delay(TimeSpan.FromMilliseconds(i == 1 ? 200 : 10));
            providedData.Add(i);
        });

        // Act
        await _systemUnderTest.ProcessEventAsync(1);
        await _systemUnderTest.ProcessEventAsync(2);
        await Task.Delay(TimeSpan.FromMilliseconds(250));

        // Assert
        providedData.Should().HaveCount(2);
        providedData.Should().HaveElementAt(0, 1);
        providedData.Should().HaveElementAt(1, 2);
    }
    
    [Fact]
    public async Task ProcessEventAsync_Should_CallAllWorkers() {
        // Arrange
        var calledWorkers = new ConcurrentBag<int>(); 
        _systemUnderTest.AddWorker(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledWorkers.Add(1); });
        _systemUnderTest.AddWorker(async _ => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledWorkers.Add(2); });

        // Act
        await _systemUnderTest.ProcessEventAsync(0);
        await Task.Delay(TimeSpan.FromMilliseconds(300));

        // Assert
        calledWorkers.Should().HaveCount(2);
        calledWorkers.Should().Contain(1);
        calledWorkers.Should().Contain(2);
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NiallVR.Senko.Events.Implementations;
using Xunit;

namespace Senko.Core.Tests.Unit.Events.Implementations; 

public class AsyncEventChannelTests : IDisposable {
    private readonly Func<int, CancellationToken, Task> _worker1 = (_, _) => Task.CompletedTask;
    private readonly Func<int, CancellationToken, Task> _worker2 = (_, _) => Task.CompletedTask;

    private readonly AsyncEventChannel<int> _systemUnderTest = new(new NullLogger<AsyncEventChannel<int>>());

    public void Dispose() => _systemUnderTest.Dispose();
    
    [Fact]
    public void AddWorker_Should_AddWorkersToTheEventChannel() {
        // Act
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker2);
        
        // Assert
        _systemUnderTest.GetWorkers().Should().HaveCount(2);
        _systemUnderTest.GetWorkers().Should().Contain(_worker1);
        _systemUnderTest.GetWorkers().Should().Contain(_worker2);
    }

    [Fact]
    public void AddWorker_Should_AllowMultipleWorkersOfTheSameType() {
        // Act
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker1);
        
        // Assert
        _systemUnderTest.GetWorkers().Should().HaveCount(2);
        _systemUnderTest.GetWorkers().All(l => l == _worker1).Should().BeTrue();
    }
    
    [Fact]
    public void RemoveWorker_Should_RemoveOnlyOneWorker() {
        // Arrange
        _systemUnderTest.AddWorker(_worker1);
        _systemUnderTest.AddWorker(_worker1);
        
        // Act
        _systemUnderTest.RemoveWorker(_worker1);

        // Assert
        _systemUnderTest.GetWorkers().Should().HaveCount(1);
        _systemUnderTest.GetWorkers().Should().Contain(_worker1);
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
    public async Task AddEventAsync_Should_QueueAndProcessEvent_When_QueueIsEmpty() {
        // Arrange
        var providedData = 0; 
        _systemUnderTest.AddWorker((i, _) => { providedData = i; return Task.CompletedTask; });

        // Act
        await _systemUnderTest.AddEventAsync(10);
        await Task.Delay(TimeSpan.FromMilliseconds(300));

        // Assert
        providedData.Should().Be(10);
    }
    
    [Fact]
    public async Task AddEventAsync_Should_QueueEvent_When_QueueIsNotEmpty() {
        // Arrange
        var providedData = new List<int>(); 
        _systemUnderTest.AddWorker(async (i, _) => {
            await Task.Delay(TimeSpan.FromMilliseconds(i == 1 ? 200 : 10));
            providedData.Add(i);
        });

        // Act
        await _systemUnderTest.AddEventAsync(1);
        await _systemUnderTest.AddEventAsync(2);
        await Task.Delay(TimeSpan.FromMilliseconds(250));

        // Assert
        providedData.Should().HaveCount(2);
        providedData.Should().HaveElementAt(0, 1);
        providedData.Should().HaveElementAt(1, 2);
    }
    
    [Fact]
    public async Task AddEventAsync_Should_CallAllWorkers() {
        // Arrange
        var calledWorkers = new ConcurrentBag<int>(); 
        _systemUnderTest.AddWorker(async (_, _) => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledWorkers.Add(1); });
        _systemUnderTest.AddWorker(async (_, _) => { await Task.Delay(TimeSpan.FromMilliseconds(100)); calledWorkers.Add(2); });

        // Act
        await _systemUnderTest.AddEventAsync(0);
        await Task.Delay(TimeSpan.FromMilliseconds(300));

        // Assert
        calledWorkers.Should().HaveCount(2);
        calledWorkers.Should().Contain(1);
        calledWorkers.Should().Contain(2);
    }

    [Fact(Timeout = 1000)]
    public async Task ClearEvents_Should_StopCurrentEventAndRemoveAllEventsFromQueue()
    {
        // Arrange
        var processedNumbers = new List<int>();
        var processedEventStopped = false;
        _systemUnderTest.AddWorker(async (i, cancelToken) =>
        {
            processedNumbers.Add(i);
            while (!cancelToken.IsCancellationRequested)
            {
                await Task.Delay(25);
            }
            processedEventStopped = true;
        });

        // Act
        for (var i = 0; i < 20; i++) 
            _ = _systemUnderTest.AddEventAsync(i);
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        _systemUnderTest.ClearEvents();
        await Task.Delay(TimeSpan.FromMilliseconds(100));
        
        // Assert
        processedNumbers.Should().HaveCount(1);
        processedNumbers.Should().Contain(0);
        processedEventStopped.Should().BeTrue();
    }
}
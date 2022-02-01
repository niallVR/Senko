using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NiallVR.Senko.Async.Events.Entities;
using Xunit;

namespace Senko.Async.Tests.Events.Entities; 

public class AsyncEventChannelGenericTests : IDisposable {
        private readonly Func<int, Task> _listener1 = _ => Task.CompletedTask;
    private readonly Func<int, Task> _listener2 = _ => Task.CompletedTask;

    private readonly AsyncEventChannel<int> _systemUnderTest = new(new NullLogger<AsyncEventChannel>());

    public void Dispose() => _systemUnderTest.Dispose();
    
    [Fact]
    public void Subscribe_Should_AddListener() {
        _systemUnderTest.Subscribe(_listener1);
        
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(1);
        listeners.Should().Contain(_listener1);
    }

    [Fact]
    public void Subscribe_Should_AllowMultipleListenersOfTheSameType() {
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener1);
        
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(2);
        listeners.All(l => l == _listener1).Should().BeTrue();
    }
    
    [Fact]
    public void Subscribe_Should_AllowListenersOfDifferentTypes() {
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener2);
        
        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(2);
        listeners.Should().Contain(_listener1);
        listeners.Should().Contain(_listener2);
    }

    [Fact]
    public void Unsubscribe_Should_RemoveFirstMatchingListener() {
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener1);
        
        _systemUnderTest.Unsubscribe(_listener1);

        var listeners = _systemUnderTest.GetListeners();
        listeners.Should().HaveCount(1);
        listeners.Should().Contain(_listener1);
    }
    
    [Fact]
    public void ClearListeners_Should_RemoveAllListener() {
        _systemUnderTest.Subscribe(_listener1);
        _systemUnderTest.Subscribe(_listener2);
        
        _systemUnderTest.ClearListeners();
        
        _systemUnderTest.GetListeners().Should().HaveCount(0);
    }

    [Fact]
    public async Task Invoke_Should_InvokeListeners() {
        var results = new List<int>();
        Func<int, Task> listener = i => { results.Add(i); return Task.CompletedTask; };
        _systemUnderTest.Subscribe(listener);
        _systemUnderTest.Subscribe(listener);

        await _systemUnderTest.Invoke(10);
        await Task.Delay(TimeSpan.FromSeconds(0.2));

        results.Should().HaveCount(2);
        results.All(i => i == 10).Should().BeTrue();
    }
}
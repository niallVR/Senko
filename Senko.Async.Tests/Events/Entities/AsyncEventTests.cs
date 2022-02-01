using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NiallVR.Senko.Extensions.Events.Entities;
using Xunit;

namespace Senko.Async.Tests.Events.Entities; 

public class AsyncEventTests {
    private readonly Func<Task> _listener1 = () => Task.CompletedTask;
    private readonly Func<Task> _listener2 = () => Task.CompletedTask;
    
    private readonly AsyncEvent _systemUnderTest = new(new NullLogger<AsyncEvent>());

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
    public async Task InvokeSync_Should_CallListenersInOrderTheyWereAdded() {
        var callOrder = new List<int>();
        _systemUnderTest.Subscribe(async () => { await Task.Delay(TimeSpan.FromSeconds(0.2)); callOrder.Add(1); });
        _systemUnderTest.Subscribe(() => { callOrder.Add(2); return Task.CompletedTask; });

        await _systemUnderTest.InvokeSync();

        callOrder.Should().HaveCount(2);
        callOrder.ElementAt(0).Should().Be(1);
        callOrder.ElementAt(1).Should().Be(2);
    }
    
    [Fact]
    public async Task InvokeSync_Should_HandleErrorsInternally() {
        _systemUnderTest.Subscribe(() => throw new Exception());

        var act = async () => await _systemUnderTest.InvokeSync();

        await act.Should().NotThrowAsync();
    }
    
    [Fact]
    public async Task InvokeAsync_Should_CallListenersAtTheSameTime() {
        var callOrder = new List<int>();
        _systemUnderTest.Subscribe(async () => { await Task.Delay(TimeSpan.FromSeconds(0.2)); callOrder.Add(1); });
        _systemUnderTest.Subscribe(() => { callOrder.Add(2); return Task.CompletedTask; });

        await _systemUnderTest.InvokeAsync();

        callOrder.Should().HaveCount(2);
        callOrder.ElementAt(0).Should().Be(2);
        callOrder.ElementAt(1).Should().Be(1);
    }
    
    [Fact]
    public async Task InvokeAsync_Should_HandleErrorsInternally() {
        _systemUnderTest.Subscribe(() => throw new Exception());

        var act = async () => await _systemUnderTest.InvokeAsync();

        await act.Should().NotThrowAsync();
    }
}
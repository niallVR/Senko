using System;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Extensions.Extensions;
using Xunit;

namespace Senko.Async.Tests.Extensions; 

public class TaskExtensionsTests {

    private readonly TaskCompletionSource _taskCompletionSource = new();
    private readonly TaskCompletionSource<string> _taskCompletionSourceGeneric = new();
    
    [Fact]
    public async Task WithTimeout_NonGeneric_Should_ReturnTrue_When_NotTimeout() {
        var runningTask = _taskCompletionSource.Task.WithTimeout(TimeSpan.FromSeconds(.2));
        
        _taskCompletionSource.SetResult();
        var result = await runningTask;

        result.Should().BeTrue();
    }
        
    [Fact]
    public async Task WithTimeout_NonGeneric_Should_ReturnFalse_When_Timeout() {
        var runningTask = _taskCompletionSource.Task.WithTimeout(TimeSpan.FromSeconds(.2));
        
        var result = await runningTask;

        result.Should().BeFalse();
    }
        
    [Fact]
    public async Task WithTimeout_Generic_Should_ReturnOriginalTask_When_NotTimeout() {
        var runningTask = _taskCompletionSourceGeneric.Task.WithTimeout(TimeSpan.FromSeconds(.2));
        
        _taskCompletionSourceGeneric.SetResult("Hello World!");
        var (success, result) = await runningTask;

        success.Should().BeTrue();
        result.Should().Be("Hello World!");
    }
        
    [Fact]
    public async Task WithTimeout_Generic_Returns_Default_When_NotTimeout() {
        var runningTask = _taskCompletionSourceGeneric.Task.WithTimeout(TimeSpan.FromSeconds(.2));

        var (success, result) = await runningTask;

        success.Should().BeFalse();
        result.Should().BeNull();
    }
}
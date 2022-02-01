using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NiallVR.Senko.Async.Utilities;
using Xunit;

namespace Senko.Async.Tests.Utilities; 

public class TaskUtilsTests {
    private readonly ILogger _logger = new NullLogger<object>();

    [Fact]
    public async Task RunEndlessly_Should_Continue_When_TaskErrors() {
        using var cancelToken = new CancellationTokenSource();
        var runCount = 0;

        TaskUtils.RunEndlessly(() => { runCount++; throw new Exception(); }, _logger, cancelToken.Token);
        await Task.Delay(TimeSpan.FromSeconds(.2), cancelToken.Token);
        cancelToken.Cancel();

        runCount.Should().BeGreaterThan(1);
    }
    
    [Fact]
    public async Task RunEndlessly_Should_NotContinue_When_TaskErrorsAndContinueDisabled() {
        using var cancelToken = new CancellationTokenSource();
        var runCount = 0;


        TaskUtils.RunEndlessly(() => { runCount++; throw new Exception(); }, _logger, cancelToken.Token, false);
        await Task.Delay(TimeSpan.FromSeconds(.2), cancelToken.Token);
        cancelToken.Cancel();

        runCount.Should().Be(1);
    }

    [Fact]
    public async Task TryRun_Should_ReturnTrue_When_TaskDoesntThrow() {
        var result = await TaskUtils.TryRun(() => Task.CompletedTask, _logger);

        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task TryRun_Should_ReturnFalse_When_TaskThrows() {
        var result = await TaskUtils.TryRun(() => throw new Exception(), _logger);
        
        result.Should().BeFalse();
    }

    [Fact]
    public async Task TryRun_WithArg_Should_ReturnTrue_When_TaskDoesntThrow() {
        var result = await TaskUtils.TryRun(_ => Task.CompletedTask, string.Empty, _logger);
        
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task TryRun_WithArg_Should_ReturnFalse_When_TaskThrows() {
        var result = await TaskUtils.TryRun(_ => throw new Exception(), string.Empty, _logger);
        
        result.Should().BeFalse();
    }

    [Fact]
    public async Task WaitForCondition_Should_ReturnTrue_When_ConditionIsMet() {
        var result = await TaskUtils.WaitForCondition(() => true, TimeSpan.FromSeconds(0.5));

        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task WaitForCondition_Should_ReturnFalse_When_TimeoutIsReached() {
        var result = await TaskUtils.WaitForCondition(() => false, TimeSpan.FromSeconds(0.5));

        result.Should().BeFalse();
    }
}
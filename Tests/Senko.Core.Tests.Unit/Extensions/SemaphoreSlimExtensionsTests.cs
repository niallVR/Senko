using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Core.Extensions;
using Xunit;

namespace Senko.Core.Tests.Unit.Extensions; 

public class SemaphoreSlimExtensionsTests : IDisposable {
    private readonly SemaphoreSlim _systemUnderTest = new(1);

    [Fact]
    public async Task WaitAsyncDisposable_Should_WaitToEnterSemaphoreSlim() {
        // Act
        var lockInstance = await _systemUnderTest.WaitAsyncDisposable();

        // Assert
        _systemUnderTest.CurrentCount.Should().Be(0);
        lockInstance.Should().BeOfType<SemaphoreSlimExtensions.SemaphoreSlimReleaser>();
    }
    
    [Fact]
    public async Task WaitAsyncDisposable_Should_ReleaseLockWhenDisposed() {
        // Arrange
        var lockInstance = await _systemUnderTest.WaitAsyncDisposable();
        
        // Act
        lockInstance.Dispose();

        // Assert
        _systemUnderTest.CurrentCount.Should().Be(1);
    }
    
    public void Dispose() {
        _systemUnderTest.Dispose();
        GC.SuppressFinalize(this);
    }
}
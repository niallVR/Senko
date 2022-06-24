using System;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Extensions;
using NiallVR.Senko.Locks;
using Xunit;

namespace Senko.Core.Tests.Unit.Extensions; 

public class SemaphoreQueueExtensionsTests : IDisposable {
    private readonly SemaphoreQueue _systemUnderTest = new(1);

    [Fact]
    public async Task WaitAsyncDisposable_Should_WaitToEnterSemaphoreSlim() {
        // Act
        var lockInstance = await _systemUnderTest.WaitAsyncDisposable();

        // Assert
        _systemUnderTest.CurrentCount.Should().Be(0);
        lockInstance.Should().BeOfType<SemaphoreQueueExtensions.SemaphoreQueueReleaser>();
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
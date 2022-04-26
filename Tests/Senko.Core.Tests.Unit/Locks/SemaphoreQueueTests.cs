using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NiallVR.Senko.Core.Locks;
using Xunit;

namespace Senko.Core.Tests.Unit.Locks; 

public class SemaphoreQueueTests {
    private readonly SemaphoreQueue _systemUnderTest = new(1);

    [Fact(Timeout = 3000)]
    public async Task WaitAsync_Should_ReturnATaskWhichComplete_When_NextInLine() {
        // Arrange
        var resultList = new List<int>();
        async Task AddToResultsList(int index) {
            await _systemUnderTest.WaitAsync();
            resultList.Add(index);
            _systemUnderTest.Release();
        }

        // Act
        await Task.WhenAll(Enumerable.Range(0, 20).Select(AddToResultsList));
        
        // Assert
        resultList.Should().BeInAscendingOrder();
    }
}
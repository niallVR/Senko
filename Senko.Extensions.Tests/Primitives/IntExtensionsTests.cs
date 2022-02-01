using FluentAssertions;
using NiallVR.Senko.Extensions.Primitives;
using Xunit;

namespace Senko.Extensions.Tests.Primitives; 

public class IntExtensionsTests {
    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, false)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, false)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_IntNotInclusive_Should_ReturnExpected(int number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, true)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, true)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_IntInclusive_Should_ReturnExpected(int number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((uint)0, 1UL, 5UL, false)]
    [InlineData((uint)1, 1UL, 5UL, false)]
    [InlineData((uint)3, 1UL, 5UL, true)]
    [InlineData((uint)5, 1UL, 5UL, false)]
    [InlineData((uint)6, 1UL, 5UL, false)]
    public void IsInRange_uIntNotInclusive_Should_ReturnExpected(uint number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((uint)0, 1UL, 5UL, false)]
    [InlineData((uint)1, 1UL, 5UL, true)]
    [InlineData((uint)3, 1UL, 5UL, true)]
    [InlineData((uint)5, 1UL, 5UL, true)]
    [InlineData((uint)6, 1UL, 5UL, false)]
    public void IsInRange_uIntInclusive_Should_ReturnExpected(uint number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }
}
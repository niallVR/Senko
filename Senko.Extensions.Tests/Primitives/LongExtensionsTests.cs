using FluentAssertions;
using NiallVR.Senko.Extensions.Primitives;
using Xunit;

namespace Senko.Extensions.Tests.Primitives; 

public class LongExtensionsTests {
    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, false)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, false)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_LongNotInclusive_Should_ReturnExpected(long number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, true)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, true)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_LongInclusive_Should_ReturnExpected(long number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((ulong)0, 1UL, 5UL, false)]
    [InlineData((ulong)1, 1UL, 5UL, false)]
    [InlineData((ulong)3, 1UL, 5UL, true)]
    [InlineData((ulong)5, 1UL, 5UL, false)]
    [InlineData((ulong)6, 1UL, 5UL, false)]
    public void IsInRange_uLongNotInclusive_Should_ReturnExpected(ulong number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((ulong)0, 1UL, 5UL, false)]
    [InlineData((ulong)1, 1UL, 5UL, true)]
    [InlineData((ulong)3, 1UL, 5UL, true)]
    [InlineData((ulong)5, 1UL, 5UL, true)]
    [InlineData((ulong)6, 1UL, 5UL, false)]
    public void IsInRange_uLongInclusive_Should_ReturnExpected(ulong number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }
}
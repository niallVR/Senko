using FluentAssertions;
using NiallVR.Senko.Extensions.Primitives;
using Xunit;

namespace Senko.Extensions.Tests.Primitives; 

public class ShortExtensionsTests {
    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, false)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, false)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_ShortNotInclusive_Should_ReturnExpected(short number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, true)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, true)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_ShortInclusive_Should_ReturnExpected(short number, long min, long max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((ushort)0, 1UL, 5UL, false)]
    [InlineData((ushort)1, 1UL, 5UL, false)]
    [InlineData((ushort)3, 1UL, 5UL, true)]
    [InlineData((ushort)5, 1UL, 5UL, false)]
    [InlineData((ushort)6, 1UL, 5UL, false)]
    public void IsInRange_uShortNotInclusive_Should_ReturnExpected(ushort number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData((ushort)0, 1UL, 5UL, false)]
    [InlineData((ushort)1, 1UL, 5UL, true)]
    [InlineData((ushort)3, 1UL, 5UL, true)]
    [InlineData((ushort)5, 1UL, 5UL, true)]
    [InlineData((ushort)6, 1UL, 5UL, false)]
    public void IsInRange_uShortInclusive_Should_ReturnExpected(ushort number, ulong min, ulong max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }
}
using FluentAssertions;
using NiallVR.Senko.Extensions.Primitives;
using Xunit;

namespace Senko.Extensions.Tests.Primitives; 

public class DoubleExtensionsTests {
    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, false)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, false)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_NotInclusive_Should_ReturnExpected(double number, double min, double max, bool expected) {
        var result = number.IsInRange(min, max, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, 0, 5, true)]
    [InlineData(3, 0, 5, true)]
    [InlineData(5, 0, 5, true)]
    [InlineData(6, 0, 5, false)]
    public void IsInRange_Inclusive_Should_ReturnExpected(double number, double min, double max, bool expected) {
        var result = number.IsInRange(min, max, true);
        
        result.Should().Be(expected);
    }
}
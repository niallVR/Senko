using FluentAssertions;
using NiallVR.Senko.Extensions.Primitives;
using Xunit;

namespace Senko.Extensions.Tests.Primitives; 

public class StringExtensionsTests {
    [Theory]
    [InlineData("Example", 3, "Exa")]
    [InlineData("Example", 4, "E...")]
    [InlineData("Example", 20, "Example")]
    public void LimitString_WithEllipsis_Should_ReturnExpected(string inputString, int limit, string expected) {
        var result = inputString.LimitString(limit, true);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Example", 3, "Exa")]
    [InlineData("Example", 4, "Exam")]
    [InlineData("Example", 20, "Example")]
    public void LimitString_WithoutEllipsis_Should_ReturnExpected(string inputString, int limit, string expected) {
        var result = inputString.LimitString(limit, false);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example", "example")]
    [InlineData("  example  ", "example")]
    [InlineData("EXAMPLE", "example")]
    [InlineData("  EXAMPLE  ", "example")]
    public void ToSearchFormat_Should_ReturnExpected(string input, string expected) {
        var result = input.ToSearchFormat();
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Example", "Examples", 0, "Examples")]
    [InlineData("Example", "Examples", 1, "Example")]
    [InlineData("Example", "Examples", 20, "Examples")]
    public void Plural_WithPlural_Should_ReturnExpected(string input, string plural, int amount, string expected) {
        var result = input.Plural(plural, amount);
        
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Example", 0, "Examples")]
    [InlineData("Example", 1, "Example")]
    [InlineData("Example", 20, "Examples")]
    public void Plural_WithoutPlural_Should_ReturnExpected(string input, int amount, string expected) {
        var result = input.Plural(amount);
        
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "example", true)]
    [InlineData("example", "EXAMPLE", true)]
    [InlineData("example", "test", false)]
    [InlineData("example", "TEST", false)]
    public void EqualsIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        var result = firstString.EqualsIgnoreCase(secondString);
        
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "am", true)]
    [InlineData("example", "AM", true)]
    [InlineData("example", "test", false)]
    [InlineData("example", "TEST", false)]
    public void ContainsIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        var result = firstString.ContainsIgnoreCase(secondString);
        
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "ex", true)]
    [InlineData("example", "EX", true)]
    [InlineData("example", "te", false)]
    [InlineData("example", "TE", false)]
    public void StartsWithIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        var result = firstString.StartsWithIgnoreCase(secondString);
        
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "le", true)]
    [InlineData("example", "LE", true)]
    [InlineData("example", "te", false)]
    [InlineData("example", "TE", false)]
    public void EndsWithIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        var result = firstString.EndsWithIgnoreCase(secondString);
        
        result.Should().Be(expected);
    }
}
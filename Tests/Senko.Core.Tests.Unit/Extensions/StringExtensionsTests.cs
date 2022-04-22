using FluentAssertions;
using NiallVR.Senko.Core.Extensions;
using Xunit;

namespace Senko.Core.Tests.Unit.Extensions; 

public class StringExtensionsTests {
    [Theory]
    [InlineData("Example", 3, "Exa")]
    [InlineData("Example", 4, "E...")]
    [InlineData("Example", 20, "Example")]
    public void LimitString_WithEllipsis_Should_ReturnExpected(string inputString, int limit, string expected) {
        // Act
        var result = inputString.LimitString(limit, true);
        
        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Example", 3, "Exa")]
    [InlineData("Example", 4, "Exam")]
    [InlineData("Example", 20, "Example")]
    public void LimitString_WithoutEllipsis_Should_ReturnExpected(string inputString, int limit, string expected) {
        // Act
        var result = inputString.LimitString(limit, false);
        
        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("example", "example")]
    [InlineData("  example  ", "example")]
    [InlineData("EXAMPLE", "example")]
    [InlineData("  EXAMPLE  ", "example")]
    public void ToSearchFormat_Should_ReturnExpected(string input, string expected) {
        // Act
        var result = input.ToSearchFormat();
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "example", true)]
    [InlineData("example", "EXAMPLE", true)]
    [InlineData("example", "test", false)]
    [InlineData("example", "TEST", false)]
    public void EqualsIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        // Act
        var result = firstString.EqualsIgnoreCase(secondString);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "am", true)]
    [InlineData("example", "AM", true)]
    [InlineData("example", "test", false)]
    [InlineData("example", "TEST", false)]
    public void ContainsIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        // Act
        var result = firstString.ContainsIgnoreCase(secondString);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "ex", true)]
    [InlineData("example", "EX", true)]
    [InlineData("example", "te", false)]
    [InlineData("example", "TE", false)]
    public void StartsWithIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        // Act
        var result = firstString.StartsWithIgnoreCase(secondString);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("example", "le", true)]
    [InlineData("example", "LE", true)]
    [InlineData("example", "te", false)]
    [InlineData("example", "TE", false)]
    public void EndsWithIgnoreCase_Should_ReturnExpected(string firstString, string secondString, bool expected) {
        // Act
        var result = firstString.EndsWithIgnoreCase(secondString);
        
        // Assert
        result.Should().Be(expected);
    }
}
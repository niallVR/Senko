using System;
using FluentAssertions;
using NiallVR.Senko.Core.Extensions;
using Xunit;

namespace Senko.Core.Tests.Unit.Extensions;

public class TimespanExtensionsTests {
    [Theory]
    [InlineData(0, "00:00:00")]
    [InlineData(1, "00:00:01")]
    [InlineData(10, "00:00:10")]
    [InlineData(11, "00:00:11")]
    [InlineData(60, "00:01:00")]
    [InlineData(600, "00:10:00")]
    [InlineData(660, "00:11:00")]
    [InlineData(3600, "01:00:00")]
    [InlineData(36000, "10:00:00")]
    [InlineData(39600, "11:00:00")]
    [InlineData(93671, "26:01:11")]
    public void AsShortFormat_Should_ReturnExpected_When_includeSecondsIsTrue(int totalSeconds, string expected) {
        // Arrange
        var timespan = TimeSpan.FromSeconds(totalSeconds);
        
        // Act
        var result = timespan.AsShortFormat(true);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(0, "00:00")]
    [InlineData(60, "00:01")]
    [InlineData(600, "00:10")]
    [InlineData(660, "00:11")]
    [InlineData(3600, "01:00")]
    [InlineData(36000, "10:00")]
    [InlineData(39600, "11:00")]
    [InlineData(93671, "26:01")]
    public void AsShortFormat_Should_ReturnExpected_When_includeSecondsIsFalse(int totalSeconds, string expected) {
        // Arrange
        var timespan = TimeSpan.FromSeconds(totalSeconds);
        
        // Act
        var result = timespan.AsShortFormat(false);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(1, "1 Second")]
    [InlineData(2, "2 Seconds")]
    [InlineData(60, "1 Minute")]
    [InlineData(120, "2 Minutes")]
    [InlineData(3600, "1 Hour")]
    [InlineData(7200, "2 Hours")]
    [InlineData(86400, "1 Day")]
    [InlineData(172800, "2 Days")]
    [InlineData(121, "2 Minutes and 1 Second")]
    [InlineData(3721, "1 Hour, 2 Minutes and 1 Second")]
    [InlineData(90061, "1 Day, 1 Hour, 1 Minute and 1 Second")]
    public void AsLongFormat_Should_ReturnExpected(int seconds, string expected) {
        // Arrange
        var timespan = TimeSpan.FromSeconds(seconds);
        
        // Act
        var result = timespan.AsLongFormat();

        // Assert
        result.Should().Be(expected);
    }
    
}
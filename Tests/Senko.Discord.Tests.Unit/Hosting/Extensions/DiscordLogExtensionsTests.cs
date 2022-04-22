using Discord;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Discord.Hosting.Extensions;
using Xunit;

namespace Senko.Discord.Tests.Unit.Hosting.Extensions; 

public class DiscordLogExtensionsTests {
    [Theory]
    [InlineData(LogSeverity.Critical, LogLevel.Critical)]
    [InlineData(LogSeverity.Error, LogLevel.Error)]
    [InlineData(LogSeverity.Warning, LogLevel.Warning)]
    [InlineData(LogSeverity.Info, LogLevel.Information)]
    [InlineData(LogSeverity.Verbose, LogLevel.Trace)]
    [InlineData(LogSeverity.Debug, LogLevel.Debug)]
    public void ToLogLevel_Should_ReturnExpectedLogLevel(LogSeverity input, LogLevel expected) {
        // Act
        var result = input.ToLogLevel();

        // Assert
        result.Should().Be(expected);
    }
}
using System;
using System.Collections.Generic;
using FluentAssertions;
using NiallVR.Senko.Extensions;
using Xunit;

namespace Senko.Core.Tests.Unit.Extensions; 

public class RandomExtensionsTests {
        private readonly Random _random = new();

    [Fact]
    public void GenerateRandomString_Should_ReturnAnEmptyString_When_LengthIsLessThanZero() {
        // Act
        var result = _random.GenerateRandomString(0);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnAnEmptyString_When_NoAlphabetSelected() {
        // Act
        var result = _random.GenerateRandomString(10, false, false, false);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnNumberOnlyString_When_OnlyNumbersSelected() {
        // Act
        var result = _random.GenerateRandomString(5, includeUpper: false, includeLower: false, includeNumbers: true);

        // Assert
        result.Should().MatchRegex("^[0-9]{5}$");
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnLowercaseOnlyString_When_OnlyLowerSelected() {
        // Act
        var result = _random.GenerateRandomString(5, includeUpper: false, includeLower: true, includeNumbers: false);

        // Assert
        result.Should().MatchRegex("^[a-z]{5}$");
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnUppercaseOnlyString_When_OnlyUppercaseSelected() {
        // Act
        var result = _random.GenerateRandomString(5, includeUpper: true, includeLower: false, includeNumbers: false);

        // Assert
        result.Should().MatchRegex("^[A-Z]{5}$");
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnMixedString_When_EverythingEnabled() {
        // Act
        var result = _random.GenerateRandomString(5, includeUpper: true, includeLower: true, includeNumbers: true);

        // Assert
        result.Should().MatchRegex("^[a-zA-Z0-9]{5}$");
    }

    [Fact]
    public void GenerateRandomString_Should_BeMostlyUnique() {
        // Act
        var output = new HashSet<string>();
        for (var i = 0; i < 10_000; i++)
            output.Add(_random.GenerateRandomString(10));

        // Assert
        var percentage = output.Count / 10_000 * 100;
        percentage.Should().BeGreaterThan(80);
    }
}
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FluentAssertions;
using NiallVR.Senko.Extensions.BuiltIn;
using Xunit;

namespace Senko.Extensions.Tests.BuiltIn; 

public class RandomExtensionsTests {
        private readonly Random _random = new();

    [Fact]
    public void GenerateRandomString_Should_ReturnAnEmptyString_When_LengthIsLessThanZero() {
        var result = _random.GenerateRandomString(0);

        result.Should().Be(string.Empty);
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnAnEmptyString_When_NoAlphabetSelected() {
        var result = _random.GenerateRandomString(10, false, false, false);

        result.Should().Be(string.Empty);
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnNumberOnlyString_When_OnlyNumbersSelected() {
        var result = _random.GenerateRandomString(5, includeUpper: false, includeLower: false, includeNumbers: true);

        result.Should().HaveLength(5);
        int.TryParse(result, out _).Should().BeTrue();
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnLowercaseOnlyString_When_OnlyLowerSelected() {
        var result = _random.GenerateRandomString(5, includeUpper: false, includeLower: true, includeNumbers: false);

        result.Should().HaveLength(5);
        Regex.Matches(result, @"[a-z]").Count.Should().Be(5);
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnUppercaseOnlyString_When_OnlyUppercaseSelected() {
        var result = _random.GenerateRandomString(5, includeUpper: true, includeLower: false, includeNumbers: false);

        result.Should().HaveLength(5);
        Regex.Matches(result, @"[A-Z]").Count.Should().Be(5);
    }

    [Fact]
    public void GenerateRandomString_Should_ReturnMixedString_When_EverythingEnabled() {
        var result = _random.GenerateRandomString(5, includeUpper: true, includeLower: true, includeNumbers: true);

        result.Should().HaveLength(5);
        Regex.Matches(result, @"[a-zA-Z0-9]").Count.Should().Be(5);
    }

    [Fact]
    public void GenerateRandomString_Should_BeMostlyUnique() {
        var output = new HashSet<string>();
        for (var i = 0; i < 10_000; i++)
            output.Add(_random.GenerateRandomString(10));

        var percentage = output.Count / 10_000 * 100;
        percentage.Should().BeGreaterThan(90);
    }
}
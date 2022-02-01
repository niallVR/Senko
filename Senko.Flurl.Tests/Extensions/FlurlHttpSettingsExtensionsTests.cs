using System.Text.Json;
using FluentAssertions;
using Flurl.Http.Configuration;
using NiallVR.Senko.Flurl.Entities;
using NiallVR.Senko.Flurl.Extensions;
using Xunit;

namespace Senko.Flurl.Tests.Extensions; 

public class FlurlHttpSettingsExtensionsTests {
    private readonly FlurlHttpSettings _settings = new();

    [Fact]
    public void UsingSystemJson_Should_ChangeSerializerToSystemJson() {
        var result = _settings.UsingSystemJson();

        result.Should().Be(_settings);
        result.JsonSerializer.Should().BeOfType<SystemJsonSerializer>();
    }
    
    [Fact]
    public void UsingSystemJson_CustomOptions_Should_ChangeSerializerToSystemJson() {
        var options = new JsonSerializerOptions();
        
        var result = _settings.UsingSystemJson(options);

        result.Should().Be(_settings);
        result.JsonSerializer.Should().BeOfType<SystemJsonSerializer>();
    }

    [Fact]
    public void DontThrowOnError_Should_SetAllowedHttpRange() {
        var result = _settings.DontThrowOnError();

        result.Should().Be(_settings);
        result.AllowedHttpStatusRange.Should().Be("*");
    }
}
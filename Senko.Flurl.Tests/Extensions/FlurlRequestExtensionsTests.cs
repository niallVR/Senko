using FluentAssertions;
using Flurl.Http;
using Flurl.Http.Configuration;
using NiallVR.Senko.Flurl.Entities;
using NiallVR.Senko.Flurl.Extensions;
using NSubstitute;
using Xunit;

namespace Senko.Flurl.Tests.Extensions;

public class FlurlRequestExtensionsTests {
    private readonly IFlurlRequest _flurlRequest = Substitute.For<IFlurlRequest>();
    private readonly FlurlHttpSettings _settings = new();

    public FlurlRequestExtensionsTests() {
        _flurlRequest.Settings.Returns(_settings);
    }

    [Fact]
    public void UsingSystemJson_Should_ChangeSerializerToSystemJson() {
        var result = _flurlRequest.UsingSystemJson();

        result.Should().Be(_flurlRequest);
        _flurlRequest.Settings.JsonSerializer.Should().BeOfType<SystemJsonSerializer>();
    }
    
    [Fact]
    public void UsingSystemJson_CustomOptions_Should_ChangeSerializerToSystemJson() {
        var result = _flurlRequest.UsingSystemJson();

        result.Should().Be(_flurlRequest);
        _flurlRequest.Settings.JsonSerializer.Should().BeOfType<SystemJsonSerializer>();
    }

    [Fact]
    public void DontThrowOnError_Should_SetAllowedHttpRange() {
        var result = _flurlRequest.DontThrowOnError();

        result.Should().Be(_flurlRequest);
        _flurlRequest.Settings.AllowedHttpStatusRange.Should().Be("*");
    }
}
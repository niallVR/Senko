using FluentAssertions;
using Flurl.Http;
using NiallVR.Senko.Flurl.Extensions;
using NSubstitute;
using Xunit;

namespace Senko.Flurl.Tests.Extensions; 

public class FlurlResponseExtensionsTests {
    [Theory]
    [InlineData(0, 199, false)]
    [InlineData(200, 299, true)]
    [InlineData(300, 1000, false)]
    public void WasSuccessful_Should_ReturnExpected(int startingCode, int endingCode, bool shouldReturn) {
        for (var i = startingCode; i < endingCode + 1; i++) {
            var response = Substitute.For<IFlurlResponse>();
            response.StatusCode.Returns(i);
            
            response.WasSuccessful().Should().Be(shouldReturn);
        }
    }
}
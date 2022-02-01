using System.IO;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using NiallVR.Senko.Extensions.BuiltIn;
using Xunit;

namespace Senko.Extensions.Tests.BuiltIn; 

public class SystemJsonExtensionsTests {
    private record MockModel(string Value);
    private readonly JsonSerializerOptions _options = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    [Fact]
    public void Serialize_Should_SerializeType() {
        var model = new MockModel("Test");
        
        var result = model.Serialize(_options);

        result.Should().Be("{\"value\":\"Test\"}");
    }
    
    [Fact]
    public void Deserialize_String_Should_DeserializeMessage() {
        const string testString = "{\"value\":\"Test\"}";
        
        var result = testString.Deserialize<MockModel>(_options);

        result.Should().NotBeNull();
        result!.Value.Should().Be("Test");
    }
    
    [Fact]
    public void Deserialize_Stream_Should_DeserializeMessage() {
        var testStream = new MemoryStream(Encoding.Default.GetBytes("{\"value\":\"Test\"}"));
        
        var result = testStream.Deserialize<MockModel>(_options);

        result.Should().NotBeNull();
        result!.Value.Should().Be("Test");
    }  
}
using System.Collections.Generic;
using FluentAssertions;
using NiallVR.Senko.Extensions.Collections;
using Xunit;

namespace Senko.Extensions.Tests.Collections; 

public class DictionaryExtensionsTests {
    private readonly Dictionary<int, int> _systemUnderTest = new();
    
    [Fact]
    public void AddAndGet_NonFunc_Should_StoreAndReturnValue_When_KeyDoesntExist() {
        var result = _systemUnderTest.AddAndGet(10, 10);

        _systemUnderTest.Should().ContainKey(10);
        _systemUnderTest[10].Should().Be(10);
        result.Should().Be(10);
    }
    
    [Fact]
    public void AddAndGet_NonFunc_Should_ReturnStoredValue_When_KeyExists() {
        var result = _systemUnderTest[10] = 20;
        
        _systemUnderTest.AddAndGet(10, 10);

        _systemUnderTest.Should().ContainKey(10);
        _systemUnderTest[10].Should().Be(20);
        result.Should().Be(20);
    }
    
    [Fact]
    public void AddAndGet_Func_Should_StoreAndReturnValue_When_KeyDoesntExist() {
        var result = _systemUnderTest.AddAndGet(10, () => 10);

        _systemUnderTest.Should().ContainKey(10);
        _systemUnderTest[10].Should().Be(10);
        result.Should().Be(10);
    }
    
    [Fact]
    public void AddAndGet_Func_Should_ReturnStoredValue_When_KeyExists() {
        var result = _systemUnderTest[10] = 20;
        
        _systemUnderTest.AddAndGet(10, () => 10);

        _systemUnderTest.Should().ContainKey(10);
        _systemUnderTest[10].Should().Be(20);
        result.Should().Be(20);
    }
}
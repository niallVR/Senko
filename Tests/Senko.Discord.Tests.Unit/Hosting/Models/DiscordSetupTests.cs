using System;
using System.Collections.Generic;
using System.Linq;
using Discord.Interactions;
using FluentAssertions;
using NiallVR.Senko.Discord.Hosting.Models;
using Xunit;

namespace Senko.Discord.Tests.Unit.Hosting.Models; 

public class DiscordSetupTests {
    public class MockModule : InteractionModuleBase {}
    private readonly DiscordSetup _systemUnderTest = new();

    [Fact]
    public void AddGlobalInteractionModule_Should_AddTypeToInternalCollection() {
        // Act
        _systemUnderTest.AddGlobalInteractionModule<MockModule>();
        
        // Assert
        _systemUnderTest.GlobalInteractionModules.Should().HaveCount(1);
        _systemUnderTest.GlobalInteractionModules.Should().Contain(typeof(MockModule));
    }
    
    [Fact]
    public void AddGuildInteractionModule_Should_AddTypeToInternalCollection() {
        // Act
        _systemUnderTest.AddGuildInteractionModule<MockModule>();
        
        // Assert
        _systemUnderTest.GlobalGuildInteractionModules.Should().HaveCount(1);
        _systemUnderTest.GlobalGuildInteractionModules.Should().Contain(typeof(MockModule));
    }
    
    [Fact]
    public void AddTargetedGuildInteractionModule_Should_CreateEntryAndAddTypeToDictionary_When_GuildDoesntExist() {
        // Act
        _systemUnderTest.AddTargetedGuildInteractionModule<MockModule>(100);
        
        // Assert
        _systemUnderTest.GuildInteractionModules.Should().HaveCount(1);
        _systemUnderTest.GuildInteractionModules[100].Should().HaveCount(1);
        _systemUnderTest.GuildInteractionModules[100].Should().Contain(typeof(MockModule));
    }
    
    [Fact]
    public void AddTargetedGuildInteractionModule_Should_AddTypeToDictionary_When_GuildExists() {
        // Arrange
        _systemUnderTest.GuildInteractionModules[100] = new List<Type> { typeof(MockModule) };
        
        // Act
        _systemUnderTest.AddTargetedGuildInteractionModule<MockModule>(100);
        
        // Assert
        _systemUnderTest.GuildInteractionModules.Should().HaveCount(1);
        _systemUnderTest.GuildInteractionModules[100].Should().HaveCount(2);
        _systemUnderTest.GuildInteractionModules[100].All(m => m == typeof(MockModule)).Should().BeTrue();
    }
}
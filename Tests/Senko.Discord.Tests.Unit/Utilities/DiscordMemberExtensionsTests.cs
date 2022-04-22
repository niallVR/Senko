using Discord;
using FluentAssertions;
using NiallVR.Senko.Discord.Utilities.Extensions;
using NSubstitute;
using Xunit;

namespace Senko.Discord.Tests.Unit.Utilities; 

public class DiscordMemberExtensionsTests {

    [Fact]
    public void GetDisplayName_Should_ReturnNickname_When_UserHasNicknameSet() {
        // Arrange
        var guildUser = Substitute.For<IGuildUser>();
        guildUser.Nickname.Returns("HelloWorld");
        guildUser.Username.Returns("Error");
        guildUser.Discriminator.Returns("Error");

        // Act
        var result = guildUser.GetDisplayName();

        // Assert
        result.Should().Be("HelloWorld");
    }
    
    
    [Fact]
    public void GetDisplayName_Should_ReturnUsernameAndDiscriminator_When_UserHasNoNicknameSet() {
        // Arrange
        var guildUser = Substitute.For<IGuildUser>();
        guildUser.Nickname.Returns((string?) null);
        guildUser.Username.Returns("Hello");
        guildUser.Discriminator.Returns("World");

        // Act
        var result = guildUser.GetDisplayName();

        // Assert
        result.Should().Be("Hello#World");
    }

    [Fact]
    public void GetVoiceChannel_Should_ReturnNull_When_UserNotInVoiceChannel() {
        // Arrange
        var user = Substitute.For<IUser, IVoiceState>();
        ((IVoiceState) user).VoiceChannel.Returns((IVoiceChannel?) null);

        // Act
        var result = user.GetVoiceChannel();

        // Assert
        result.Should().BeNull();
    }
    
    [Fact]
    public void GetVoiceChannel_Should_ReturnVoiceChannel_When_UserInVoiceChannel() {
        // Arrange
        var voiceChannel = Substitute.For<IVoiceChannel>();
        var user = Substitute.For<IUser, IVoiceState>();
        ((IVoiceState) user).VoiceChannel.Returns(voiceChannel);

        // Act
        var result = user.GetVoiceChannel();

        // Assert
        result.Should().Be(voiceChannel);
    }

    [Fact]
    public void GetAvatarUrlOrDefault_Should_ReturnDefaultUrl_When_UserHasNoAvatarSet() {
        // Arrange
        var user = Substitute.For<IUser>();
        user.GetAvatarUrl(Arg.Any<ImageFormat>(), Arg.Any<ushort>()).Returns((string?) null);
        user.GetDefaultAvatarUrl().Returns("Default");

        // Act
        var result = user.GetAvatarUrlOrDefault();

        // Assert
        result.Should().Be("Default");
    }
    
    [Fact]
    public void GetAvatarUrlOrDefault_Should_ReturnCustomUrl_When_UserHasAvatarSet() {
        // Arrange
        var user = Substitute.For<IUser>();
        user.GetAvatarUrl(Arg.Any<ImageFormat>(), Arg.Any<ushort>()).Returns("Custom");
        user.GetDefaultAvatarUrl().Returns("Default");

        // Act
        var result = user.GetAvatarUrlOrDefault();

        // Assert
        result.Should().Be("Custom");
    }
}
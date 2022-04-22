using Discord;

namespace NiallVR.Senko.Discord.Utilities.Extensions; 

public static class DiscordMemberExtensions {
    /// <summary>
    /// Returns the current display name of the member.
    /// </summary>
    /// <param name="member">The member to get the display name of.</param>
    /// <returns>Either their nickname or username and discriminator.</returns>
    public static string GetDisplayName(this IGuildUser member) {
        return member.Nickname ?? $"{member.Username}#{member.Discriminator}";
    }
    
    /// <summary>
    /// Returns the users current voice channel.
    /// </summary>
    /// <param name="user">The target user.</param>
    /// <returns>The voice channel the member is in or null if they're not in one</returns>
    /// <remarks>
    /// This only works on guild users!
    /// As most methods return an IUser, this is a small shortcut to save a cast.
    /// </remarks>
    public static IVoiceChannel? GetVoiceChannel(this IUser user) {
        var voiceState = user as IVoiceState;
        return voiceState?.VoiceChannel;
    }

    /// <summary>
    /// Returns the users current avatar, or the default one if they don't have one set.
    /// </summary>
    /// <param name="user">The user to get the avatar of.</param>
    /// <param name="format">The desired format of the avatar.</param>
    /// <param name="size">The desired size of the avatar.</param>
    /// <returns></returns>
    public static string GetAvatarUrlOrDefault(this IUser user, ImageFormat format = ImageFormat.Auto, ushort size = 128) {
        return user.GetAvatarUrl(format, size) ?? user.GetDefaultAvatarUrl();
    }
}
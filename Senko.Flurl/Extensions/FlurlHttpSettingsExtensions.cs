using System.Text.Json;
using Flurl.Http.Configuration;
using NiallVR.Senko.Flurl.Entities;

namespace NiallVR.Senko.Flurl.Extensions;

public static class FlurlHttpSettingsExtensions {
    private static readonly SystemJsonSerializer Serializer = new();

    /// <summary>
    /// Changes the settings to use System.Json over Flurl's default provider.
    /// </summary>
    /// <param name="settings">The settings to edit.</param>
    /// <returns>The edited settings.</returns>
    public static FlurlHttpSettings UsingSystemJson(this FlurlHttpSettings settings) {
        settings.JsonSerializer = Serializer;
        return settings;
    }

    /// <summary>
    /// Changes the settings to use System.Json over Flurl's default provider.
    /// </summary>
    /// <param name="settings">The settings to edit.</param>
    /// <param name="options">The serializer options to use.</param>
    /// <returns>The edited settings.</returns>
    public static FlurlHttpSettings UsingSystemJson(this FlurlHttpSettings settings, JsonSerializerOptions options) {
        settings.JsonSerializer = new SystemJsonSerializer(options);
        return settings;
    }

    /// <summary>
    /// Changes the default behaviour to disable exception throwing when a server returns a non 200 code.
    /// </summary>
    /// <param name="settings">The settings to edit.</param>
    /// <returns>The edited settings.</returns>
    public static FlurlHttpSettings DontThrowOnError(this FlurlHttpSettings settings) {
        settings.AllowedHttpStatusRange = "*";
        return settings;
    }
}
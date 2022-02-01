using System.Text.Json;
using Flurl.Http;

namespace NiallVR.Senko.Flurl.Extensions;

public static class FlurlRequestExtensions {
    /// <summary>
    /// Changes the settings to use System.Json over Flurl's default provider.
    /// </summary>
    /// <param name="request">The request to edit.</param>
    /// <returns>The edited request.</returns>
    public static IFlurlRequest UsingSystemJson(this IFlurlRequest request) {
        request.Settings.UsingSystemJson();
        return request;
    }

    /// <summary>
    /// Changes the settings to use System.Json over Flurl's default provider.
    /// </summary>
    /// <param name="request">The request to edit.</param>
    /// <param name="options">The serializer options to use.</param>
    /// <returns>The edited request.</returns>
    public static IFlurlRequest UsingSystemJson(this IFlurlRequest request, JsonSerializerOptions options) {
        request.Settings.UsingSystemJson(options);
        return request;
    }

    /// <summary>
    /// Changes the default behaviour to disable exception throwing when a server returns a non 200 code.
    /// </summary>
    /// <param name="request">The request to edit.</param>
    /// <returns>The edited request.</returns>
    public static IFlurlRequest DontThrowOnError(this IFlurlRequest request) {
        request.Settings.DontThrowOnError();
        return request;
    }
}
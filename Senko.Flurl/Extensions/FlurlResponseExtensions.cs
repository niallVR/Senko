using Flurl.Http;
using NiallVR.Senko.Extensions.Primitives;

namespace NiallVR.Senko.Flurl.Extensions; 

public static class FlurlResponseExtensions {
    /// <summary>
    /// Returns true if the request was successful.
    /// </summary>
    /// <returns>True if the request was successful, false if not.</returns>
    public static bool WasSuccessful(this IFlurlResponse response) => response.StatusCode.IsInRange(200, 299, true);
}
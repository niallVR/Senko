namespace NiallVR.Senko.Hosting.Utils; 

public static class DockerDetection {
    /// <summary>
    /// Returns if the application is running in a container using the official dotnet image.
    /// </summary>
    /// <returns>True if the application is running in a container, false if not.</returns>
    /// <remarks>
    /// This requires DOTNET_RUNNING_IN_CONTAINER to be set to true.
    /// In official dotnet images, this is set to true for you.
    /// </remarks>
    public static bool IsInContainer() {
        var result = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
        return result is not null && result.Equals("true", StringComparison.InvariantCultureIgnoreCase);
    }
}
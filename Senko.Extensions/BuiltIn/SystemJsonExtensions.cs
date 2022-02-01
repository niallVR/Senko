using System.Text.Json;
using System.Text.Json.Serialization;

namespace NiallVR.Senko.Extensions.BuiltIn;

/// <summary>
/// Extensions for the <see cref="JsonSerializer"/> class.
/// </summary>
public static class SystemJsonExtensions {
    private static readonly JsonSerializerOptions? SerializerOptions = new() { Converters = {
        new JsonStringEnumConverter()
    }};

    /// <summary>
    /// Serializes the object to JSON.
    /// </summary>
    /// <param name="toSerialize">The object to serialize.</param>
    /// <param name="options">The serializer options.</param>
    /// <typeparam name="T">The type of object to serialize.</typeparam>
    /// <returns>The JSON string.</returns>
    public static string Serialize<T>(this T toSerialize, JsonSerializerOptions? options = null) {
        return JsonSerializer.Serialize(toSerialize, options ?? SerializerOptions);
    }

    /// <summary>
    /// Deserialize a JSON string to an object.
    /// </summary>
    /// <param name="toDeserialize">The string to deserialize.</param>
    /// <param name="options">The serializer options.</param>
    /// <typeparam name="T">The type to deserialize to.</typeparam>
    /// <returns>The deserialized object.</returns>
    public static T? Deserialize<T>(this string toDeserialize, JsonSerializerOptions? options = null) {
        return JsonSerializer.Deserialize<T>(toDeserialize, options ?? SerializerOptions);
    }
    
    /// <summary>
    /// Deserialize a JSON stream to an object.
    /// </summary>
    /// <param name="toDeserialize">The stream to deserialize.</param>
    /// <param name="options">The serializer options.</param>
    /// <typeparam name="T">The type to deserialize to.</typeparam>
    /// <returns>The deserialized object.</returns>
    public static T? Deserialize<T>(this Stream toDeserialize, JsonSerializerOptions? options = null) {
        return JsonSerializer.Deserialize<T>(toDeserialize, options ?? SerializerOptions);
    }
}
using System.Text.Json;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations;

/// <summary>
/// An implementation of <see cref="ISystemJson"/> using <see cref="JsonSerializer"/>.
/// </summary>
public class SystemJsonProvider : ISystemJson
{
    /// <inheritdoc cref="ISystemJson.Deserialize{T}(Stream, JsonSerializerOptions?)"/>
    public TValue? Deserialize<TValue>(Stream utf8Json, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<TValue>(utf8Json, options);
    }

    /// <inheritdoc cref="ISystemJson.Deserialize{T}(string, JsonSerializerOptions?)"/>
    public TValue? Deserialize<TValue>(string json, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<TValue>(json, options);
    }

    /// <inheritdoc cref="ISystemJson.DeserializeAsync{T}(Stream, JsonSerializerOptions?, CancellationToken)"/>
    public ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.DeserializeAsync<TValue>(utf8Json, options, cancellationToken);
    }

    /// <inheritdoc cref="ISystemJson.Serialize(Stream, object?, Type, JsonSerializerOptions?)"/>
    public void Serialize(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null)
    {
        JsonSerializer.Serialize(utf8Json, value, inputType, options);
    }

    /// <inheritdoc cref="ISystemJson.Serialize(object?, Type, JsonSerializerOptions?)"/>
    public string Serialize(object? value, Type inputType, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, inputType, options);
    }

    /// <inheritdoc cref="ISystemJson.Serialize{T}(Stream, T, JsonSerializerOptions?)"/>
    public void Serialize<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null)
    {
        JsonSerializer.Serialize(utf8Json, value, options);
    }

    /// <inheritdoc cref="ISystemJson.Serialize{T}(Utf8JsonWriter, T, JsonSerializerOptions?)"/>
    public void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null)
    {
        JsonSerializer.Serialize(writer, value, options);
    }

    /// <inheritdoc cref="ISystemJson.Serialize{T}(T, JsonSerializerOptions?)"/>
    public string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(value, options);
    }

    /// <inheritdoc cref="ISystemJson.SerializeAsync(Stream, object?, Type, JsonSerializerOptions?, CancellationToken)"/>
    public Task SerializeAsync(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.SerializeAsync(utf8Json, value, inputType, options, cancellationToken);
    }

    /// <inheritdoc cref="ISystemJson.SerializeAsync{T}(Stream, T, JsonSerializerOptions?, CancellationToken)"/>
    public Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.SerializeAsync(utf8Json, value, options, cancellationToken);
    }
}
using System.Text.Json;

namespace NiallVR.Senko.Core.Providers.Interfaces; 

public interface ISystemJson {
    /// <inheritdoc cref="JsonSerializer.Deserialize{TValue}(Stream, JsonSerializerOptions?)"/>
    TValue? Deserialize<TValue>(Stream utf8Json, JsonSerializerOptions? options = null);
    
    /// <inheritdoc cref="JsonSerializer.Deserialize{TValue}(string, JsonSerializerOptions?)"/>
    TValue? Deserialize<TValue>(string json, JsonSerializerOptions? options = null);

    /// <inheritdoc cref="JsonSerializer.DeserializeAsync{TValue}(Stream, JsonSerializerOptions?, CancellationToken)"/>
    ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="JsonSerializer.Serialize(Stream, object?, Type, JsonSerializerOptions?)"/>
    void Serialize(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null);

    /// <inheritdoc cref="JsonSerializer.Serialize(object?, Type, JsonSerializerOptions?)"/>
    string Serialize(object? value, Type inputType, JsonSerializerOptions? options = null);

    /// <inheritdoc cref="JsonSerializer.Serialize{TValue}(Stream, TValue, JsonSerializerOptions?)"/>
    void Serialize<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null);
    
    /// <inheritdoc cref="JsonSerializer.Serialize{TValue}(Utf8JsonWriter, TValue, JsonSerializerOptions?)"/>
    void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null);
    
    /// <inheritdoc cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions?)"/>
    string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null);

    /// <inheritdoc cref="JsonSerializer.SerializeAsync(Stream, object?, Type, JsonSerializerOptions?, CancellationToken)"/>
    Task SerializeAsync(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);
    
    /// <inheritdoc cref="JsonSerializer.SerializeAsync{TValue}(Stream, TValue, JsonSerializerOptions?, CancellationToken)"/>
    Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default);
}
using System.Text.Json;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations;

public class SystemJsonProvider : ISystemJson {
    public TValue? Deserialize<TValue>(Stream utf8Json, JsonSerializerOptions? options = null) {
        return JsonSerializer.Deserialize<TValue>(utf8Json, options);
    }

    public TValue? Deserialize<TValue>(string json, JsonSerializerOptions? options = null) {
        return JsonSerializer.Deserialize<TValue>(json, options);
    }

    public ValueTask<TValue?> DeserializeAsync<TValue>(Stream utf8Json, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default) {
        return JsonSerializer.DeserializeAsync<TValue>(utf8Json, options, cancellationToken);
    }

    public void Serialize(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null) {
        JsonSerializer.Serialize(utf8Json, value, inputType, options);
    }

    public string Serialize(object? value, Type inputType, JsonSerializerOptions? options = null) {
        return JsonSerializer.Serialize(value, inputType, options);
    }

    public void Serialize<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null) {
        JsonSerializer.Serialize(utf8Json, value, options);
    }

    public void Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null) {
        JsonSerializer.Serialize(writer, value, options);
    }

    public string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null) {
        return JsonSerializer.Serialize(value, options);
    }

    public Task SerializeAsync(Stream utf8Json, object? value, Type inputType, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default) {
        return JsonSerializer.SerializeAsync(utf8Json, value, inputType, options, cancellationToken);
    }

    public Task SerializeAsync<TValue>(Stream utf8Json, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default) {
        return JsonSerializer.SerializeAsync(utf8Json, value, options, cancellationToken);
    }
}
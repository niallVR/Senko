using System.Text.Json;
using Flurl.Http.Configuration;
using NiallVR.Senko.Extensions.BuiltIn;

namespace NiallVR.Senko.Flurl.Entities;

/// <summary>
/// Wrapper class to use System.Text.Json with Flurl.
/// </summary>
/// <source>https://github.com/tmenier/Flurl/issues/517#issuecomment-821541278</source>
internal class SystemJsonSerializer : ISerializer {
    private readonly JsonSerializerOptions? _options;

    public SystemJsonSerializer(JsonSerializerOptions? options = null) {
        _options = options;
    }

    public T Deserialize<T>(string s) => s.Deserialize<T>(_options)!;
    public T Deserialize<T>(Stream stream) => stream.Deserialize<T>(_options)!;
    public string Serialize(object obj) => obj.Serialize(_options);
}
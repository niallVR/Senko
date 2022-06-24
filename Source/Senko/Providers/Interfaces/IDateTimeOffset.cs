using System.Globalization;

namespace NiallVR.Senko.Providers.Interfaces; 

/// <summary>
/// A testable wrapper around <see cref="IDateTimeOffset"/>.
/// </summary>
public interface IDateTimeOffset {
    /// <inheritdoc cref="DateTimeOffset.Now"/>
    DateTimeOffset Now { get; }
    
    /// <inheritdoc cref="DateTimeOffset.UtcNow"/>
    DateTimeOffset UtcNow { get; }
    
    /// <inheritdoc cref="DateTimeOffset.MaxValue"/>
    DateTimeOffset MaxValue { get; }
    
    /// <inheritdoc cref="DateTimeOffset.MinValue"/>
    DateTimeOffset MinValue { get; }
    
    /// <inheritdoc cref="DateTimeOffset.UnixEpoch"/>
    DateTimeOffset UnixEpoch { get; }

    /// <inheritdoc cref="DateTimeOffset.TryParse(string?, out DateTimeOffset)"/>
    bool TryParse(string? input, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParse(ReadOnlySpan{char}, out DateTimeOffset)"/>
    bool TryParse(ReadOnlySpan<char> input, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParse(string?, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParse(string? input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParse(ReadOnlySpan<char> input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParseExact(string?, string?, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParseExact(string? input, string? format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParseExact(string?, string?[], IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParseExact(string? input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);
    
    /// <inheritdoc cref="DateTimeOffset.TryParseExact(ReadOnlySpan{char}, string?[], IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    bool TryParseExact(ReadOnlySpan<char> input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result);

    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeSeconds"/>
    DateTimeOffset FromUnixTimeSeconds(long seconds);
    
    /// <inheritdoc cref="DateTimeOffset.FromUnixTimeMilliseconds"/>
    DateTimeOffset FromUnixTimeMilliseconds(long seconds);
}
using System.Globalization;

namespace NiallVR.Senko.Providers.Interfaces;

/// <summary>
/// A testable wrapper around <see cref="ITimeOnly"/>.
/// </summary>
public interface ITimeOnly
{
    /// <inheritdoc cref="TimeOnly.MaxValue"/>
    TimeOnly MaxValue { get; }

    /// <inheritdoc cref="TimeOnly.MinValue"/>
    TimeOnly MinValue { get; }

    /// <inheritdoc cref="TimeOnly.Parse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles)"/>
    TimeOnly Parse(ReadOnlySpan<char> s, IFormatProvider? provider = default,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.Parse(string)"/>
    TimeOnly Parse(string s);

    /// <inheritdoc cref="TimeOnly.Parse(string, IFormatProvider?, DateTimeStyles)"/>
    TimeOnly Parse(string s, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.ParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles)"/>
    TimeOnly ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider = default,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.ParseExact(ReadOnlySpan{char}, string[])"/>
    TimeOnly ParseExact(ReadOnlySpan<char> s, string[] formats);

    /// <inheritdoc cref="TimeOnly.ParseExact(ReadOnlySpan{char}, string[], IFormatProvider?, DateTimeStyles)"/>
    TimeOnly ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.ParseExact(string, string)"/>
    TimeOnly ParseExact(string s, string format);

    /// <inheritdoc cref="TimeOnly.ParseExact(string, string, IFormatProvider?, DateTimeStyles)"/>
    TimeOnly ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.ParseExact(string, string[])"/>
    TimeOnly ParseExact(string s, string[] formats);

    /// <inheritdoc cref="TimeOnly.ParseExact(string, string[], IFormatProvider?, DateTimeStyles)"/>
    TimeOnly ParseExact(string s, string[] formats, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="TimeOnly.TryParse(ReadOnlySpan{char}, out TimeOnly)"/>
    bool TryParse(ReadOnlySpan<char> s, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParse(string?, out TimeOnly)"/>
    bool TryParse(string? s, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParse(string?, IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.FromDateTime(DateTime)"/>
    TimeOnly FromDateTime(DateTime dateTime);

    /// <inheritdoc cref="TimeOnly.FromTimeSpan(TimeSpan)"/>
    TimeOnly FromTimeSpan(TimeSpan timeSpan);

    /// <inheritdoc cref="TimeOnly.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, out TimeOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style,
        out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(ReadOnlySpan{char}, string?[], out TimeOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(ReadOnlySpan{char}, string?[], IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(string?, string?, out TimeOnly)"/>
    bool TryParseExact(string? s, string? format, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(string?, string?, IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(string?, string?[], out TimeOnly)"/>
    bool TryParseExact(string? s, string?[]? formats, out TimeOnly result);

    /// <inheritdoc cref="TimeOnly.TryParseExact(string?, string?[], IFormatProvider?, DateTimeStyles, out TimeOnly)"/>
    bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out TimeOnly result);
}
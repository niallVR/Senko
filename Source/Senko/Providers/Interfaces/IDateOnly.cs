using System.Globalization;

namespace NiallVR.Senko.Providers.Interfaces;

/// <summary>
/// A testable wrapper around <see cref="DateOnly"/>.
/// </summary>
public interface IDateOnly
{
    /// <inheritdoc cref="DateOnly.MaxValue"/>
    DateOnly MaxValue { get; }

    /// <inheritdoc cref="DateOnly.MinValue"/>
    DateOnly MinValue { get; }

    /// <inheritdoc cref="DateOnly.Parse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles"/>
    DateOnly Parse(ReadOnlySpan<char> s, IFormatProvider? provider = default,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.Parse(string)"/>
    DateOnly Parse(string s);

    /// <inheritdoc cref="DateOnly.Parse(string, IFormatProvider?, DateTimeStyles)"/>
    DateOnly Parse(string s, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.ParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles)"/>
    DateOnly ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider = default,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.ParseExact(ReadOnlySpan{char}, string[])"/>
    DateOnly ParseExact(ReadOnlySpan<char> s, string[] formats);

    /// <inheritdoc cref="DateOnly.ParseExact(ReadOnlySpan{char}, string[], IFormatProvider?, DateTimeStyles)"/>
    DateOnly ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.ParseExact(string, string)"/>
    DateOnly ParseExact(string s, string format);

    /// <inheritdoc cref="DateOnly.ParseExact(string, string, IFormatProvider?, DateTimeStyles)"/>
    DateOnly ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.ParseExact(string, string[])"/>
    DateOnly ParseExact(string s, string[] formats);

    /// <inheritdoc cref="DateOnly.ParseExact(string, string[], IFormatProvider?, DateTimeStyles)"/>
    DateOnly ParseExact(string s, string[] formats, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None);

    /// <inheritdoc cref="DateOnly.TryParse(ReadOnlySpan{char}, out DateOnly)"/>
    bool TryParse(ReadOnlySpan<char> s, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles style, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParse(string?, out DateOnly)"/>
    bool TryParse(string? s, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParse(string?, IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles style, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, out DateOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style,
        out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(ReadOnlySpan{char}, string?[], out DateOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(ReadOnlySpan{char}, string?[], IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(string?, string?, out DateOnly)"/>
    bool TryParseExact(string? s, string? format, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(string?, string?, IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(string?, string?[], out DateOnly)"/>
    bool TryParseExact(string? s, string?[]? formats, out DateOnly result);

    /// <inheritdoc cref="DateOnly.TryParseExact(string?, string?[], IFormatProvider?, DateTimeStyles, out DateOnly)"/>
    bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out DateOnly result);
}
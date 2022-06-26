using System.Globalization;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations;

/// <summary>
/// An implementation of <see cref="IDateTimeOffset"/> using <see cref="System.DateTimeOffset"/>.
/// </summary>
public class DateTimeOffsetProvider : IDateTimeOffset
{
    /// <inheritdoc cref="IDateTimeOffset.Now"/>
    public DateTimeOffset Now => DateTimeOffset.Now;
    
    /// <inheritdoc cref="IDateTimeOffset.UtcNow"/>
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    
    /// <inheritdoc cref="IDateTimeOffset.MaxValue"/>
    public DateTimeOffset MaxValue => DateTimeOffset.MaxValue;
    
    /// <inheritdoc cref="IDateTimeOffset.MinValue"/>
    public DateTimeOffset MinValue => DateTimeOffset.MinValue;
    
    /// <inheritdoc cref="IDateTimeOffset.UnixEpoch"/>
    public DateTimeOffset UnixEpoch => DateTimeOffset.UnixEpoch;

    /// <inheritdoc cref="IDateTimeOffset.TryParse(string?, out DateTimeOffset)"/>
    public bool TryParse(string? input, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParse(input, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParse(ReadOnlySpan{char}, out DateTimeOffset)"/>
    public bool TryParse(ReadOnlySpan<char> input, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParse(input, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParse(string?, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParse(string? input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParse(input, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParse(ReadOnlySpan<char> input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParse(input, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParseExact(string?, string?, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParseExact(string? input, string? format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParseExact(input, format, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParseExact(input, format, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParseExact(string?, string?[], IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParseExact(string? input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParseExact(input, formats, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.TryParseExact(ReadOnlySpan{char}, string?[], IFormatProvider?, DateTimeStyles, out DateTimeOffset)"/>
    public bool TryParseExact(ReadOnlySpan<char> input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result)
    {
        return DateTimeOffset.TryParseExact(input, formats, formatProvider, styles, out result);
    }

    /// <inheritdoc cref="IDateTimeOffset.FromUnixTimeSeconds(long)"/>
    public DateTimeOffset FromUnixTimeSeconds(long seconds)
    {
        return DateTimeOffset.FromUnixTimeSeconds(seconds);
    }

    /// <inheritdoc cref="IDateTimeOffset.FromUnixTimeMilliseconds(long)"/>
    public DateTimeOffset FromUnixTimeMilliseconds(long seconds)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(seconds);
    }
}
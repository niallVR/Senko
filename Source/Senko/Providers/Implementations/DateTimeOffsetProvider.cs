using System.Globalization;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations; 

/// <summary>
/// An implementation of <see cref="IDateTimeOffset"/> using <see cref="System.DateTimeOffset"/>.
/// </summary>
public class DateTimeOffsetProvider : IDateTimeOffset {
    public DateTimeOffset Now => DateTimeOffset.Now;
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    public DateTimeOffset MaxValue => DateTimeOffset.MaxValue;
    public DateTimeOffset MinValue => DateTimeOffset.MinValue;
    public DateTimeOffset UnixEpoch => DateTimeOffset.UnixEpoch;

    public bool TryParse(string? input, out DateTimeOffset result) {
        return DateTimeOffset.TryParse(input, out result);
    }

    public bool TryParse(ReadOnlySpan<char> input, out DateTimeOffset result) {
        return DateTimeOffset.TryParse(input, out result);
    }

    public bool TryParse(string? input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParse(input, formatProvider, styles, out result);
    }

    public bool TryParse(ReadOnlySpan<char> input, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParse(input, formatProvider, styles, out result);
    }

    public bool TryParseExact(string? input, string? format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParseExact(input, format, formatProvider, styles, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> input, ReadOnlySpan<char> format, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParseExact(input, format, formatProvider, styles, out result);
    }

    public bool TryParseExact(string? input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParseExact(input, formats, formatProvider, styles, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> input, string?[]? formats, IFormatProvider? formatProvider, DateTimeStyles styles, out DateTimeOffset result) {
        return DateTimeOffset.TryParseExact(input, formats, formatProvider, styles, out result);
    }

    public DateTimeOffset FromUnixTimeSeconds(long seconds) {
        return DateTimeOffset.FromUnixTimeSeconds(seconds);
    }

    public DateTimeOffset FromUnixTimeMilliseconds(long seconds) {
        return DateTimeOffset.FromUnixTimeMilliseconds(seconds);
    }
}
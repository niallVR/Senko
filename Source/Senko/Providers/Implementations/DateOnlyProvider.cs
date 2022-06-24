using System.Globalization;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations; 

/// <summary>
/// An implementation of <see cref="IDateOnly"/> using <see cref="System.DateOnly"/>.
/// </summary>
public class DateOnlyProvider : IDateOnly {
    public DateOnly MaxValue => DateOnly.MaxValue;
    public DateOnly MinValue => DateOnly.MinValue;
    
    public DateOnly Parse(ReadOnlySpan<char> s, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.Parse(s, provider, style);
    }

    public DateOnly Parse(string s) {
        return DateOnly.Parse(s);
    }

    public DateOnly Parse(string s, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.Parse(s, provider, style);
    }

    public DateOnly ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.ParseExact(s, format, provider, style);
    }

    public DateOnly ParseExact(ReadOnlySpan<char> s, string[] formats) {
        return DateOnly.ParseExact(s, formats);
    }

    public DateOnly ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.ParseExact(s, formats, provider, style);
    }

    public DateOnly ParseExact(string s, string format) {
        return DateOnly.ParseExact(s, format);
    }

    public DateOnly ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.ParseExact(s, format, provider, style);
    }

    public DateOnly ParseExact(string s, string[] formats) {
        return DateOnly.ParseExact(s, formats);
    }

    public DateOnly ParseExact(string s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return DateOnly.ParseExact(s, formats, provider, style);
    }

    public bool TryParse(ReadOnlySpan<char> s, out DateOnly result) {
        return DateOnly.TryParse(s, out result);
    }

    public bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParse(s, provider, style, out result);
    }

    public bool TryParse(string? s, out DateOnly result) {
        return DateOnly.TryParse(s, out result);
    }

    public bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParse(s, provider, style, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, out DateOnly result) {
        return DateOnly.TryParseExact(s, format, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, out DateOnly result) {
        return DateOnly.TryParseExact(s, formats, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParseExact(s, formats, provider, style, out result);
    }

    public bool TryParseExact(string? s, string? format, out DateOnly result) {
        return DateOnly.TryParseExact(s, format, out result);
    }

    public bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(string? s, string?[]? formats, out DateOnly result) {
        return DateOnly.TryParseExact(s, formats, out result);
    }

    public bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out DateOnly result) {
        return DateOnly.TryParseExact(s, formats, provider, style, out result);
    }
}
using System.Globalization;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations; 

/// <summary>
/// An implementation of <see cref="ITimeOnly"/> using <see cref="System.TimeOnly"/>.
/// </summary>
public class TimeOnlyProvider : ITimeOnly {
    public TimeOnly MaxValue => TimeOnly.MaxValue;
    public TimeOnly MinValue => TimeOnly.MinValue;

    public TimeOnly Parse(ReadOnlySpan<char> s, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.Parse(s, provider, style);
    }

    public TimeOnly Parse(string s) {
        return TimeOnly.Parse(s);
    }

    public TimeOnly Parse(string s, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.Parse(s, provider, style);
    }

    public TimeOnly ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider = default, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.ParseExact(s, format, provider, style);
    }

    public TimeOnly ParseExact(ReadOnlySpan<char> s, string[] formats) {
        return TimeOnly.ParseExact(s, formats);
    }

    public TimeOnly ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.ParseExact(s, formats, provider, style);
    }

    public TimeOnly ParseExact(string s, string format) {
        return TimeOnly.ParseExact(s, format);
    }

    public TimeOnly ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.ParseExact(s, format, provider, style);
    }

    public TimeOnly ParseExact(string s, string[] formats) {
        return TimeOnly.ParseExact(s, formats);
    }

    public TimeOnly ParseExact(string s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None) {
        return TimeOnly.ParseExact(s, formats, provider, style);
    }

    public bool TryParse(ReadOnlySpan<char> s, out TimeOnly result) {
        return TimeOnly.TryParse(s, out result);
    }

    public bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParse(s, provider, style, out result);
    }

    public bool TryParse(string? s, out TimeOnly result) {
        return TimeOnly.TryParse(s, out result);
    }

    public bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParse(s, provider, style, out result);
    }

    public TimeOnly FromDateTime(DateTime dateTime) {
        return TimeOnly.FromDateTime(dateTime);
    }

    public TimeOnly FromTimeSpan(TimeSpan timeSpan) {
        return TimeOnly.FromTimeSpan(timeSpan);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, format, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, formats, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, formats, provider, style, out result);
    }

    public bool TryParseExact(string? s, string? format, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, format, out result);
    }

    public bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(string? s, string?[]? formats, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, formats, out result);
    }

    public bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out TimeOnly result) {
        return TimeOnly.TryParseExact(s, formats, provider, style, out result);
    }
}
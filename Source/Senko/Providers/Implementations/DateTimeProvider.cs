using System.Globalization;
using NiallVR.Senko.Providers.Interfaces;

namespace NiallVR.Senko.Providers.Implementations;

/// <summary>
/// An implementation of <see cref="IDateTime"/> using <see cref="System.DateTime"/>.
/// </summary>
public class DateTimeProvider : IDateTime
{
    public DateTime Now => DateTime.Now;
    public DateTime Today => DateTime.Today;
    public DateTime MaxValue => DateTime.MaxValue;
    public DateTime MinValue => DateTime.MinValue;
    public DateTime UnixEpoch => DateTime.UnixEpoch;
    public DateTime UtcNow => DateTime.UtcNow;

    public DateTime Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null,
        DateTimeStyles styles = DateTimeStyles.None)
    {
        return DateTime.Parse(s, provider, styles);
    }

    public DateTime Parse(string s)
    {
        return DateTime.Parse(s);
    }

    public DateTime Parse(string s, IFormatProvider? provider)
    {
        return DateTime.Parse(s, provider);
    }

    public DateTime Parse(string s, IFormatProvider? provider, DateTimeStyles styles)
    {
        return DateTime.Parse(s, provider, styles);
    }

    public DateTime FromBinary(long dateData)
    {
        return DateTime.FromBinary(dateData);
    }

    public DateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, format, provider, style);
    }

    public DateTime ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider,
        DateTimeStyles style = DateTimeStyles.None)
    {
        return DateTime.ParseExact(s, formats, provider, style);
    }

    public DateTime ParseExact(string s, string format, IFormatProvider? provider)
    {
        return DateTime.ParseExact(s, format, provider);
    }

    public DateTime ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style)
    {
        return DateTime.ParseExact(s, format, provider, style);
    }

    public DateTime ParseExact(string s, string[] formats, IFormatProvider? provider, DateTimeStyles style)
    {
        return DateTime.ParseExact(s, formats, provider, style);
    }

    public DateTime SpecifyKind(DateTime value, DateTimeKind kind)
    {
        return DateTime.SpecifyKind(value, kind);
    }

    public bool TryParse(ReadOnlySpan<char> s, out DateTime result)
    {
        return DateTime.TryParse(s, out result);
    }

    public bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles styles, out DateTime result)
    {
        return DateTime.TryParse(s, provider, styles, out result);
    }

    public bool TryParse(string? s, out DateTime result)
    {
        return DateTime.TryParse(s, out result);
    }

    public bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles styles, out DateTime result)
    {
        return DateTime.TryParse(s, provider, styles, out result);
    }

    public int DaysInMonth(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }

    public DateTime FromFileTime(long fileTime)
    {
        return DateTime.FromFileTime(fileTime);
    }

    public bool IsLeapYear(int year)
    {
        return DateTime.IsLeapYear(year);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider,
        DateTimeStyles style, out DateTime result)
    {
        return DateTime.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out DateTime result)
    {
        return DateTime.TryParseExact(s, formats, provider, style, out result);
    }

    public bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style,
        out DateTime result)
    {
        return DateTime.TryParseExact(s, format, provider, style, out result);
    }

    public bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style,
        out DateTime result)
    {
        return DateTime.TryParseExact(s, formats, provider, style, out result);
    }

    public DateTime FromFileTimeUtc(long fileTime)
    {
        return DateTime.FromFileTimeUtc(fileTime);
    }

    public DateTime FromOADate(double d)
    {
        return DateTime.FromOADate(d);
    }
}
using System.Globalization;

namespace NiallVR.Senko.Providers.Interfaces; 

/// <summary>
/// A testable wrapper around <see cref="IDateTime"/>.
/// </summary>
public interface IDateTime {
    /// <inheritdoc cref="DateTime.Now"/>
    DateTime Now { get; }
    
    /// <inheritdoc cref="DateTime.Today"/>
    DateTime Today { get; }
    
    /// <inheritdoc cref="DateTime.MaxValue"/>
    DateTime MaxValue { get; }
    
    /// <inheritdoc cref="DateTime.MinValue"/>
    DateTime MinValue { get; }
    
    /// <inheritdoc cref="DateTime.UnixEpoch"/>
    DateTime UnixEpoch { get; }
    
    /// <inheritdoc cref="DateTime.UtcNow"/>
    DateTime UtcNow { get; }

    /// <inheritdoc cref="DateTime.Parse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles)"/>
    DateTime Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null, DateTimeStyles styles = DateTimeStyles.None);
    
    /// <inheritdoc cref="DateTime.Parse(string)"/>
    DateTime Parse(string s);
    
    /// <inheritdoc cref="DateTime.Parse(string, IFormatProvider?)"/>
    DateTime Parse(string s, IFormatProvider? provider);
    
    /// <inheritdoc cref="DateTime.Parse(string, IFormatProvider?, DateTimeStyles)"/>
    DateTime Parse(string s, IFormatProvider? provider, DateTimeStyles styles);

    /// <inheritdoc cref="DateTime.FromBinary(long)"/>
    DateTime FromBinary(long dateData);

    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles)"/>
    DateTime ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);
    
    /// <inheritdoc cref="DateTime.ParseExact(ReadOnlySpan{char}, string[], IFormatProvider?, DateTimeStyles)"/>
    DateTime ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None);
    
    /// <inheritdoc cref="DateTime.ParseExact(string, string, IFormatProvider?)"/>
    DateTime ParseExact(string s, string format, IFormatProvider? provider);
    
    /// <inheritdoc cref="DateTime.ParseExact(string, string, IFormatProvider?, DateTimeStyles)"/>
    DateTime ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style);
    
    /// <inheritdoc cref="DateTime.ParseExact(string, string[], IFormatProvider?, DateTimeStyles)"/>
    DateTime ParseExact(string s, string[] formats, IFormatProvider? provider, DateTimeStyles style);

    /// <inheritdoc cref="DateTime.SpecifyKind(DateTime, DateTimeKind)"/>
    DateTime SpecifyKind(DateTime value, DateTimeKind kind);

    /// <inheritdoc cref="DateTime.TryParse(ReadOnlySpan{char}, out DateTime)"/>
    bool TryParse(ReadOnlySpan<char> s, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParse(ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles styles, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParse(string?, out DateTime)"/>
    bool TryParse(string? s, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParse(string?, IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParse(string? s, IFormatProvider? provider, DateTimeStyles styles, out DateTime result);

    /// <inheritdoc cref="DateTime.DaysInMonth(int, int)"/>
    int DaysInMonth(int year, int month);

    /// <inheritdoc cref="DateTime.FromFileTime(long)"/>
    DateTime FromFileTime(long fileTime);

    /// <inheritdoc cref="DateTime.IsLeapYear(int)"/>
    bool IsLeapYear(int year);

    /// <inheritdoc cref="DateTime.TryParseExact(ReadOnlySpan{char}, ReadOnlySpan{char}, IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParseExact(ReadOnlySpan{char}, string?[], IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParseExact(ReadOnlySpan<char> s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParseExact(string?, string?, IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParseExact(string? s, string? format, IFormatProvider? provider, DateTimeStyles style, out DateTime result);
    
    /// <inheritdoc cref="DateTime.TryParseExact(string?, string?[], IFormatProvider?, DateTimeStyles, out DateTime)"/>
    bool TryParseExact(string? s, string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out DateTime result);

    /// <inheritdoc cref="DateTime.FromFileTimeUtc(long)"/>
    DateTime FromFileTimeUtc(long fileTime);

    /// <inheritdoc cref="DateTime.FromOADate(double)"/>
    DateTime FromOADate(double d);
}
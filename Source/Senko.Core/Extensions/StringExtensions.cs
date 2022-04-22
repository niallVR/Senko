using System.Runtime.CompilerServices;

namespace NiallVR.Senko.Core.Extensions; 

/// <summary>
/// Extensions for the <see cref="string"/> class.
/// </summary>
public static class StringExtensions {
    /// <summary>
    /// Limits the string to the specified amount if it exceeds it.
    /// </summary>
    /// <param name="input">The string to limit.</param>
    /// <param name="maxLength">The max length the string can be.</param>
    /// <param name="wantEllipsis">True if the limited string should have an ellipsis.</param>
    /// <returns>The limited string.</returns>
    /// <remarks>If the length is 3 or less, no ellipsis will be added.</remarks>
    public static string LimitString(this string input, int maxLength, bool wantEllipsis = true) {
        if (input.Length <= maxLength)
            return input;

        if (wantEllipsis && maxLength > 3)
            return input[..(maxLength - 3)] + "...";

        return input[..maxLength];
    }

    /// <summary>
    /// Converts a string to a format used for string comparisons.
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>The converted string.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToSearchFormat(this string input) {
        return input.Trim().ToLower();
    }

    /// <summary>
    /// Checks if the first string equals the second string using <see cref="StringComparison.InvariantCultureIgnoreCase"/>.
    /// </summary>
    /// <returns>True if they match, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EqualsIgnoreCase(this string firstString, string secondString) {
        return firstString.Equals(secondString, StringComparison.InvariantCultureIgnoreCase);
    }
    
    /// <summary>
    /// Checks if the first string contains the characters of the second string using <see cref="StringComparison.InvariantCultureIgnoreCase"/>.
    /// </summary>
    /// <returns>True if they match, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsIgnoreCase(this string firstString, string secondString) {
        return firstString.Contains(secondString, StringComparison.InvariantCultureIgnoreCase);
    }
    
    /// <summary>
    /// Checks if the first string starts with the second string using <see cref="StringComparison.InvariantCultureIgnoreCase"/>.
    /// </summary>
    /// <returns>True if the first string starts with the second string, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool StartsWithIgnoreCase(this string firstString, string secondString) {
        return firstString.StartsWith(secondString, StringComparison.InvariantCultureIgnoreCase);
    }
    
    /// <summary>
    /// Checks if the first string ends with the second string using <see cref="StringComparison.InvariantCultureIgnoreCase"/>.
    /// </summary>
    /// <returns>True if the first string ends with the second string, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWithIgnoreCase(this string firstString, string secondString) {
        return firstString.EndsWith(secondString, StringComparison.InvariantCultureIgnoreCase);
    }
}
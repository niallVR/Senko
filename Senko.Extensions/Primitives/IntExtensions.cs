using System.Runtime.CompilerServices;

namespace NiallVR.Senko.Extensions.Primitives; 

/// <summary>
/// Extensions for the <see cref="int"/> struct.
/// </summary>
public static class IntExtensions {
    /// <summary>
    /// Determines if the value is within a certain range.
    /// </summary>
    /// <param name="number">The value to test.</param>
    /// <param name="min">The lower bound of the range.</param>
    /// <param name="max">The upper bound of the range.</param>
    /// <param name="inclusive">Should the check be inclusive?</param>
    /// <returns>True if the value is in the range, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInRange(this int number, long min, long max, bool inclusive) {
        return inclusive ? min <= number && number <= max : min < number && number < max;
    }
        
    /// <summary>
    /// Determines if the <see cref="uint"/> is within a certain range.
    /// </summary>
    /// <param name="number">The <see cref="uint"/> to test.</param>
    /// <param name="min">The lower bound of the range.</param>
    /// <param name="max">The upper bound of the range.</param>
    /// <param name="inclusive">Should the check be inclusive?</param>
    /// <returns>True if the <see cref="uint"/> is in the range, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInRange(this uint number, ulong min, ulong max, bool inclusive = true) {
        return inclusive ? min <= number && number <= max : min < number && number < max;
    }
}
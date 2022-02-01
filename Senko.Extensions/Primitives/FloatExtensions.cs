using System.Runtime.CompilerServices;

namespace NiallVR.Senko.Extensions.Primitives; 

/// <summary>
/// Extensions for the <see cref="float"/> struct.
/// </summary>
public static class FloatExtensions {
    /// <summary>
    /// Determines if the value is within a certain range.
    /// </summary>
    /// <param name="number">The value to test.</param>
    /// <param name="min">The lower bound of the range.</param>
    /// <param name="max">The upper bound of the range.</param>
    /// <param name="inclusive">Should the check be inclusive?</param>
    /// <returns>True if the value is in the range, false if not.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsInRange(this float number, float min, float max, bool inclusive) {
        return inclusive ? min <= number && number <= max : min < number && number < max;
    }
}
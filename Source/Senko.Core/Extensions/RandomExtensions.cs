namespace NiallVR.Senko.Core.Extensions; 

/// <summary>
/// Extensions for the <see cref="Random"/> class.
/// </summary>
public static class RandomExtensions {
    private const string LowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
    private const string UpperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string Numbers = "0123456789";

    /// <summary>
    /// Generates a random string.
    /// </summary>
    /// <param name="random">The instance of random to use.</param>
    /// <param name="length">The length of the string.</param>
    /// <param name="includeUpper">True if the random string should contain uppercase letters, false if not.</param>
    /// <param name="includeLower">True if the random string should contain lowercase letters, false if not.</param>
    /// <param name="includeNumbers">True if the random string should contain numbers, false if not.</param>
    /// <returns>The randomly generated string.</returns>
    /// <remarks>This should not be used for anything security related.</remarks>
    public static string GenerateRandomString(this Random random, int length, bool includeUpper = true, bool includeLower = true, bool includeNumbers = true) {
        if (length < 1)
            return string.Empty;
        
        var lower = includeLower ? LowerAlphabet : string.Empty;
        var upper = includeUpper ? UpperAlphabet : string.Empty;
        var numbers = includeNumbers ? Numbers : string.Empty;
        var alphabet = lower + upper + numbers;
        if (alphabet.Length == 0)
            return string.Empty;
        
        var output = new char[length];
        for (var i = 0; i < output.Length; i++)
            output[i] = alphabet[random.Next(alphabet.Length)];
        
        return new string(output);
    }
}
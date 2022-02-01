namespace NiallVR.Senko.Extensions.Collections; 

/// <summary>
/// Extensions for the <see cref="IDictionary{TK, TV}"/> interface.
/// </summary>
public static class DictionaryExtensions {
    /// <summary>
    /// Adds the value to the dictionary, if the key doesn't exist.
    /// Then returns the value stored under the key. 
    /// </summary>
    /// <param name="dict">The dictionary to operate on.</param>
    /// <param name="key">The key to store the value under.</param>
    /// <param name="value">The value to store under the key.</param>
    /// <typeparam name="TK">The type of key.</typeparam>
    /// <typeparam name="TV">The type of value.</typeparam>
    /// <returns>The value stored under the key if it exists, otherwise, the provided value.</returns>
    public static TV AddAndGet<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV value) {
        if (dict.TryGetValue(key, out var foundValue))
            return foundValue;
        
        dict[key] = value;
        return value;
    }
    
    /// <summary>
    /// Adds the value to the dictionary, if the key doesn't exist.
    /// Then returns the value stored under the key. 
    /// </summary>
    /// <param name="dict">The dictionary to operate on.</param>
    /// <param name="key">The key the value is stored under.</param>
    /// <param name="addFunction">The function used to generate the value if they key doesn't exist.</param>
    /// <typeparam name="TK">The type of key.</typeparam>
    /// <typeparam name="TV">The type of value.</typeparam>
    /// <returns>The value stored under the key if it exists, otherwise, the newly created value.</returns>
    public static TV AddAndGet<TK, TV>(this IDictionary<TK, TV> dict, TK key, Func<TV> addFunction) {
        if (dict.TryGetValue(key, out var foundValue))
            return foundValue;

        var toAdd = addFunction();
        dict[key] = toAdd;
        return toAdd;
    }
}
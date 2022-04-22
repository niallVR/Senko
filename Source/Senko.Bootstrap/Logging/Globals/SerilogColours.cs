namespace NiallVR.Senko.Bootstrap.Logging.Globals; 

// Colours can be found here
// https://stackoverflow.com/questions/4842424/list-of-ansi-color-escape-sequences

/// <summary>
/// A collection of colours that can be printed the console.
/// </summary>
internal static class SerilogColours {
    internal const string White = "\u001b[37m";
    internal const string Cyan = "\u001B[38;5;14m";
    internal const string Magenta = "\u001B[38;5;13m";
    internal const string Green = "\u001B[38;5;10m";
    internal const string Yellow = "\u001B[38;5;11m";
    internal const string Red = "\u001B[38;5;9m";
    internal const string Orange = "\u001B[38;5;208m";
}
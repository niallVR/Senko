using Serilog.Sinks.SystemConsole.Themes;

namespace NiallVR.Senko.Serilog.Globals; 

/// <summary>
/// Settings for the console sink.
/// </summary>
public static class SerilogConsoleSettings {
    /// <summary>
    /// The template used when printing a message to the console.
    /// </summary>
    public const string Template = "[{Timestamp:HH:mm:ss}] [{Level}] [{SourceContext}] {Message:lj}{NewLine}{Exception}";
    
    /// <summary>
    /// The colour theme used when printing to the console.
    /// </summary>
    public static AnsiConsoleTheme Theme { get; } = new(new Dictionary<ConsoleThemeStyle, string> {
        [ConsoleThemeStyle.Text] = SerilogColours.White,
        [ConsoleThemeStyle.SecondaryText] = SerilogColours.White,
        [ConsoleThemeStyle.TertiaryText] = SerilogColours.White,
        [ConsoleThemeStyle.Invalid] = SerilogColours.White,
        [ConsoleThemeStyle.Null] = SerilogColours.White,
        [ConsoleThemeStyle.Name] = SerilogColours.Cyan,
        [ConsoleThemeStyle.String] = SerilogColours.Green,
        [ConsoleThemeStyle.Number] = SerilogColours.Orange,
        [ConsoleThemeStyle.Boolean] = SerilogColours.Magenta,
        [ConsoleThemeStyle.Scalar] = SerilogColours.White,
        [ConsoleThemeStyle.LevelVerbose] = SerilogColours.Cyan,
        [ConsoleThemeStyle.LevelDebug] = SerilogColours.Magenta,
        [ConsoleThemeStyle.LevelInformation] = SerilogColours.Green,
        [ConsoleThemeStyle.LevelWarning] = SerilogColours.Yellow,
        [ConsoleThemeStyle.LevelError] = SerilogColours.Red,
        [ConsoleThemeStyle.LevelFatal] = SerilogColours.Red
    });
}
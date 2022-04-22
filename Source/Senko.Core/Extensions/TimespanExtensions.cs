namespace NiallVR.Senko.Core.Extensions;

public static class TimespanExtensions {
    /// <summary>
    /// Formats a <see cref="TimeSpan"/> into a HH:MM:SS or HH:MM format.
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> to convert.</param>
    /// <param name="includeSeconds">True if seconds should be appended to the output string.</param>
    /// <returns>The formatted string.</returns>
    /// <example>
    /// 1 Hour, 23 minutes and 3 seconds (includeSeconds = true): "01:23:03"<br/>
    /// 1 Hour, 23 minutes and 3 seconds (includeSeconds = false): "01:23"
    /// </example>
    public static string AsShortFormat(this TimeSpan timeSpan, bool includeSeconds = true) {
        var hours = timeSpan.Days * 24 + timeSpan.Hours;
        var minutes = timeSpan.Minutes;
        return includeSeconds ? $"{hours:D2}:{minutes:D2}:{timeSpan.Seconds:D2}" : $"{hours:D2}:{minutes:D2}";
    }


    /// <summary>
    /// Formats a <see cref="TimeSpan"/> into a long format string.
    /// </summary>
    /// <param name="timeSpan">The <see cref="TimeSpan"/> to convert.</param>
    /// <returns>The formatted string.</returns>
    /// <example>
    /// 0-Value <see cref="TimeSpan"/>: "0 Seconds"<br/>
    /// 50 milliseconds: "50 Milliseconds"<br/>
    /// 3 Hours, 23 minutes and 1 second: "3 Hours, 23 Minutes and 1 Second"<br/>
    /// 3 Hours and 1 second: "2 Hours and 1 Second"
    /// </example>
    public static string AsLongFormat(this TimeSpan timeSpan) {
        if (timeSpan.TotalMilliseconds == 0)
            return "0 Seconds";

        if (timeSpan.TotalSeconds < 1)
            return timeSpan.TotalMilliseconds + " Milliseconds";

        var strings = new List<string>(4);
        if (timeSpan.Days != 0) strings.Add(timeSpan.Days + (timeSpan.Days == 1 ? " Day" : " Days"));
        if (timeSpan.Hours != 0) strings.Add(timeSpan.Hours + (timeSpan.Hours == 1 ? " Hour" : " Hours"));
        if (timeSpan.Minutes != 0) strings.Add(timeSpan.Minutes + (timeSpan.Minutes == 1 ? " Minute" : " Minutes"));
        if (timeSpan.Seconds != 0) strings.Add(timeSpan.Seconds + (timeSpan.Seconds == 1 ? " Second" : " Seconds"));
        if (strings.Count == 1)
            return strings[0];

        return string.Join(", ", strings.ToArray(), 0, strings.Count - 1) + " and " + strings.LastOrDefault();
    }
}
namespace NiallVR.Senko.Events.Interfaces;

/// <summary>
/// A value which triggers an event upon being reassigned.
/// </summary>
/// <typeparam name="T">The type to monitor.</typeparam>
public interface IAsyncMonitoredValue<T> {
    /// <summary>
    /// The currently set value.
    /// </summary>
    T Value { get; }
    
    /// <summary>
    /// An event which is fired when the value is changed.
    /// </summary>
    IAsyncEvent<T> OnChanged { get; }
    
    /// <summary>
    /// Updates the value, triggering the event.
    /// </summary>
    /// <param name="newValue">The new value to update the value to.</param>
    Task SetValueAsync(T newValue);
}
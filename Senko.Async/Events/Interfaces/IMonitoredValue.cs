namespace NiallVR.Senko.Async.Events.Interfaces;

public interface IMonitoredValue<T> {
    /// <summary>
    /// The current value.
    /// </summary>
    T Value { get; }
    
    /// <summary>
    /// An event which is triggered when the value is changed.
    /// </summary>
    IAsyncEvent<T> OnChanged { get; }
    
    /// <summary>
    /// Updates the value, triggering the event.
    /// </summary>
    /// <param name="newValue">The new value to update the value to.</param>
    void UpdateValue(T newValue);
}
namespace NiallVR.Senko.Async.Events.Interfaces; 

/// <summary>
/// An async implementation of C# events.
/// </summary>
public interface IAsyncEvent {
    /// <summary>
    /// Subscribes a listener to the event.
    /// </summary>
    /// <param name="method">The method to call when an event is triggered.</param>
    void Subscribe(Func<Task> method);
        
    /// <summary>
    /// Unsubscribes a listener from the event.
    /// </summary>
    /// <param name="method">The method to remove.</param>
    void Unsubscribe(Func<Task> method);

    /// <summary>
    /// Returns a collection of the listeners subscribed to the event.
    /// </summary>
    /// <returns>The listeners subscribed to the event.</returns>
    IReadOnlyCollection<Func<Task>> GetListeners();
        
    /// <summary>
    /// Removes all listeners from the event.
    /// </summary>
    void ClearListeners();
        
    /// <summary>
    /// Invokes all of the listeners one at a time, in the order they were added.
    /// </summary>
    /// <returns>A task that completes when all listeners have finished or errored.</returns>
    Task InvokeSync();
        
    /// <summary>
    /// Invokes all of the listeners at the same time.
    /// </summary>
    /// <returns>A task that completes when all listeners have finished or errored.</returns>
    Task InvokeAsync();
}
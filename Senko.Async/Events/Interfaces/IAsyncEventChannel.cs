namespace NiallVR.Senko.Extensions.Events.Interfaces; 

/// <summary>
/// An <see cref="IAsyncEvent"/> handler which queues incoming events and invokes them one at a time.
/// </summary>
public interface IAsyncEventChannel : IDisposable {
    /// <summary>
    /// Subscribes to the event channel.
    /// </summary>
    /// <param name="listener">The method to call when an object is written to the channel.</param>
    void Subscribe(Func<Task> listener);
        
    /// <summary>
    /// Unsubscribes from the event channel.
    /// </summary>
    /// <param name="listener">The method to remove from the channel.</param>
    void Unsubscribe(Func<Task> listener);
    
    /// <summary>
    /// Returns a collection of the listeners subscribed to the event channel.
    /// </summary>
    /// <returns>The listeners subscribed to the event channel.</returns>
    IReadOnlyCollection<Func<Task>> GetListeners();
    
    /// <summary>
    /// Removes all listeners from the channel.
    /// </summary>
    void ClearListeners();
        
    /// <summary>
    /// Invokes all of the listeners.
    /// </summary>
    Task Invoke();
}
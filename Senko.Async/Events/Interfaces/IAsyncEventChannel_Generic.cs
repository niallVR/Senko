namespace NiallVR.Senko.Async.Events.Interfaces; 

/// <inheritdoc cref="IAsyncEventChannel"/>
/// <typeparam name="T">The type passed to subscribers.</typeparam>
public interface IAsyncEventChannel<T> : IDisposable {
    /// <summary>
    /// Subscribes to the event channel.
    /// </summary>
    /// <param name="listener">The method to call when an object is written to the channel.</param>
    void Subscribe(Func<T, Task> listener);
        
    /// <summary>
    /// Unsubscribes from the event channel.
    /// </summary>
    /// <param name="listener">The method to remove from the channel.</param>
    void Unsubscribe(Func<T, Task> listener);
    
    /// <summary>
    /// Returns a collection of the listeners subscribed to the event channel.
    /// </summary>
    /// <returns>The listeners subscribed to the event channel.</returns>
    IReadOnlyCollection<Func<T, Task>> GetListeners();
    
    /// <summary>
    /// Removes all listeners from the channel.
    /// </summary>
    void ClearListeners();
        
    /// <summary>
    /// Invokes all of the listeners.
    /// </summary>
    /// <param name="arg">The value to pass to the listeners.</param>
    Task Invoke(T arg);
}
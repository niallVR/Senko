namespace NiallVR.Senko.Events.Interfaces; 

/// <summary>
/// <para>
/// An event queue system which queues events and processes them on a first come first served basis.
/// </para>
/// <para>
/// Worker functions are the functions which process the incoming events.
/// For each AsyncEventChannel there can be many worker functions.
/// </para>
/// <para>
/// When a new event gets processed, it's added to the internal queue.
/// Only one event can be processed at a time.
/// Each event is processed by all of the worker functions before moving on to the next event in the queue.
/// </para>
/// </summary>
/// <typeparam name="T">The type passed to subscribers.</typeparam>
public interface IAsyncEventChannel<T> : IDisposable {
    /// <summary>
    /// Adds a new worker to the AsyncEventChannel.
    /// </summary>
    /// <param name="listener">The method to call when an event is being processed.</param>
    /// <remarks>
    /// This does not check for duplicates!
    /// Adding the same method multiple times will result in multiple calls.
    /// </remarks>
    void AddWorker(Func<T, Task> listener);
        
    /// <summary>
    /// Removes the worker from the AsyncEventChannel.
    /// </summary>
    /// <param name="listener">The method to remove.</param>
    void RemoveWorker(Func<T, Task> listener);
    
    /// <summary>
    /// Returns a collection of the worker functions.
    /// </summary>
    /// <returns>All of the worker functions that are added to this AsyncEventChannel.</returns>
    IReadOnlyCollection<Func<T, Task>> GetWorkers();
    
    /// <summary>
    /// Removes all worker functions from this AsyncEventChannel.
    /// </summary>
    void ClearWorkers();
        
    /// <summary>
    /// Adds an event to the internal queue to be processed by the worker functions.
    /// </summary>
    /// <param name="eventData">The event data.</param>
    Task ProcessEventAsync(T eventData);
}
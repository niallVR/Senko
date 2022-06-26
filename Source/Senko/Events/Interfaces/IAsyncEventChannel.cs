namespace NiallVR.Senko.Events.Interfaces;

/// <summary>
/// <para>
/// An event queue system which queues events and processes them one at a time.
/// </para>
/// <para>
/// Worker functions are the functions which process the incoming events.
/// For each IAsyncEventChannel there can be many worker functions.
/// </para>
/// <para>
/// When a new event gets processed, it's added to the internal queue.
/// Each event is processed by all of the worker functions before moving on to the next event in the queue.
/// </para>
/// </summary>
/// <typeparam name="T">The type passed to subscribers.</typeparam>
public interface IAsyncEventChannel<T> : IDisposable
{
    /// <summary>
    /// Adds a new worker to the AsyncEventChannel.
    /// </summary>
    /// <param name="worker">The method to call when an event is being processed.</param>
    void AddWorker(Func<T, CancellationToken, Task> worker);

    /// <summary>
    /// Removes the worker from the AsyncEventChannel.
    /// </summary>
    /// <param name="worker">The method to remove.</param>
    void RemoveWorker(Func<T, CancellationToken, Task> worker);

    /// <summary>
    /// Removes all of the workers from this IAsyncEventChannel.
    /// </summary>
    void ClearWorkers();

    /// <summary>
    /// Returns a collection of all the workers.
    /// </summary>
    /// <returns>All of the workers that are added to this IAsyncEventChannel.</returns>
    IReadOnlyCollection<Func<T, CancellationToken, Task>> GetWorkers();
    
    /// <summary>
    /// Adds an event to be processed by the workers.
    /// </summary>
    /// <param name="eventData">The event data to be processed by the workers.</param>
    /// <returns>A task which completes when the event data is added to the queue.</returns>
    ValueTask AddEventAsync(T eventData);

    /// <summary>
    /// Clears the queue and stops the workers if they're processing an event.
    /// </summary>
    void ClearEvents();
}
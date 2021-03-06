namespace NiallVR.Senko.Events.Interfaces;

/// <summary>
/// A asynchronous version of C# events.
/// </summary>
/// <typeparam name="T">The type sent when an event is raised.</typeparam>
public interface IAsyncEvent<T>
{
    /// <summary>
    /// Subscribes a listener to the event.
    /// </summary>
    /// <param name="method">The method to call when an event is fired.</param>
    /// <remarks>
    /// This does not check for duplicates!
    /// Adding the same method multiple times will result in multiple calls.
    /// </remarks>
    void AddListener(Func<T, Task> method);

    /// <summary>
    /// Unsubscribes a listener from the event if it's subscribed.
    /// </summary>
    /// <param name="method">The method to remove.</param>
    /// <remarks>
    /// This will remove the first match of the listener.
    /// If multiple of the same listener was added, call this multiple times.
    /// </remarks>
    void RemoveListener(Func<T, Task> method);

    /// <summary>
    /// Removes all of the listeners subscribed to the event.
    /// </summary>
    void ClearListeners();
    
    /// <summary>
    /// Returns a collection of the listeners subscribed to the event.
    /// </summary>
    /// <returns>The listeners subscribed to the event.</returns>
    IReadOnlyCollection<Func<T, Task>> GetListeners();

    /// <summary>
    /// Calls all of the listener methods with the provided data.
    /// </summary>
    /// <param name="data">The data to send with the event.</param>
    /// <returns>A task that completes when all listeners have finished or errored.</returns>
    /// <exception cref="AggregateException">Thrown if one or more of the listeners throw an exception.</exception>
    Task InvokeAsync(T data);
}
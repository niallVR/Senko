namespace NiallVR.Senko.Async.Events.Interfaces; 

/// <inheritdoc cref="IAsyncEvent"/>
/// <typeparam name="T">The type passed to subscribers.</typeparam>
public interface IAsyncEvent<T> {
    /// <inheritdoc cref="IAsyncEvent.Subscribe"/>
    void Subscribe(Func<T, Task> method);
    
    /// <inheritdoc cref="IAsyncEvent.Unsubscribe"/>
    void Unsubscribe(Func<T, Task> method);
    
    /// <inheritdoc cref="IAsyncEvent.GetListeners"/>
    IReadOnlyCollection<Func<T, Task>> GetListeners();
    
    /// <inheritdoc cref="IAsyncEvent.ClearListeners"/>
    void ClearListeners();
    
    /// <inheritdoc cref="IAsyncEvent.InvokeSync"/>
    /// <param name="instance">The instance to pass to all the listeners.</param>
    Task InvokeSync(T instance);
    
    /// <inheritdoc cref="IAsyncEvent.InvokeAsync"/>
    /// <param name="instance">The instance to pass to all the listeners.</param>
    Task InvokeAsync(T instance);
}
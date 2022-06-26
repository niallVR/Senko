using NiallVR.Senko.Events.Interfaces;

namespace NiallVR.Senko.Events.Implementations;

/// <inheritdoc cref="IAsyncEvent{T}"/>
public class AsyncEvent<T> : IAsyncEvent<T>
{
    private readonly List<Func<T, Task>> _methods = new();

    /// <inheritdoc cref="IAsyncEvent{T}.AddListener"/>
    public void AddListener(Func<T, Task> method) => _methods.Add(method);
    
    /// <inheritdoc cref="IAsyncEvent{T}.RemoveListener"/>
    public void RemoveListener(Func<T, Task> method) => _methods.Remove(method);
    
    /// <inheritdoc cref="IAsyncEvent{T}.ClearListeners"/>
    public void ClearListeners() => _methods.Clear();
    
    /// <inheritdoc cref="IAsyncEvent{T}.GetListeners"/>
    public IReadOnlyCollection<Func<T, Task>> GetListeners() => _methods;

    /// <inheritdoc cref="IAsyncEvent{T}.InvokeAsync"/>
    public async Task InvokeAsync(T eventData) => await Task.WhenAll(_methods.Select(m => m(eventData))).ConfigureAwait(false);
}
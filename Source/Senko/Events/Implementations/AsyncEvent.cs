using NiallVR.Senko.Events.Interfaces;

namespace NiallVR.Senko.Events.Implementations;

/// <inheritdoc cref="IAsyncEvent{T}"/>
public class AsyncEvent<T> : IAsyncEvent<T>
{
    private readonly List<Func<T, Task>> _methods = new();

    public void Subscribe(Func<T, Task> method) => _methods.Add(method);
    public void Unsubscribe(Func<T, Task> method) => _methods.Remove(method);
    public IReadOnlyCollection<Func<T, Task>> GetListeners() => _methods;
    public void ClearListeners() => _methods.Clear();

    public async Task InvokeAsync(T eventData) =>
        await Task.WhenAll(_methods.Select(m => m(eventData))).ConfigureAwait(false);
}
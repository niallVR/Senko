using NiallVR.Senko.Events.Interfaces;

namespace NiallVR.Senko.Events.Implementations;

/// <inheritdoc cref="IAsyncMonitoredValue{T}"/>
public class AsyncMonitoredValue<T> : IAsyncMonitoredValue<T>
{
    /// <inheritdoc cref="IAsyncMonitoredValue{T}.Value"/>
    public T Value { get; private set; }

    /// <inheritdoc cref="IAsyncMonitoredValue{T}.OnChanged"/>
    public IAsyncEvent<T> OnChanged { get; } = new AsyncEvent<T>();
    
    /// <param name="initialValue">The value to initialise the monitored value with.</param>
    public AsyncMonitoredValue(T initialValue)
    {
        Value = initialValue;
    }

    /// <inheritdoc cref="IAsyncMonitoredValue{T}.SetValueAsync(T)"/>
    public async Task SetValueAsync(T newValue)
    {
        Value = newValue;
        await OnChanged.InvokeAsync(newValue).ConfigureAwait(false);
    }
}
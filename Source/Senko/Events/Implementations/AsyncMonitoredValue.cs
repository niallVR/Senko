using NiallVR.Senko.Events.Interfaces;

namespace NiallVR.Senko.Events.Implementations;

/// <inheritdoc cref="IAsyncMonitoredValue{T}"/>
public class AsyncMonitoredValue<T> : IAsyncMonitoredValue<T>
{
    public T Value { get; private set; }
    public IAsyncEvent<T> OnChanged { get; }

    public AsyncMonitoredValue(T initialValue)
    {
        Value = initialValue;
        OnChanged = new AsyncEvent<T>();
    }

    public async Task SetValueAsync(T newValue)
    {
        Value = newValue;
        await OnChanged.InvokeAsync(newValue).ConfigureAwait(false);
    }
}
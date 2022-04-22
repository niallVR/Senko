using NiallVR.Senko.Core.Events.Interfaces;

namespace NiallVR.Senko.Core.Events.Implementations; 

public class AsyncMonitoredValue<T> : IAsyncMonitoredValue<T> {
    public T Value { get; private set; }
    public IAsyncEvent<T> OnChanged { get;  }

    public AsyncMonitoredValue(T initialValue) {
        Value = initialValue;
        OnChanged = new AsyncEvent<T>();
    }
    
    public async Task SetValueAsync(T newValue) {
        Value = newValue;
        await OnChanged.InvokeAsync(newValue).ConfigureAwait(false);    
    }
}
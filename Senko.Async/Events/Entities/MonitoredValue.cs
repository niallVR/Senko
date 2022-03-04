using Microsoft.Extensions.Logging;
using NiallVR.Senko.Async.Events.Interfaces;

namespace NiallVR.Senko.Async.Events.Entities; 

public class MonitoredValue<T> : IMonitoredValue<T> {
    public T Value { get; private set; }
    public IAsyncEvent<T> OnChanged { get;  }

    public MonitoredValue(T initialValue) {
        Value = initialValue;
        OnChanged = new AsyncEvent<T>();
    }
    
    public MonitoredValue(T initialValue, ILogger logger) {
        Value = initialValue;
        OnChanged = new AsyncEvent<T>(logger);
    }

    public void UpdateValue(T newValue) {
        Value = newValue;
        OnChanged.InvokeAsync(newValue);
    }
}
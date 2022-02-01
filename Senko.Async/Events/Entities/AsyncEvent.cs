using Microsoft.Extensions.Logging;
using NiallVR.Senko.Async.Events.Interfaces;

namespace NiallVR.Senko.Async.Events.Entities; 

public class AsyncEvent : IAsyncEvent {
    private readonly ILogger? _logger;
    private readonly List<Func<Task>> _methods = new();

    public AsyncEvent() {
    }
        
    public AsyncEvent(ILogger logger) {
        _logger = logger;
    }
        
    public void Subscribe(Func<Task> method) => _methods.Add(method);
    public void Unsubscribe(Func<Task> method) => _methods.Remove(method);

    public IReadOnlyCollection<Func<Task>> GetListeners() => _methods;
    public void ClearListeners() => _methods.Clear();
        
    public async Task InvokeSync() {
        foreach (var method in _methods) {
            try {
                await method.Invoke().ConfigureAwait(false);
            } catch (Exception error) {
                LogError(error);
            }
        }
    }

    public async Task InvokeAsync() {
        // Tasks can potentially throw instantly, so need to try catch everywhere.
        var invokedTasks = new List<Task>(_methods.Count);
        foreach (var method in _methods) {
            try {
                invokedTasks.Add(method());
            } catch (Exception error) {
                LogError(error);
            }
        }
            
        try {
            await Task.WhenAll(invokedTasks).ConfigureAwait(false);
        } catch (Exception) {
            // Ignored
            // This will throw if any of the tasks threw an error. This is handled later on.
        }
            
        foreach (var invokedTask in invokedTasks) {
            try {
                await invokedTask.ConfigureAwait(false);
            } catch (Exception error) {
                LogError(error);
            }
        }
    }

    private void LogError(Exception error) {
        if (_logger is null)
            Console.Out.WriteLine($"A listener encountered an error: {error}");
        else
            _logger.Log(LogLevel.Error, error, "A listener encountered an error");
    }
}
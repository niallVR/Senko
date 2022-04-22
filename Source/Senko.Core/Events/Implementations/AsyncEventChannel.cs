using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Core.Events.Interfaces;

namespace NiallVR.Senko.Core.Events.Implementations;

/// <inheritdoc cref="IAsyncEventChannel{T}"/>
public class AsyncEventChannel<T> : IAsyncEventChannel<T> {
    private readonly ILogger _logger;
    private readonly AsyncEvent<T> _eventHandler = new();
    private readonly CancellationTokenSource _cancellationToken = new();
    private readonly Channel<T> _eventChannel = Channel.CreateUnbounded<T>();
    
    public AsyncEventChannel(ILogger logger) {
        _logger = logger;
        Task.Run(RunEventLoop);
    }
    
    public void AddWorker(Func<T, Task> listener) => _eventHandler.Subscribe(listener);
    public void RemoveWorker(Func<T, Task> listener) => _eventHandler.Unsubscribe(listener);
    public IReadOnlyCollection<Func<T, Task>> GetWorkers() => _eventHandler.GetListeners();
    public void ClearWorkers() => _eventHandler.ClearListeners();
    public async Task ProcessEventAsync(T eventData) => await _eventChannel.Writer.WriteAsync(eventData).ConfigureAwait(false);

    public void Dispose() {
        _cancellationToken.Cancel();
        _cancellationToken.Dispose();
    }

    private async Task RunEventLoop() {
        while (await _eventChannel.Reader.WaitToReadAsync(_cancellationToken.Token)) {
            while (_eventChannel.Reader.TryRead(out var eventData))
                await CallWorkers(eventData).ConfigureAwait(false);
        }
    }

    private async Task CallWorkers(T eventData) {
        try {
            await _eventHandler.InvokeAsync(eventData).ConfigureAwait(false);
        } catch (AggregateException aggregateException) {
            foreach (var innerException in aggregateException.InnerExceptions)
                _logger.LogError(innerException, "A worker function threw an exception");
        } catch (Exception exception) {
            _logger.LogError(exception, "An unknown exception happens when calling the worker functions");
        }
    }
}
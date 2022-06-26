using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Events.Interfaces;

namespace NiallVR.Senko.Events.Implementations;

/// <inheritdoc cref="IAsyncEventChannel{T}"/>
public class AsyncEventChannel<T> : IAsyncEventChannel<T>
{
    private CancellationTokenSource? _eventCancellation;

    private readonly ILogger _logger;
    private readonly Channel<T> _eventChannel = Channel.CreateUnbounded<T>();
    private readonly List<Func<T, CancellationToken, Task>> _workers = new();
    private readonly CancellationTokenSource _eventChannelCancellation = new();


    /// <param name="logger">The logger to output exceptions to.</param>
    public AsyncEventChannel(ILogger logger)
    {
        _logger = logger;
        Task.Run(StartEventLoop);
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose()
    {
        ClearEvents();
        ClearWorkers();
        _eventChannelCancellation.Cancel();
        _eventChannelCancellation.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.AddWorker"/>
    public void AddWorker(Func<T, CancellationToken, Task> worker)
    {
        _workers.Add(worker);
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.RemoveWorker"/>
    public void RemoveWorker(Func<T, CancellationToken, Task> worker)
    {
        _workers.Remove(worker);
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.ClearWorkers"/>
    public void ClearWorkers()
    {
        _workers.Clear();
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.GetWorkers"/>
    public IReadOnlyCollection<Func<T, CancellationToken, Task>> GetWorkers()
    {
        return _workers;
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.AddEventAsync"/>
    public ValueTask AddEventAsync(T eventData)
    {
        return _eventChannel.Writer.WriteAsync(eventData, _eventChannelCancellation.Token);
    }

    /// <inheritdoc cref="IAsyncEventChannel{T}.ClearEvents"/>
    public void ClearEvents()
    {
        while (_eventChannel.Reader.TryRead(out _)) {} // Clear the channel
        _eventCancellation?.Cancel(); // Stop the current work being done.
    }

    private async Task StartEventLoop()
    {
        while (await _eventChannel.Reader.WaitToReadAsync(_eventChannelCancellation.Token).ConfigureAwait(false))
        {
            while (_eventChannel.Reader.TryRead(out var eventData))
                await ProcessEvent(eventData).ConfigureAwait(false);
        }
    }

    private async Task ProcessEvent(T eventData)
    {
        try
        {
            _eventCancellation = new CancellationTokenSource();
            var tasks = _workers.Select(m => m(eventData, _eventCancellation.Token)).ToArray();
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
        catch (AggregateException aggregateException)
        {
            foreach (var innerException in aggregateException.InnerExceptions) 
                _logger.LogError(innerException, "A worker function threw an exception");
        }
        catch (Exception exception)
        { 
            _logger.LogError(exception, "An unknown exception happens when calling the worker functions");
        }
        finally
        {
            _eventCancellation?.Dispose();
            _eventCancellation = null;
        }
    }
}
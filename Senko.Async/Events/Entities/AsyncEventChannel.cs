using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using NiallVR.Senko.Extensions.Events.Interfaces;

namespace NiallVR.Senko.Extensions.Events.Entities;

public class AsyncEventChannel : IAsyncEventChannel {
    private readonly ILogger? _logger;
    private readonly bool _useInvokeAsync;
    private readonly AsyncEvent _eventHandler;
    private readonly CancellationTokenSource _cancellationToken;
    private readonly Channel<bool> _eventChannel = Channel.CreateUnbounded<bool>();
    
    /// <param name="logger">The logger to use. If null, Console.Out.WriteLine will be used.</param>
    /// <param name="listener">A listener to register to the event channel.</param>
    /// <param name="useInvokeAsync">If true, <see cref="IAsyncEvent.InvokeAsync"/> will be used.</param>
    public AsyncEventChannel(ILogger? logger = null, Func<Task>? listener = null, bool useInvokeAsync = true) {
        _logger = logger;
        _useInvokeAsync = useInvokeAsync;
        _cancellationToken = new CancellationTokenSource();
        _eventHandler = _logger is null ? new AsyncEvent() : new AsyncEvent(_logger);
        if (listener is not null)
            _eventHandler.Subscribe(listener);
        
        Task.Run(RunEventLoop);
    }

    public void Dispose() {
        _cancellationToken.Cancel();
        _cancellationToken.Dispose();
    }

    public void Subscribe(Func<Task> eventListener) => _eventHandler.Subscribe(eventListener);
    public void Unsubscribe(Func<Task> eventListener) => _eventHandler.Unsubscribe(eventListener);

    public IReadOnlyCollection<Func<Task>> GetListeners() => _eventHandler.GetListeners();
    public void ClearListeners() => _eventHandler.ClearListeners();

    public async Task Invoke() {
        await _eventChannel.Writer.WaitToWriteAsync().ConfigureAwait(false);
        await _eventChannel.Writer.WriteAsync(false).ConfigureAwait(false);
    }

    private async Task RunEventLoop() {
        while (!_cancellationToken.IsCancellationRequested) {
            try {
                while (await _eventChannel.Reader.WaitToReadAsync(_cancellationToken.Token)) {
                    while (_eventChannel.Reader.TryRead(out _)) {
                        if (_useInvokeAsync)
                            await _eventHandler.InvokeAsync().ConfigureAwait(false);
                        else
                            await _eventHandler.InvokeSync().ConfigureAwait(false);
                    }
                }
            } catch (Exception error) {
                // Don't report that the token was canceled.
                if (!_cancellationToken.IsCancellationRequested)
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
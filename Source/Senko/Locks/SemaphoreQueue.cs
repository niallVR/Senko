using System.Collections.Concurrent;

namespace NiallVR.Senko.Locks;

/// <summary>
/// A <see cref="SemaphoreSlim"/> wrapper which enforces FIFO.
/// </summary>
public class SemaphoreQueue : IDisposable
{
    /// <inheritdoc cref="SemaphoreSlim.CurrentCount"/>
    public int CurrentCount => _semaphoreSlim.CurrentCount;

    private readonly SemaphoreSlim _semaphoreSlim;
    private readonly ConcurrentQueue<TaskCompletionSource> _queue = new();

    /// <inheritdoc cref="SemaphoreSlim(int)"/>
    public SemaphoreQueue(int initialCount)
    {
        _semaphoreSlim = new SemaphoreSlim(initialCount);
    }

    /// <inheritdoc cref="SemaphoreSlim(int, int)"/>
    public SemaphoreQueue(int initialCount, int maxCount)
    {
        _semaphoreSlim = new SemaphoreSlim(initialCount, maxCount);
    }
    
    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose()
    {
        _semaphoreSlim.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="SemaphoreSlim.WaitAsync()"/>
    public async Task WaitAsync()
    {
        // SemaphoreSlim doesn't use FIFO, so we have to create a queue system for this behaviour.
        // We first need to create a task which will be in the queue to enter the semaphore.
        var taskCompletionSource = new TaskCompletionSource();
        _queue.Enqueue(taskCompletionSource);

        // Now we need to create a task which attempts to enter the semaphore.
        // Upon entering, it will pull the next task from the queue and complete it.
        _ = UnlockNextInLine();

        // All that's left to do is await our turn to enter the semaphore.
        await taskCompletionSource.Task;
    }

    private async Task UnlockNextInLine()
    {
        await _semaphoreSlim.WaitAsync();
        if (_queue.TryDequeue(out var nextTaskCompletionSource))
            nextTaskCompletionSource.SetResult();
    }

    /// <inheritdoc cref="SemaphoreSlim.Release()"/>
    public int Release()
    {
        return _semaphoreSlim.Release();
    }


}
using NiallVR.Senko.Locks;

namespace NiallVR.Senko.Extensions; 

/// <summary>
/// Extensions for the <see cref="SemaphoreQueue"/> class.
/// </summary>
public static class SemaphoreQueueExtensions {
    public readonly struct SemaphoreQueueReleaser : IDisposable {
        private readonly SemaphoreQueue _lockInstance;
        
        public SemaphoreQueueReleaser(SemaphoreQueue lockInstance) => _lockInstance = lockInstance;
        public void Dispose() => _lockInstance.Release();
    }
    
    /// <summary>
    /// Waits to enter the <see cref="SemaphoreQueue"/> and returns a disposable struct to release the semaphore.
    /// </summary>
    /// <returns>A task that completes when the <see cref="SemaphoreQueue"/> has been entered.</returns>
    /// <example>
    /// using var _ = await _lock.WaitAsyncDisposable();
    /// </example>
    public static async Task<SemaphoreQueueReleaser> WaitAsyncDisposable(this SemaphoreQueue lockInstance) {
        await lockInstance.WaitAsync().ConfigureAwait(false);
        return new SemaphoreQueueReleaser(lockInstance);
    }
}
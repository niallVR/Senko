namespace NiallVR.Senko.Extensions; 

/// <summary>
/// Extensions for the <see cref="SemaphoreSlim"/> class.
/// </summary>
public static class SemaphoreSlimExtensions {
    public readonly struct SemaphoreSlimReleaser : IDisposable {
        private readonly SemaphoreSlim _lockInstance;
        
        public SemaphoreSlimReleaser(SemaphoreSlim lockInstance) => _lockInstance = lockInstance;
        public void Dispose() => _lockInstance.Release();
    }

    /// <summary>
    /// Waits to enter the <see cref="SemaphoreSlim"/> and returns a disposable struct to release the semaphore.
    /// </summary>
    /// <returns>A task that completes when the <see cref="SemaphoreSlim"/> has been entered.</returns>
    /// <example>
    /// using var _ = await _lock.WaitAsyncDisposable();
    /// </example>
    public static async Task<SemaphoreSlimReleaser> WaitAsyncDisposable(this SemaphoreSlim lockInstance) {
        await lockInstance.WaitAsync().ConfigureAwait(false);
        return new SemaphoreSlimReleaser(lockInstance);
    }
    

}
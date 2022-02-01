namespace NiallVR.Senko.Extensions.Extensions; 

/// <summary>
/// A collection of extensions for working with Tasks
/// </summary>
public static class TaskExtensions {
    /// <summary>
    /// Returns a task which will complete when the original task finishes or a timeout happens.
    /// </summary>
    /// <param name="runningTask">The task to wait upon.</param>
    /// <param name="timeoutDuration">The amount of time the task should finish in.</param>
    /// <returns>True if the task finished on time, false if it hits the timeout.</returns>
    /// <remarks>This does not cancel the task if it times out.</remarks>
    public static async Task<bool> WithTimeout(this Task runningTask, TimeSpan timeoutDuration) {
        var timeoutTask = Task.Delay(timeoutDuration);
        var firstTaskToFinish = await Task.WhenAny(runningTask, timeoutTask).ConfigureAwait(false);
        return firstTaskToFinish == runningTask;
    }
        
    /// <summary>
    /// Returns a task which will complete when the original task finishes or a timeout happens.
    /// </summary>
    /// <param name="runningTask">The task to wait upon.</param>
    /// <param name="timeoutDuration">The amount of time the task should finish in.</param>
    /// <returns>(True, Task Result) if the task finished. (False, Default) if it timed out.</returns>
    /// <remarks>This does not cancel the task if it times out.</remarks>
    public static async Task<Tuple<bool, T>> WithTimeout<T>(this Task<T> runningTask, TimeSpan timeoutDuration) {
        var timeoutTask = Task.Delay(timeoutDuration);
        var firstTaskToFinish = await Task.WhenAny(runningTask, timeoutTask).ConfigureAwait(false);
        return firstTaskToFinish == runningTask ? new Tuple<bool, T>(true, await runningTask) : new Tuple<bool, T>(false, default!);
    }
}
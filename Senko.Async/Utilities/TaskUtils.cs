using Microsoft.Extensions.Logging;
using NiallVR.Senko.Async.Extensions;

namespace NiallVR.Senko.Async.Utilities; 

public static class TaskUtils {
    /// <summary>
    /// Creates a task that will run until the application exits.
    /// If the task throws an error, it's logged and ignored.
    /// </summary>
    /// <param name="taskToRun">The task to run.</param>
    /// <param name="logger">The logger to use when an error is thrown.</param>
    /// <param name="continueOnError">If an error is thrown, should the task be restarted?</param>
    public static void RunEndlessly(Func<Task> taskToRun, ILogger logger, bool continueOnError = true) {
        Task.Run(async () => {
            while (true) {
                try {
                    await taskToRun().ConfigureAwait(false);
                } catch (Exception error) {
                    logger.LogError(error, "An endless task ran into an error");
                    if (!continueOnError)
                        break;
                }
            }
        });
    }

    /// <summary>
    /// Creates a task that will run until the application exits.
    /// If the task throws an error, it's logged and ignored.
    /// </summary>
    /// <param name="taskToRun">The task to run.</param>
    /// <param name="logger">The logger to use when an error is thrown.</param>
    /// <param name="token">A cancellation token to stop the task.</param>
    /// <param name="continueOnError">If an error is thrown, should the task be restarted?</param>
    public static void RunEndlessly(Func<Task> taskToRun, ILogger logger, CancellationToken token, bool continueOnError = true) {
        Task.Run(async () => {
            while (!token.IsCancellationRequested) {
                try {
                    await taskToRun().ConfigureAwait(false);
                } catch (Exception error) {
                    logger.LogError(error, "An endless task ran into an error");
                    if (!continueOnError)
                        break;
                }
            }
        }, token);
    }
        
    /// <summary>
    /// Runs a task inside of a Try/Catch block.
    /// If an error is thrown, it's logged and ignored.
    /// </summary>
    /// <remarks>This is designed to be an improvement over fire and forget.</remarks>
    /// <param name="toRun">The task to run.</param>
    /// <param name="logger">The logger to use if an error is thrown.</param>
    /// <returns>True if the task didn't error, false if it did.</returns>
    public static async Task<bool> TryRun(Func<Task> toRun, ILogger logger) {
        try {
            await toRun().ConfigureAwait(false);
            return true;
        } catch (Exception error) {
            logger.LogError(error, "A task ran into an error");
            return false;
        }
    }

    /// <summary>
    /// Runs a task inside of a Try/Catch block.
    /// If an error is thrown, it's logged and ignored.
    /// </summary>
    /// <remarks>This is designed to be an improvement over fire and forget.</remarks>
    /// <param name="toRun">The task to run.</param>
    /// <param name="arg">The argument to pass to the task.</param>
    /// <param name="logger">The logger to use if an error is thrown.</param>
    /// <typeparam name="T">The type of argument to pass to the task.</typeparam>
    /// <returns>True if the task didn't error, false if it did.</returns>
    public static async Task<bool> TryRun<T>(Func<T, Task> toRun, T arg, ILogger logger) {
        try {
            await toRun(arg).ConfigureAwait(false);
            return true;
        } catch (Exception error) {
            logger.LogError(error, "A task ran into an error");
            return false;
        }
    }
        
    private static async Task RunUntilConditionOrCanceled(Func<bool> func, CancellationToken token) {
        while (!token.IsCancellationRequested && !func())
            await Task.Delay(25, CancellationToken.None).ConfigureAwait(false);
    }

    /// <summary>
    /// Checks for a condition until it's met or timesout.
    /// </summary>
    /// <param name="func">The condition to check for.</param>
    /// <param name="timeout">The max amount of time to check for.</param>
    /// <returns>True if the condition was met, false if it took too much time.</returns>
    public static async Task<bool> WaitForCondition(Func<bool> func, TimeSpan timeout) {
        using var cancelTokenSource = new CancellationTokenSource();
        var funcTask = RunUntilConditionOrCanceled(func, cancelTokenSource.Token);
        var funcFinishFirst = await funcTask.WithTimeout(timeout).ConfigureAwait(false);
        cancelTokenSource.Cancel();
        return funcFinishFirst;
    }
}
using Android.App;
using Android.Content;
using System.Collections.Concurrent;

namespace MauiBlazorToolkit.Platform
{
    public class IntermediateActivity
    {
        static readonly string guidExtra = Guid.NewGuid().ToString();

        static readonly ConcurrentDictionary<string, IntermediateTask> pendingTasks = new();

        static Activity? Activity => Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;

        internal static void OnActivityResult(int requestCode, Result resultCode, Intent? data)
        {
            string? guid = Activity?.Intent?.GetStringExtra(guidExtra);
            var task = GetIntermediateTask(guid, true);

            if (task is null)
                return;

            if (resultCode == Result.Canceled)
            {
                task.TaskCompletionSource.TrySetCanceled();
            }
            else
            {
                try
                {
                    data ??= new Intent();

                    task.OnResult?.Invoke(data);

                    task.TaskCompletionSource.TrySetResult(data);
                }
                catch (Exception ex)
                {
                    task.TaskCompletionSource.TrySetException(ex);
                }
            }
        }

        public static Task<Intent> StartAsync(Intent intent, int requestCode, Action<Intent>? onResult = null)
        {
            var data = new IntermediateTask(onResult);
            pendingTasks[data.Id] = data;

            Activity?.Intent?.PutExtra(guidExtra, data.Id);

            Activity?.StartActivityForResult(intent, requestCode);

            return data.TaskCompletionSource.Task;
        }

        static IntermediateTask? GetIntermediateTask(string? guid, bool remove = false)
        {
            if (string.IsNullOrEmpty(guid))
                return null;

            if (remove)
            {
                pendingTasks.TryRemove(guid, out var removedTask);
                return removedTask;
            }

            pendingTasks.TryGetValue(guid, out var task);
            return task;
        }

        class IntermediateTask
        {
            public IntermediateTask(Action<Intent>? onResult)
            {
                Id = Guid.NewGuid().ToString();
                TaskCompletionSource = new TaskCompletionSource<Intent>();

                OnResult = onResult;
            }

            public string Id { get; }

            public TaskCompletionSource<Intent> TaskCompletionSource { get; }

            public Action<Intent>? OnResult { get; }
        }
    }
}

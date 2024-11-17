using AndroidX.Activity;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;

namespace MauiBlazorToolkit.Platform
{
    public class ActivityResultContractForResult<TActivityResultContract, TResult> where TActivityResultContract : ActivityResultContract, new() where TResult : Java.Lang.Object
    {
        protected ActivityResultLauncher? launcher;
        protected TaskCompletionSource<TResult>? tcs = null;

        public virtual void Register(ComponentActivity componentActivity)
        {
            var contract = new TActivityResultContract();
            var callback = new ActivityResultCallback<TResult>(result => tcs?.SetResult(result));
            launcher = componentActivity.RegisterForActivityResult(contract, callback);
        }

        public Task<TResult> Launch<T>(T request) where T : Java.Lang.Object
        {
            tcs = new TaskCompletionSource<TResult>();
            if (launcher is null)
            {
                tcs.SetCanceled();
                return tcs.Task;
            }

            try
            {
                launcher.Launch(request);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }

            return tcs.Task;
        }
    }
}

using AndroidX.Activity.Result;
using JavaObject = Java.Lang.Object;

#nullable disable
namespace MauiBlazorToolkit
{
    public class ActivityResultCallback<T> : JavaObject, IActivityResultCallback where T : JavaObject
    {
        readonly Action<T> _callback;

        public ActivityResultCallback(Action<T> callback) => _callback = callback;

        public void OnActivityResult(JavaObject result)
        {
            _callback(result as T);
        }
    }
}
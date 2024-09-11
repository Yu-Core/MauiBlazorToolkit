using Android.Content;
using System.Reflection;

#nullable disable
namespace MauiBlazorToolkit.Platform
{
    public class IntermediateActivity
    {
        static readonly Type intermediateActivityType = typeof(FileSystem).Assembly.GetType("Microsoft.Maui.ApplicationModel.IntermediateActivity") ?? throw new Exception("IntermediateActivity type not found.");
        static readonly MethodInfo startAsync = intermediateActivityType.GetMethod("StartAsync", BindingFlags.Public | BindingFlags.Static) ?? throw new Exception("StartAsync method not found.");

        public static Task<Intent> StartAsync(Intent intent, int requestCode, Action<Intent>? onCreate = null, Action<Intent>? onResult = null)
        {
            return startAsync.Invoke(null, [intent, requestCode, onCreate, onResult]) as Task<Intent>;
        }
    }
}

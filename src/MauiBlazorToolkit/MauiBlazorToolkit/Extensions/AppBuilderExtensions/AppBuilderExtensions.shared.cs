using MauiBlazorToolkit.Essentials;
using Microsoft.Maui.LifecycleEvents;
#if WINDOWS || MACCATALYST
using TitleBar = MauiBlazorToolkit.Platform.TitleBar;
#endif
#if ANDROID
using static AndroidX.Activity.Result.Contract.ActivityResultContracts;
using Android.App;
using Android.Content;
#endif

namespace MauiBlazorToolkit.Extensions
{
    /// <summary>
    /// Extensions for MauiAppBuilder
    /// </summary>
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseMauiBlazorToolkit(this MauiAppBuilder builder, Action<Options>? options = default)
        {
            options?.Invoke(new Options());

            builder.ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
                events.AddWindows(windows =>
                {
                    windows.OnWindowCreated((window) =>
                    {
                        if (Options.InternalTitleBar)
                        {
                            TitleBar.Initialize();
                        }
                    });
                });
#elif MACCATALYST
                events.AddiOS(ios =>
                {
                    ios.FinishedLaunching((window, args) =>
                    {
                        if (Options.InternalTitleBar)
                        {
                            TitleBar.Initialize();
                        }
                        return true;
                    });
                });
#elif ANDROID
                events.AddAndroid(android =>
                {
                    android.OnCreate((activity, bundle) =>
                    {
                        if (PickVisualMedia.InvokeIsPhotoPickerAvailable(activity) && activity is AndroidX.Activity.ComponentActivity componentActivity)
                        {
                            PickVisualMediaForResult.Default.Register(componentActivity);
                            PickMultipleVisualMediaForResult.Default.Register(componentActivity);
                        }
                    });
                    android.OnActivityResult((Activity activity, int requestCode, Result resultCode, Intent? data) =>
                    {
                        MauiBlazorToolkit.Platform.IntermediateActivity.OnActivityResult(requestCode, resultCode, data);
                    });
                });
#endif
            });


            return builder;
        }
    }
}
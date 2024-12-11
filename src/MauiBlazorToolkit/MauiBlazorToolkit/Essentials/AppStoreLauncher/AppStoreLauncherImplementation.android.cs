using Android.Content;
using AndroidUri = Android.Net.Uri;
using Application = Android.App.Application;
using Uri = System.Uri;

namespace MauiBlazorToolkit.Essentials
{
    internal sealed partial class AppStoreLauncherImplementation
    {
        static string InternalAppStoreAppUri(string appId)
            => $"market://details?id={appId}";

        static Task<bool> PlatformCanOpenAsync(string appId)
            => Launcher.CanOpenAsync(InternalAppStoreAppUri(appId));

        static Task<bool> PlatformOpenAsync(string appId)
        {
            var uri = new Uri(InternalAppStoreAppUri(appId));
            var intent = new Intent(Intent.ActionView, AndroidUri.Parse(uri.OriginalString));
            var chooserIntent = Intent.CreateChooser(intent, string.Empty);
            var flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
            chooserIntent!.SetFlags(flags);
            Application.Context.StartActivity(chooserIntent);
            return Task.FromResult(true);
        }
    }
}

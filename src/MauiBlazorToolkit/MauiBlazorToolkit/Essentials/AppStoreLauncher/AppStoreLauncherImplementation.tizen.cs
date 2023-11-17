namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        static string InternalAppStoreAppUri(string appId)
            => $"tizenstore://ProductDetail/{appId}";

        static Task<bool> PlatformCanOpenAsync(string appId) 
            => Launcher.CanOpenAsync(InternalAppStoreAppUri(appId));

        static Task<bool> PlatformOpenAsync(string appId) 
            => Launcher.OpenAsync(InternalAppStoreAppUri(appId));
    }
}

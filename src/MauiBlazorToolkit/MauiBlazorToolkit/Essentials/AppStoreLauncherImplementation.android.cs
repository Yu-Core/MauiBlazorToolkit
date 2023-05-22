namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public static string InternalAppStoreUri()
            => $"market://details?id={AppInfo.PackageName}";

        public static string InternalAppStoreUri(string appId)
            => $"market://details?id={appId}";
    }
}

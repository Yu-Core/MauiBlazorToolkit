namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public static string InternalAppStoreUri()
            => $"market://search";

        public static string InternalAppStoreUri(string appId)
            => $"market://details?id={appId}";
    }
}

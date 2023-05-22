namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public static string InternalAppStoreUri() => "ms-windows-store://home";

        public static string InternalAppStoreUri(string appId)
            => $"ms-windows-store://pdp/?ProductId={appId}";
    }
}

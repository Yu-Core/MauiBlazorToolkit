namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public string InternalAppStoreUri() => throw new NotSupportedException($"{nameof(InternalAppStoreUri)} is not supported");

        public string InternalAppStoreUri(string appId) => throw new NotSupportedException($"{nameof(InternalAppStoreUri)} is not supported");
    }
}

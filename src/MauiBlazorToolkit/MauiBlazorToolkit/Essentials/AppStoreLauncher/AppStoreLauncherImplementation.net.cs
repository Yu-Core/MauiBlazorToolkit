namespace MauiBlazorToolkit.Essentials
{
    internal sealed partial class AppStoreLauncherImplementation
    {
        static Task<bool> PlatformCanOpenAsync(string appId) => throw new NotSupportedException($"{nameof(PlatformCanOpenAsync)} is not supported");

        static Task<bool> PlatformOpenAsync(string appId) => throw new NotSupportedException($"{nameof(PlatformOpenAsync)} is not supported");
    }
}

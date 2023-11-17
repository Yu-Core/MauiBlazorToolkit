namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation : IAppStoreLauncher
    {
        public Task<bool> CanOpenAsync(string appId)
            => PlatformCanOpenAsync(appId);

        public Task<bool> OpenAsync(string appId)
            => PlatformOpenAsync(appId);

        public async Task<bool> TryOpenAsync(string appId)
        {
            var canOpen = await CanOpenAsync(appId);
            if (canOpen)
            {
                await OpenAsync(appId);
            }

            return canOpen;
        }
    }
}

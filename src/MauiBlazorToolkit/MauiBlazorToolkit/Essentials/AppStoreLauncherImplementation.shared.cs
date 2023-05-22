namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation : IAppStoreLauncher
    {
        public Task<bool> CanOpenAsync()
        {
            return Launcher.CanOpenAsync(InternalAppStoreUri());
        }

        public Task<bool> CanOpenAsync(string uri)
        {
            return Launcher.CanOpenAsync(InternalAppStoreUri(uri));
        }

        public Task<bool> OpenAsync()
        {
            return Launcher.OpenAsync(InternalAppStoreUri());
        }

        public Task<bool> OpenAsync(string uri)
        {
            return Launcher.OpenAsync(InternalAppStoreUri(uri));
        }

        public Task<bool> TryOpenAsync()
        {
            return Launcher.TryOpenAsync(InternalAppStoreUri());
        }

        public Task<bool> TryOpenAsync(string uri)
        {
            return Launcher.TryOpenAsync(InternalAppStoreUri(uri));
        }
    }
}

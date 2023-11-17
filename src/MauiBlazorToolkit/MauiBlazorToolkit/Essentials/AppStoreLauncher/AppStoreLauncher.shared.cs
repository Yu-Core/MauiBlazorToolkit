namespace MauiBlazorToolkit.Essentials
{
    public static class AppStoreLauncher
    {
        static readonly Lazy<IAppStoreLauncher> defaultImplementation = new(new AppStoreLauncherImplementation());

        public static IAppStoreLauncher Default => defaultImplementation.Value;

        public static Task<bool> OpenAsync(string appId) => Default.OpenAsync(appId);
        public static Task<bool> CanOpenAsync(string appId) => Default.CanOpenAsync(appId);
        public static Task<bool> TryOpenAsync(string appId) => Default.TryOpenAsync(appId);
    }
}

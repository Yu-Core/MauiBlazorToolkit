namespace MauiBlazorToolkit.Essentials
{
    public static class AppStoreLauncher
    {
        static Lazy<IAppStoreLauncher> defaultImplementation = new(new AppStoreLauncherImplementation());

        public static IAppStoreLauncher Default => defaultImplementation.Value;

        public static Task<bool> OpenAsync() => Default.OpenAsync();
        public static Task<bool> CanOpenAsync() => Default.CanOpenAsync();
        public static Task<bool> TryOpenAsync() => Default.TryOpenAsync();
        public static Task<bool> OpenAsync(string uri) => Default.OpenAsync(uri);
        public static Task<bool> CanOpenAsync(string uri) => Default.CanOpenAsync(uri);
        public static Task<bool> TryOpenAsync(string uri) => Default.TryOpenAsync(uri);
    }
}

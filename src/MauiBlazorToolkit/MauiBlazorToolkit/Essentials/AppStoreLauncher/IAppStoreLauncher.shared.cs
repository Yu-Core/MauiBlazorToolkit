namespace MauiBlazorToolkit.Essentials
{
    public interface IAppStoreLauncher
    {
        Task<bool> OpenAsync(string appId);
        Task<bool> CanOpenAsync(string appId);
        Task<bool> TryOpenAsync(string appId);
    }
}

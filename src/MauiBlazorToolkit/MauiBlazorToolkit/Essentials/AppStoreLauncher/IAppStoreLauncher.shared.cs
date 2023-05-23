namespace MauiBlazorToolkit.Essentials
{
    public interface IAppStoreLauncher
    {
        Task<bool> OpenAsync();
        Task<bool> CanOpenAsync();
        Task<bool> TryOpenAsync();
        Task<bool> OpenAsync(string uri);
        Task<bool> CanOpenAsync(string uri);
        Task<bool> TryOpenAsync(string uri);
    }
}

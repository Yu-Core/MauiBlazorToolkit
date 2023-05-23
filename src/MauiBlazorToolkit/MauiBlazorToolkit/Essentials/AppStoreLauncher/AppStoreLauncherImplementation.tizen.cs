namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public string InternalAppStoreUri() => "tizenstore://SellerApps";

        public string InternalAppStoreUri(string appId) 
            => $"tizenstore://ProductDetail/{appId}";
    }
}

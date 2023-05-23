using System;

namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class AppStoreLauncherImplementation
    {
        public static string InternalAppStoreUri() => "itms-apps://itunes.apple.com/app/id0";

        public static string InternalAppStoreUri(string appId)
            => $"itms-apps://itunes.apple.com/app/id{appId}";
    }
}

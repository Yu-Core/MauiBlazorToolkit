using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform
{
    [UnsupportedOSPlatform("Tizen")]
    static partial class WebViewSoftInputPatch
    {
        static void PlatformInitialize()
        {
            throw new NotSupportedException("Tizen does not currently support WebViewSoftInputPatch");
        }
    }
}

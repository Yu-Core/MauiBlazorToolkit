using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform
{
    [UnsupportedOSPlatform("Windows")]
    static partial class WebViewSoftInputPatch
    {
        static void PlatformInitialize()
        {
            throw new NotSupportedException("WinUI does not currently support WebViewSoftInputPatch");
        }
    }
}

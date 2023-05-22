using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform
{
    [UnsupportedOSPlatform("MacCatalyst")]
    static partial class WebViewSoftInputPatch
    {
        static void PlatformInitialize()
        {
            throw new NotSupportedException("Mac does not currently support WebViewSoftInputPatch");
        }
    }
}

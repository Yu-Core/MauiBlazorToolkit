using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform;

[UnsupportedOSPlatform("IOS")]
static partial class WebViewSoftInputPatch
{
    static void PlatformInitialize()
    {
        throw new NotSupportedException("IOS does not currently support WebViewSoftInputPatch");
    }
}

using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform
{
    static partial class WebViewSoftInputPatch
    {
        static void PlatformInitialize()
        {
            throw new NotSupportedException($"{nameof(PlatformInitialize)} does not currently support WebViewSoftInputPatch");
        }
    }
}

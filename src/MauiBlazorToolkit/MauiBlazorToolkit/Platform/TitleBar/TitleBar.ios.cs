using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform;

[UnsupportedOSPlatform("iOS")]
static partial class TitleBar
{
    static void PlatformSetColor(Color color)
    {
        throw new NotSupportedException("iOS does not currently support changing the iOS title bar color");
    }

    static void PlatformSetStyle(TitleBarStyle style)
    {
        throw new NotSupportedException("iOS does not currently support changing the iOS title bar color");
    }
}
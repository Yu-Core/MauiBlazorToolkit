using System.Runtime.Versioning;

namespace MauiBlazorToolKit.Platform;

[UnsupportedOSPlatform("Android")]
static partial class TitleBar
{
	static void PlatformSetColor(Color color)
	{
        throw new NotSupportedException("Android does not currently support changing the Android title bar color");
    }

	static void PlatformSetStyle(TitleBarStyle style)
	{
        throw new NotSupportedException("Android does not currently support changing the Android title bar color");
    }
}
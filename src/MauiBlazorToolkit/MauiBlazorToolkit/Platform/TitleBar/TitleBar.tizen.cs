using System.Runtime.Versioning;
using Microsoft.Maui.Platform;

namespace MauiBlazorToolKit.Platform;

[UnsupportedOSPlatform("Tizen")]
static partial class TitleBar
{
	static void PlatformSetColor(Color color)
	{
		throw new NotSupportedException("Tizen does not currently support changing the status bar color");
	}

	static void PlatformSetStyle(TitleBarStyle style)
	{
		throw new NotSupportedException("Tizen does not currently support changing the status bar color");
	}
}
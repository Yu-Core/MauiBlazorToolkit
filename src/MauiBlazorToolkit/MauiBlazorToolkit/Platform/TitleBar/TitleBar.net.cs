namespace MauiBlazorToolKit.Platform;

static partial class TitleBar
{
	static void PlatformSetColor(Color color) => throw new NotSupportedException($"{nameof(PlatformSetColor)} is only supported on net6.0-ios and net6.0-android and later");

	static void PlatformSetStyle(TitleBarStyle titleBarStyle) => throw new NotSupportedException($"{nameof(PlatformSetStyle)} is only supported on net6.0-ios and net6.0-android and later");
}
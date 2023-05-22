namespace MauiBlazorToolkit.Platform;

static partial class TitleBar
{
	static void PlatformSetColor(Color color) => throw new NotSupportedException($"{nameof(PlatformSetColor)} is only supported on windows and macos");

	static void PlatformSetStyle(TitleBarStyle titleBarStyle) => throw new NotSupportedException($"{nameof(PlatformSetStyle)} is only supported on windows and macos");
}
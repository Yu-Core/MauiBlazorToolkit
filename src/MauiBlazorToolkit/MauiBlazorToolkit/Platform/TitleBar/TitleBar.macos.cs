using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform;

[SupportedOSPlatform("MacCatalyst10.0"), UnsupportedOSPlatform("MacOS")]
static partial class TitleBar
{
    static UIKit.UIWindow? NativeWindow =>
        (UIKit.UIWindow?)Application.Current?.Windows.FirstOrDefault()?.Handler?.PlatformView;

    static ResourceDictionary? Resources => Application.Current?.Resources;
	static void PlatformSetColor(Color color)
	{
		if (Resources == null) return;
		Resources["PageBackgroundColor"] = color;
    }

	static void PlatformSetStyle(TitleBarStyle style)
	{
        if (Resources == null) return;
        var color = style switch
        {
            TitleBarStyle.Default => Colors.White,
            TitleBarStyle.LightContent => Colors.White,
            TitleBarStyle.DarkContent => Colors.Black,
            _ => throw new NotSupportedException($"{nameof(TitleBarStyle)} {style} is not yet supported on iOS")
        };
        Resources["PageBackgroundColor"] = color;
    }

    public static void Initialize()
    {
        if (NativeWindow == null) return;
        var titleBar = NativeWindow.WindowScene?.Titlebar;
        if (titleBar == null) return;
        titleBar.TitleVisibility = UIKit.UITitlebarTitleVisibility.Hidden;
    }
}
using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform;

[SupportedOSPlatform("MacCatalyst11.0"), UnsupportedOSPlatform("MacOS")]
static partial class TitleBar
{
    static UIKit.UIWindow? NativeWindow =>
        (UIKit.UIWindow?)Application.Current?.Windows.FirstOrDefault()?.Handler?.PlatformView;

    static ResourceDictionary? Resources => Application.Current?.Resources;

	static void PlatformSetColor(Color color)
	{
		if (Resources is null) return;
		Resources["PageBackgroundColor"] = color;
    }

	static void PlatformSetStyle(TitleBarStyle style)
	{
        if (Resources is null) return;
        var color = style switch
        {
            TitleBarStyle.Default => Colors.Black,
            TitleBarStyle.LightContent => Colors.White,
            TitleBarStyle.DarkContent => Colors.Black,
            _ => throw new NotSupportedException($"{nameof(TitleBarStyle)} {style} is not yet supported on MacCatalyst")
        };
        Resources["PrimaryTextColor"] = color;
    }

    public static void Initialize()
    {
        if (NativeWindow is null) return;
        var titleBar = NativeWindow.WindowScene?.Titlebar;
        if (titleBar is null) return;
        titleBar.TitleVisibility = UIKit.UITitlebarTitleVisibility.Hidden;
    }
}
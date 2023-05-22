using Microsoft.Maui.Platform;
using WinRT.Interop;
using System.Runtime.Versioning;
using PInvoke;
using static PInvoke.User32;

namespace MauiBlazorToolKit.Platform;

[SupportedOSPlatform("Windows")]
static partial class TitleBar
{
	static Microsoft.UI.Xaml.Window? NativeWindow =>
        (Microsoft.UI.Xaml.Window?)Application.Current?.Windows.FirstOrDefault()?.Handler?.PlatformView;
    static Microsoft.UI.Xaml.ResourceDictionary Resources =>
        Microsoft.UI.Xaml.Application.Current.Resources;

    static void PlatformSetColor(Color color)
	{
        Resources["WindowCaptionBackground"] = color.ToWindowsColor();
        Resources["WindowCaptionBackgroundDisabled"] = color.ToWindowsColor();
        TriggertTitleBarRepaint();
    }

	static void PlatformSetStyle(TitleBarStyle style)
	{
        var color = style switch
        {
            TitleBarStyle.Default => Colors.Black,
            TitleBarStyle.LightContent => Colors.Black,
            TitleBarStyle.DarkContent => Colors.White,
            _ => throw new NotSupportedException($"{nameof(TitleBarStyle)} {style} is not yet supported on iOS")
        };
        Resources["WindowCaptionForeground"] = color.ToWindowsColor();
        Resources["WindowCaptionForegroundDisabled"] = color.ToWindowsColor();
        TriggertTitleBarRepaint();
    }

    static void TriggertTitleBarRepaint()
    {
        if (NativeWindow is null)
        {
            return;
        }

        var hWnd = WindowNative.GetWindowHandle(NativeWindow);
        var activeWindow = User32.GetActiveWindow();
        if (hWnd == activeWindow)
        {
            User32.PostMessage(hWnd, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
            User32.PostMessage(hWnd, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
        }
        else
        {
            User32.PostMessage(hWnd, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
            User32.PostMessage(hWnd, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
        }
    }
}
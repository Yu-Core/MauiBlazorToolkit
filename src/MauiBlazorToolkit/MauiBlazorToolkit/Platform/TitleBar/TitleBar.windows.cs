using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml.Markup;
using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Platform;

[SupportedOSPlatform("Windows")]
static partial class TitleBar
{
	static Microsoft.UI.Xaml.Window? NativeWindow =>
        (Microsoft.UI.Xaml.Window?)Application.Current?.Windows.FirstOrDefault()?.Handler?.PlatformView;
    static Microsoft.UI.Xaml.ResourceDictionary Resources =>
        Microsoft.UI.Xaml.Application.Current.Resources;

    static void PlatformSetColor(Color color)
	{
        Resources["TitleBarBackground"] = color.ToWindowsColor();
        if (NativeWindow is not null && NativeWindow.Content is Microsoft.UI.Xaml.FrameworkElement fe)
        {
            var requestedTheme = fe.RequestedTheme;
            fe.RequestedTheme = Microsoft.UI.Xaml.ElementTheme.Light;
            fe.RequestedTheme = Microsoft.UI.Xaml.ElementTheme.Dark;
            fe.RequestedTheme = requestedTheme;
        }
    }

	static void PlatformSetStyle(TitleBarStyle style)
	{
        //图标颜色暂时无法更改
    }

    public static void Initialize()
    {
        string xaml = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Grid Background=\"{ThemeResource TitleBarBackground}\"></Grid></DataTemplate>";
        Microsoft.UI.Xaml.DataTemplate dataTemplate = (Microsoft.UI.Xaml.DataTemplate)XamlReader.Load(xaml);
        Resources["MauiAppTitleBarTemplate"] = dataTemplate;
    }
}
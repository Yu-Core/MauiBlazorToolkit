# MauiBlazorToolkit
English || [简体中文](/README.zh-CN.md)

The Maui Blazor toolbox encapsulates some Maui and Maui Blazor tool classes, such as changing the color of the title bar.

Imitated the [.NET MAUI Community Toolkit](https://github.com/CommunityToolkit/Maui). Thank you very much.

## Start
Install [Yu-Core.MauiBlazorToolkit](https://www.nuget.org/packages/Yu-Core.MauiBlazorToolkit) from NuGet

To use the MauiBlazor toolkit, you need to call the extension method in the file, as shown below: MauiProgram.cs

```Csharp
using MauiBlazorToolKit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			// Initialize the MAUI Blazor Toolkit by adding the below line of code
			.UseMauiBlazorToolkit()
			// After initializing the MAUI Blazor Toolkit, optionally add additional fonts
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Continue initializing your .NET MAUI App here

		return builder.Build();
	}
}
```

## TitleBarBehavior (Title Bar Color)

`TitleBarBehavior` allows you to customize the color and style of the device's title bar.
Note that it can only be used in Windows and Mac OS. If you want to change the status bar of Android and iOS, please refer to the [.NET MAUI Community Toolkit](https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/maui/behaviors/statusbar-behavior?tabs=ios)

#### Configuration

Modify ` MainPage.xaml`
```xaml
<ContentPage xmlns=" http://schemas.microsoft.com/dotnet/2021/maui "
			xmlns:x=" http://schemas.microsoft.com/winfx/2009/xaml "
			xmlns:mauiBlazorToolkit="clr-namespace:MauiBlazorToolkit.Behaviors;assembly=MauiBlazorToolkit"
			x:Class="MyLittleApp.MainPage">
	<ContentPage.Behaviors>
		<mauiBlazorToolkit:TitleBarBehavior TitleBarColor="#fff" TitleBarStyle="DarkContent"></mauiBlazorToolkit:TitleBarBehavior>
	</ContentPage.Behaviors>
</ContentPage>
```

Modify `MauiProgram.cs`

```csharp
	var builder = MauiApp.CreateBuilder();
	builder
	.UseMauiApp<App>()
	.UseMauiBlazorToolkit(options =>
	{
		options.TitleBar = true;
	})
```

#### Using

```csharp
using MauiBlazorToolKit.Platform

#if Windows || MacCatalyst
	TitleBar.SetColor(titleBarColor);
	TitleBar.SetStyle(TitleBarStyle.DarkContent);
#endif
```

> TitleBar.SetStyle() temporarily invalid, cannot change the text color of the button

## AppStoreLauncher (opens the default app store)
`AppStoreLauncher` allows you to open the default app store

The appId is the ProductId of the app in Windows

The appId is the bundle ID of the app in iOS/MacCatalyst

The appId is the package name of the app in Android

#### Using
```csharp
AppStoreLauncher.TryOpenAsync(appId);
```

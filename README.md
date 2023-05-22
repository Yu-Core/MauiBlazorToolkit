# MauiBlazorToolkit

MauiBlazor 工具箱，封装了一些 Maui 和 Maui Blazor 的工具类，例如标题栏颜色的更改。

参考并模仿了 [MAUI社区工具包](https://github.com/CommunityToolkit/Maui) ,在此特别感谢。

## 开始
若要使用 MauiBlazor 工具箱，需要在文件中调用扩展方法，如下所示：MauiProgram.cs
```Csharp
using MauiBlazorToolKit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			// Initialize the Yu-Core MAUI Blazor Toolkit by adding the below line of code
			.UseMauiBlazorToolKit()
			// After initializing the Yu-Core MAUI Blazor Toolkit, optionally add additional fonts
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

## TitleBarBehavior
`TitleBarBehavior` 允许你自定义设备标题栏的颜色和样式。

#### 配置
一般是修改 `MainPage.xaml`
```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mauiBlazorToolkit="clr-namespace:MauiBlazorToolKit.Behaviors;assembly=MauiBlazorToolkit"
             x:Class="MyLittleApp.MainPage">
    
    <ContentPage.Behaviors>
       <mauiBlazorToolkit:TitleBarBehavior TitleBarColor="#fff" TitleBarStyle="LightContent"></mauiBlazorToolkit:TitleBarBehavior>
    </ContentPage.Behaviors>

</ContentPage>
```

#### 使用

```Csharp
using MauiBlazorToolKit.Platform

TitleBar.SetColor(titleBarColor);
TitleBar.SetStyle(TitleBarStyle.LightContent);
```

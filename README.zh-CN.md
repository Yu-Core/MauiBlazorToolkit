# MauiBlazorToolkit
[English](/README.md) || 简体中文

MauiBlazor 工具箱，封装了一些 Maui 和 Maui Blazor 的工具类，例如标题栏颜色的更改。

参考并模仿了 [.NET MAUI社区工具包](https://github.com/CommunityToolkit/Maui) ,在此特别感谢。

## 开始
从 Nuget 安装 [Yu-Core.MauiBlazorToolkit](https://www.nuget.org/packages/Yu-Core.MauiBlazorToolkit)

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

## TitleBarBehavior(标题栏颜色)
`TitleBarBehavior` 允许你自定义设备标题栏的颜色和样式。

注意，只能在Windows和mac OS中使用。如果想改变Android和iOS的状态栏请查看 [.NET MAUI社区工具包](https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/maui/behaviors/statusbar-behavior?tabs=ios)

#### 配置
修改 `MainPage.xaml`
```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:mauiBlazorToolkit="clr-namespace:MauiBlazorToolkit.Behaviors;assembly=MauiBlazorToolkit"
             x:Class="MyLittleApp.MainPage">
    
    <ContentPage.Behaviors>
       <mauiBlazorToolkit:TitleBarBehavior TitleBarColor="#fff" TitleBarStyle="DarkContent"></mauiBlazorToolkit:TitleBarBehavior>
    </ContentPage.Behaviors>

</ContentPage>
```

修改 `MauiProgram.cs`
```csharp
var builder = MauiApp.CreateBuilder();
builder
	.UseMauiApp<App>()
	.UseMauiBlazorToolkit(options =>
	{
		options.TitleBar = true;
	})
```

#### 使用

```csharp
using MauiBlazorToolKit.Platform

#if Windows || MacCatalyst
	TitleBar.SetColor(titleBarColor);
	TitleBar.SetStyle(TitleBarStyle.DarkContent);
#endif
```

## AppStoreLauncher(打开默认应用商店)
`AppStoreLauncher` 允许你打开默认的应用商店

appId 在 Windows 中为 App 的 ProductId

appId 在 iOS/MacCatalyst 中为 App 的 bundle ID

appId 在 Android 中为 App 的包名

#### 使用
```csharp
AppStoreLauncher.TryOpenAsync(appId);
```

## MediaFilePicker(媒体文件选择器)
`MediaFilePicker` 允许你单选或多选媒体文件
注意，只能在Android和iOS中使用。

#### 使用

```csharp
using MauiBlazorToolkit.Essentials

#if Android || iOS
	FileResult? photoFileResult = await MediaFilePicker.Default.PickPhotoAsync();
	FileResult? videoFileResult = await MediaFilePicker.Default.PickVideoAsync();
	IEnumerable<FileResult>? photoFileResults = await MediaFilePicker.Default.PickMultiplePhotoAsync();
	IEnumerable<FileResult>? videoFileResults = await MediaFilePicker.Default.PickMultipleVideoAsync();
#endif
```

## AndroidFilePicker(安卓文件选择器)
`AndroidFilePicker` MAUI Essentials中的FilePicker的改进，选择时有更多的选项
注意，只能在Android中使用，并且未来可能删除

#### 使用

```csharp
using MauiBlazorToolkit.Essentials

#if Android
	FileResult? fileResult = await AndroidFilePicker.Default.PickAsync();
	IEnumerable<FileResult>? fileResults = await AndroidFilePicker.Default.PickMultipleAsync();
#endif
```

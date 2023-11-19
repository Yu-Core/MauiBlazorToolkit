# MauiBlazorToolkit
[English](/README.md) || ��������

MauiBlazor �����䣬��װ��һЩ Maui �� Maui Blazor �Ĺ����࣬�����������ɫ�ĸ��ġ�

�ο���ģ���� [.NET MAUI�������߰�](https://github.com/CommunityToolkit/Maui) ,�ڴ��ر��л��

## ��ʼ
�� Nuget ��װ [Yu-Core.MauiBlazorToolkit](https://www.nuget.org/packages/Yu-Core.MauiBlazorToolkit)

��Ҫʹ�� MauiBlazor �����䣬��Ҫ���ļ��е�����չ������������ʾ��MauiProgram.cs

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

## TitleBarBehavior(��������ɫ)
`TitleBarBehavior` �������Զ����豸����������ɫ����ʽ��

ע�⣬ֻ����Windows��mac OS��ʹ�á������ı�Android��iOS��״̬����鿴 [.NET MAUI�������߰�](https://learn.microsoft.com/zh-cn/dotnet/communitytoolkit/maui/behaviors/statusbar-behavior?tabs=ios)

#### ����
�޸� `MainPage.xaml`
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

�޸� `MauiProgram.cs`
```csharp
var builder = MauiApp.CreateBuilder();
builder
	.UseMauiApp<App>()
	.UseMauiBlazorToolkit(options =>
	{
		options.TitleBar = true;
	})
```

#### ʹ��

```csharp
using MauiBlazorToolKit.Platform

#if Windows || MacCatalyst
	TitleBar.SetColor(titleBarColor);
	TitleBar.SetStyle(TitleBarStyle.DarkContent);
#endif
```

> TitleBar.SetStyle() ��ʱ��Ч�����ܸı䰴ť���ı���ɫ

## WebViewSoftInputPatch(������ڵ�����)
`WebViewSoftInputPatch` �����������̲����ڵ������

ע�⣬ֻ���� Android ����Ч��ֻ����� Maui Blazor

#### ����
�޸� `MauiProgram.cs`
```csharp
var builder = MauiApp.CreateBuilder();
builder
	.UseMauiApp<App>()
	.UseMauiBlazorToolkit(options =>
	{
		options.WebViewSoftInputPatch = true;
	})
```
## AppStoreLauncher(��Ĭ��Ӧ���̵�)
`AppStoreLauncher` �������Ĭ�ϵ�Ӧ���̵�

appId �� Windows ��Ϊ App �� ProductId

appId �� iOS/MacCatalyst ��Ϊ App �� bundle ID

appId �� Android ��Ϊ App �İ���
#### ʹ��
```csharp
AppStoreLauncher.TryOpenAsync(appId);
```

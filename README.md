# MauiBlazorToolkit

MauiBlazor �����䣬��װ��һЩ Maui �� Maui Blazor �Ĺ����࣬�����������ɫ�ĸ��ġ�

�ο���ģ���� [MAUI�������߰�](https://github.com/CommunityToolkit/Maui) ,�ڴ��ر��л��

## ��ʼ
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
`TitleBarBehavior` �������Զ����豸����������ɫ����ʽ��

#### ����
һ�����޸� `MainPage.xaml`
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

#### ʹ��

```Csharp
using MauiBlazorToolKit.Platform

TitleBar.SetColor(titleBarColor);
TitleBar.SetStyle(TitleBarStyle.LightContent);
```

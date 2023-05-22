Yu-Core MAUI Blazor Toolkit

## Initializing

In order to use the Yu-Core MAUI Blazor Toolkit you need to call the extension method in your `MauiProgram.cs` file as follows:

```csharp
using MauiBlazorToolkit;

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

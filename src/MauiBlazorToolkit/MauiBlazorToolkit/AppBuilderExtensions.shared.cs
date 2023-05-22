using Microsoft.Maui.LifecycleEvents;
using MauiBlazorToolKit.Platform;

namespace MauiBlazorToolKit;

/// <summary>
/// Extensions for MauiAppBuilder
/// </summary>
public static class AppBuilderExtensions
{
	public static MauiAppBuilder UseMauiBlazorToolkit(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events =>
         {
#if MACCATALYST
             events.AddiOS(ios => ios
                  .FinishedLaunching((window, args) => {
                      TitleBar.Initialize();
                      return true;
                  }));
#endif
         });


        return builder;
	}
}
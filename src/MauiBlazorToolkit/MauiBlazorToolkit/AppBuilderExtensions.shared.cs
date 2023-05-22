using Microsoft.Maui.LifecycleEvents;
using MauiBlazorToolkit.Platform;

namespace MauiBlazorToolkit;

/// <summary>
/// Extensions for MauiAppBuilder
/// </summary>
public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiBlazorToolkit(this MauiAppBuilder builder, Action<Options>? options = default)
    {
        options?.Invoke(new Options());

        builder.ConfigureLifecycleEvents(events =>
         {
#if MACCATALYST
             events.AddiOS(ios => ios
                  .FinishedLaunching((window, args) => {
                      TitleBar.Initialize();
                      return true;
                  })
             );
#elif ANDROID
             events.AddAndroid(android => android
                  .OnPostCreate((window,args)=>{
                      if(Options.InternalWebViewSoftInput) {
                         WebViewSoftInputPatch.Initialize();
                      }
                  })
             
             );
#endif
         });


        return builder;
    }
}
using Microsoft.Extensions.Logging;

namespace MauiBlazorToolkit.Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiBlazorToolkit(options =>
                {
                    options.HiddenMacTitleVisibility = true;
                    options.WebViewSoftInputPatch = true;
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
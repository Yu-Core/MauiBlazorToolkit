
using MauiBlazorToolkit.Extensions;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using TitleBar = MauiBlazorToolkit.Platform.TitleBar;

namespace MauiBlazorToolkit.Behaviors;

/// <summary>
/// <see cref="PlatformBehavior{TView,TPlatformView}"/> that controls the Title bar color
/// </summary>
[UnsupportedOSPlatform("Android"), UnsupportedOSPlatform("iOS"), UnsupportedOSPlatform("Tizen")]
public class TitleBarBehavior : PlatformBehavior<Page>
{
    /// <summary>
    /// <see cref="BindableProperty"/> that manages the TitleBarColor property.
    /// </summary>
    public static readonly BindableProperty TitleBarColorProperty =
        BindableProperty.Create(nameof(TitleBarColor), typeof(Color), typeof(TitleBarBehavior), Colors.Transparent);


    /// <summary>
    /// <see cref="BindableProperty"/> that manages the TitleBarColor property.
    /// </summary>
    public static readonly BindableProperty TitleBarStyleProperty =
        BindableProperty.Create(nameof(TitleBarStyle), typeof(TitleBarStyle), typeof(TitleBarBehavior), TitleBarStyle.Default);

    /// <summary>
    /// Property that holds the value of the Title bar color. 
    /// </summary>
    public Color TitleBarColor
    {
        get => (Color)GetValue(TitleBarColorProperty);
        set => SetValue(TitleBarColorProperty, value);
    }

    /// <summary>
    /// Property that holds the value of the Title bar color. 
    /// </summary>
    public TitleBarStyle TitleBarStyle
    {
        get => (TitleBarStyle)GetValue(TitleBarStyleProperty);
        set => SetValue(TitleBarStyleProperty, value);
    }

#if !(ANDROID || IOS || TIZEN)

    /// <inheritdoc /> 
#if WINDOWS
    protected override void OnAttachedTo(Page bindable, Microsoft.UI.Xaml.FrameworkElement platformView)
#elif MACCATALYST
	protected override void OnAttachedTo(Page bindable, UIKit.UIView platformView)
#else
	protected override void OnAttachedTo(Page bindable, object platformView)
#endif
    {
        TitleBar.SetColor(TitleBarColor);
        TitleBar.SetStyle(TitleBarStyle);
    }


    /// <inheritdoc /> 
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return;
        }

        if (propertyName.IsOneOf(TitleBarColorProperty, VisualElement.WidthProperty, VisualElement.HeightProperty))
        {
            TitleBar.SetColor(TitleBarColor);
        }
        else if (propertyName == TitleBarStyleProperty.PropertyName)
        {
            TitleBar.SetStyle(TitleBarStyle);
        }
    }
#endif
}
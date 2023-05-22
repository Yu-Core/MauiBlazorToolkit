
using MauiBlazorToolKit.Extensions;
using MauiBlazorToolKit.Platform;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace MauiBlazorToolKit.Behaviors;

/// <summary>
/// <see cref="PlatformBehavior{TView,TPlatformView}"/> that controls the Status bar color
/// </summary>
[UnsupportedOSPlatform("Android"), UnsupportedOSPlatform("iOS"), UnsupportedOSPlatform("Tizen")]
public class TitleBarBehavior : PlatformBehavior<Page>
{
	/// <summary>
	/// <see cref="BindableProperty"/> that manages the TitleBarColor property.
	/// </summary>
	public static readonly BindableProperty StatusBarColorProperty =
		BindableProperty.Create(nameof(TitleBarColor), typeof(Color), typeof(TitleBarBehavior), Colors.Transparent);


	/// <summary>
	/// <see cref="BindableProperty"/> that manages the TitleBarColor property.
	/// </summary>
	public static readonly BindableProperty StatusBarStyleProperty =
		BindableProperty.Create(nameof(TitleBarStyle), typeof(TitleBarStyle), typeof(TitleBarBehavior), TitleBarStyle.Default);

	/// <summary>
	/// Property that holds the value of the Status bar color. 
	/// </summary>
	public Color TitleBarColor
	{
		get => (Color)GetValue(StatusBarColorProperty);
		set => SetValue(StatusBarColorProperty, value);
	}

	/// <summary>
	/// Property that holds the value of the Status bar color. 
	/// </summary>
	public TitleBarStyle TitleBarStyle
	{
		get => (TitleBarStyle)GetValue(StatusBarStyleProperty);
		set => SetValue(StatusBarStyleProperty, value); 
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

		if (propertyName.IsOneOf(StatusBarColorProperty, VisualElement.WidthProperty, VisualElement.HeightProperty))
		{
			TitleBar.SetColor(TitleBarColor);
		}
		else if (propertyName == StatusBarStyleProperty.PropertyName)
		{
			TitleBar.SetStyle(TitleBarStyle);
		}
	}
#endif
}
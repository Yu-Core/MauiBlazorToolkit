namespace MauiBlazorToolkit.Platform;

/// <summary>
/// Class that hold the method to customize the TitleBar
/// </summary>
public static partial class TitleBar
{
	/// <summary>
	/// Method to change the color of the status bar.
	/// </summary>
	/// <param name="color">The <see cref="Color"/> that will be set to the status bar.</param>
	public static void SetColor(Color? color) =>
		PlatformSetColor(color ?? Colors.Transparent);

    /// <summary>
    /// Method to change the style of the status bar.
    /// </summary>
    /// <param name="titleBarStyle"> The <see cref="TitleBarStyle"/> that will used by status bar.</param>
    public static void SetStyle(TitleBarStyle titleBarStyle) =>
		PlatformSetStyle(titleBarStyle);
}
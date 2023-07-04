using Android.Content.Res;
using Android.Views;
using Android.Widget;
using System.Runtime.Versioning;
using static Android.Resource;
using Activity = Android.App.Activity;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

namespace MauiBlazorToolkit.Platform;

[SupportedOSPlatform("Android")]
static partial class WebViewSoftInputPatch
{
    static Activity Activity => Microsoft.Maui.ApplicationModel.Platform.CurrentActivity ?? throw new InvalidOperationException("Android Activity can't be null.");
    static View? MChildOfContent;
    static FrameLayout.LayoutParams? FrameLayoutParams;
    static int UsableHeightPrevious = 0;

    static void PlatformInitialize()
    {
        FrameLayout? content = (FrameLayout?)Activity.FindViewById(Id.Content);
        MChildOfContent = content?.GetChildAt(0);
        if (MChildOfContent?.ViewTreeObserver == null) return;
        MChildOfContent.ViewTreeObserver.GlobalLayout += (s, o) => PossiblyResizeChildOfContent();
        FrameLayoutParams = (FrameLayout.LayoutParams?)MChildOfContent?.LayoutParameters;
    }

    static void PossiblyResizeChildOfContent()
    {
        if (MChildOfContent?.RootView == null) return;
        if (FrameLayoutParams == null) return;

        int usableHeightNow = ComputeUsableHeight();
        if (usableHeightNow != UsableHeightPrevious)
        {
            int usableHeightSansKeyboard = MChildOfContent.RootView.Height;
            int heightDifference = usableHeightSansKeyboard - usableHeightNow;
            if (heightDifference < 0)
            {
                usableHeightSansKeyboard = MChildOfContent.RootView.Width;
                heightDifference = usableHeightSansKeyboard - usableHeightNow;
            }

            if (heightDifference > usableHeightSansKeyboard / 4)
            {
                FrameLayoutParams.Height = usableHeightSansKeyboard - heightDifference;
            }
            else
            {
                FrameLayoutParams.Height = usableHeightNow;
            }
        }

        MChildOfContent?.RequestLayout();
        UsableHeightPrevious = usableHeightNow;
    }

    static int ComputeUsableHeight()
    {
        Rect rect = new Rect();
        MChildOfContent?.GetWindowVisibleDisplayFrame(rect);
        if(IsImmersiveMode())
        {
            return rect.Bottom;
        }
        else
        {
            return rect.Bottom - GetStatusBarHeight();
        }
    }

    static int GetStatusBarHeight()
    {
        int result = 0;
        Resources resources = Activity.Resources ?? throw new InvalidOperationException("Activity Resources can't be null.");
        int resourceId = resources.GetIdentifier("status_bar_height", "dimen", "android");
        if (resourceId > 0)
        {
            result = resources.GetDimensionPixelSize(resourceId);
        }
        return result;
    }

    static bool IsImmersiveMode()
    {
        var window = Activity.Window ?? throw new InvalidOperationException("Activity Window can't be null.");
        View decorView = window.DecorView;
        int uiOptions = (int)decorView.SystemUiVisibility;
        return (uiOptions & (int)SystemUiFlags.Immersive) == (int)SystemUiFlags.Immersive;
    }
}

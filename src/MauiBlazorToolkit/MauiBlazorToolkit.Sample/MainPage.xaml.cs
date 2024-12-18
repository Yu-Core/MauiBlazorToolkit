namespace MauiBlazorToolkit.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
#if ANDROID
            if (OperatingSystem.IsAndroidVersionAtLeast(35))
            {
                this.Padding = new Thickness(Padding.Left, 48, Padding.Right, Padding.Bottom);
            }
#endif
        }
    }
}
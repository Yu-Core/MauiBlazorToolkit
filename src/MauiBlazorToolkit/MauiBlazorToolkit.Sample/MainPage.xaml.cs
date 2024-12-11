namespace MauiBlazorToolkit.Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
#if ANDROID35_0_OR_GREATER
            this.Padding = new Thickness(Padding.Left, 48, Padding.Right, Padding.Bottom);
#endif
        }
    }
}
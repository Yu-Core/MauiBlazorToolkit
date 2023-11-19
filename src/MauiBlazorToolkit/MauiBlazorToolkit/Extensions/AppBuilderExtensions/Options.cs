namespace MauiBlazorToolkit.Extensions
{
    public class Options
    {
        internal static bool InternalTitleBar { get; private set; }

        public bool TitleBar
        {
            get => InternalTitleBar;
            set => InternalTitleBar = value;
        }
    }
}

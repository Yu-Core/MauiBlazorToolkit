namespace MauiBlazorToolkit.Essentials
{
    public static class AndroidFilePicker
    {
        static readonly Lazy<IAndroidFilePicker> defaultImplementation = new(new AndroidFilePickerImplementation());

        public static IAndroidFilePicker Default => defaultImplementation.Value;

        public static Task<FileResult?> PickAsync(PickOptions? options = null)
            => Default.PickAsync(options);

        public static Task<IEnumerable<FileResult>> PickMultipleAsync(PickOptions? options = null)
            => Default.PickMultipleAsync(options);
    }
}

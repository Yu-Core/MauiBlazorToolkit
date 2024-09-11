namespace MauiBlazorToolkit.Essentials
{
    public static class MediaFilePicker
    {
        static readonly Lazy<IMediaFilePicker> defaultImplementation = new(new MediaFilePickerImplementation());

        public static IMediaFilePicker Default => defaultImplementation.Value;

        public static Task<IEnumerable<FileResult>?> PickMultiplePhotoAsync()
            => Default.PickMultiplePhotoAsync();

        public static Task<IEnumerable<FileResult>?> PickMultipleVideoAsync()
            => Default.PickMultipleVideoAsync();

        public static Task<FileResult?> PickPhotoAsync()
             => Default.PickPhotoAsync();

        public static Task<FileResult?> PickVideoAsync()
            => Default.PickVideoAsync();
    }
}

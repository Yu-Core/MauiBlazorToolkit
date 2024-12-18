namespace MauiBlazorToolkit.Essentials
{
    public partial class MediaFilePicker
    {
        public static Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync(bool usePhotoPicker = false)
             => MediaFilePickerImplementation.PlatformPickMultiplePhotoAsync(usePhotoPicker);

        public static Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync(bool usePhotoPicker = false)
             => MediaFilePickerImplementation.PlatformPickMultipleVideoAsync(usePhotoPicker);

        public static Task<FileResult?> PlatformPickPhotoAsync(bool usePhotoPicker = false)
            => MediaFilePickerImplementation.PlatformPickPhotoAsync(usePhotoPicker);

        public static Task<FileResult?> PlatformPickVideoAsync(bool usePhotoPicker = false)
            => MediaFilePickerImplementation.PlatformPickVideoAsync(usePhotoPicker);

    }
}

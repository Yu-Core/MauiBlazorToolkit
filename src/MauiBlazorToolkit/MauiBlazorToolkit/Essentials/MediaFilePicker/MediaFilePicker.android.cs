namespace MauiBlazorToolkit.Essentials
{
    public partial class MediaFilePicker
    {
        public static Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync(bool usePhotoPicker = true)
             => MediaFilePickerImplementation.PlatformPickMultiplePhotoAsync(usePhotoPicker);

        public static Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync(bool usePhotoPicker = true)
             => MediaFilePickerImplementation.PlatformPickMultipleVideoAsync(usePhotoPicker);

        public static Task<FileResult?> PlatformPickPhotoAsync(bool usePhotoPicker = true)
            => MediaFilePickerImplementation.PlatformPickPhotoAsync(usePhotoPicker);

        public static Task<FileResult?> PlatformPickVideoAsync(bool usePhotoPicker = true)
            => MediaFilePickerImplementation.PlatformPickVideoAsync(usePhotoPicker);

    }
}

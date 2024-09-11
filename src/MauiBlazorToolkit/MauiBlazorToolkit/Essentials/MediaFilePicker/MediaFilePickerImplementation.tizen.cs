namespace MauiBlazorToolkit.Essentials
{
    [UnsupportedOSPlatform("Tizen")]
    public sealed partial class MediaFilePickerImplementation
    {
        public Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultiplePhotoAsync)} is not supported on Tizen");

        public Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultipleVideoAsync)} is not supported on Tizen");

        public Task<FileResult?> PlatformPickPhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickPhotoAsync)} is not supported on Tizen");

        public Task<FileResult?> PlatformPickVideoAsync()
            => throw new NotSupportedException($"{nameof(PlatformPickVideoAsync)} is not supported on Tizen");
    }
}

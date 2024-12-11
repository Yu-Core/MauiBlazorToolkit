namespace MauiBlazorToolkit.Essentials
{
    internal sealed partial class MediaFilePickerImplementation
    {
        public Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultiplePhotoAsync)} is not supported");

        public Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultipleVideoAsync)} is not supported");

        public Task<FileResult?> PlatformPickPhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickPhotoAsync)} is not supported");

        public Task<FileResult?> PlatformPickVideoAsync()
            => throw new NotSupportedException($"{nameof(PlatformPickVideoAsync)} is not supported");
    }
}

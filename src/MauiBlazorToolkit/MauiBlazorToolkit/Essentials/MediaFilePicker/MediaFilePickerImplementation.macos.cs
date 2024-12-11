using System.Runtime.Versioning;

namespace MauiBlazorToolkit.Essentials
{
    [UnsupportedOSPlatform("MacCatalyst")]
    internal partial class MediaFilePickerImplementation
    {
        public Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultiplePhotoAsync)} is not supported on MacCatalyst");

        public Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickMultipleVideoAsync)} is not supported on MacCatalyst");

        public Task<FileResult?> PlatformPickPhotoAsync()
             => throw new NotSupportedException($"{nameof(PlatformPickPhotoAsync)} is not supported on MacCatalyst");

        public Task<FileResult?> PlatformPickVideoAsync()
            => throw new NotSupportedException($"{nameof(PlatformPickVideoAsync)} is not supported on MacCatalyst");
    }
}

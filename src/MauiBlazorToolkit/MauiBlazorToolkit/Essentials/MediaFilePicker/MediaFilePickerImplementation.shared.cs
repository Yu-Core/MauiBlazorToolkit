
namespace MauiBlazorToolkit.Essentials
{
    public sealed partial class MediaFilePickerImplementation : IMediaFilePicker
    {
        public Task<IEnumerable<FileResult>?> PickMultiplePhotoAsync()
            => PlatformPickMultiplePhotoAsync();

        public Task<IEnumerable<FileResult>?> PickMultipleVideoAsync()
            => PlatformPickMultipleVideoAsync();

        public Task<FileResult?> PickPhotoAsync()
             => PlatformPickPhotoAsync();

        public Task<FileResult?> PickVideoAsync()
            => PlatformPickVideoAsync();
    }
}

namespace MauiBlazorToolkit.Essentials
{
    public interface IMediaFilePicker
    {
        Task<FileResult?> PickPhotoAsync();

        Task<IEnumerable<FileResult>?> PickMultiplePhotoAsync();

        Task<FileResult?> PickVideoAsync();

        Task<IEnumerable<FileResult>?> PickMultipleVideoAsync();
    }
}

using Android.Content;
using MauiBlazorToolkit.Extensions;
using MauiBlazorToolkit.Platform;

namespace MauiBlazorToolkit.Essentials
{
    public class AndroidFilePickerImplementation : IAndroidFilePicker
    {
        public async Task<FileResult?> PickAsync(PickOptions? options = null)
            => (await PlatformPickAsync(options))?.FirstOrDefault();

        public Task<IEnumerable<FileResult>> PickMultipleAsync(PickOptions? options = null)
            => PlatformPickAsync(options ?? PickOptions.Default, true);

        async Task<IEnumerable<FileResult>> PlatformPickAsync(PickOptions? options, bool allowMultiple = false)
        {
            // Essentials supports >= API 19 where this action is available
            var action = Intent.ActionGetContent;

            var intent = new Intent(action);
            intent.SetType(FileMimeTypes.All);
            intent.PutExtra(Intent.ExtraAllowMultiple, allowMultiple);

            var allowedTypes = options?.FileTypes?.Value?.ToArray();
            if (allowedTypes?.Length > 0)
                intent.PutExtra(Intent.ExtraMimeTypes, allowedTypes);

            try
            {
                var resultList = new List<FileResult>();
                void OnResult(Intent intent)
                {
                    // The uri returned is only temporary and only lives as long as the Activity that requested it,
                    // so this means that it will always be cleaned up by the time we need it because we are using
                    // an intermediate activity.

                    if (intent.ClipData == null)
                    {
                        var path = FileSystemUtils.EnsurePhysicalPath(intent.Data);
                        resultList.Add(new FileResult(path));
                    }
                    else
                    {
                        for (var i = 0; i < intent.ClipData.ItemCount; i++)
                        {
                            var uri = intent.ClipData.GetItemAt(i).Uri;
                            var path = FileSystemUtils.EnsurePhysicalPath(uri);
                            resultList.Add(new FileResult(path));
                        }
                    }
                }

                await IntermediateActivity.StartAsync(intent, PlatformUtils.requestCodeFilePicker, onResult: OnResult);

                return resultList;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }
    }
}

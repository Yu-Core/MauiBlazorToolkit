using Android.Content;
using Android.Runtime;
using AndroidX.Activity.Result;
using AndroidX.Activity.Result.Contract;
using MauiBlazorToolkit.Extensions;
using MauiBlazorToolkit.Platform;
using System.Runtime.Versioning;
using static AndroidX.Activity.Result.Contract.ActivityResultContracts;

namespace MauiBlazorToolkit.Essentials
{
    [SupportedOSPlatform("Android")]
    public sealed partial class MediaFilePickerImplementation
    {
        public static Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync()
             => PlatformPickMultipleAsync(true);

        public static Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync()
             => PlatformPickMultipleAsync(false);

        public static Task<FileResult?> PlatformPickPhotoAsync()
            => PlatformPickAsync(true);

        public static Task<FileResult?> PlatformPickVideoAsync()
            => PlatformPickAsync(false);

        private static PickVisualMediaRequest BuilderPickVisualMediaRequest(bool photo)
        {
            return new PickVisualMediaRequest.Builder()
                .SetMediaType(photo ? ActivityResultContracts.PickVisualMedia.ImageOnly.Instance : ActivityResultContracts.PickVisualMedia.VideoOnly.Instance)
                .Build();
        }

        private static async Task<FileResult?> PlatformPickAsync(bool photo)
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                return await PlatformPickAsync33Greater(photo);
            }
            else
            {
                var fileResults = await PlatformPickAsync33Below(photo);
                if (fileResults is null || fileResults.Count == 0)
                {
                    return null;
                }

                return fileResults[0];
            }
        }

        private static async Task<IEnumerable<FileResult>?> PlatformPickMultipleAsync(bool photo)
        {
            if (OperatingSystem.IsAndroidVersionAtLeast(33))
            {
                return await PlatformPickMultipleAsync33OrGreater(photo);
            }
            else
            {
                return await PlatformPickAsync33Below(photo, allowMultiple: true);
            }
        }

        private static async Task<FileResult?> PlatformPickAsync33Greater(bool photo)
        {
            var pickVisualMediaRequest = BuilderPickVisualMediaRequest(photo);
            var androidUri = await PickVisualMediaForResult.Default.Launch(pickVisualMediaRequest);
            if (androidUri is null)
            {
                return null;
            }

            var path = FileSystemUtils.EnsurePhysicalPath(androidUri);
            return new FileResult(path);
        }

        private static async Task<IEnumerable<FileResult>?> PlatformPickMultipleAsync33OrGreater(bool photo)
        {
            var pickVisualMediaRequest = BuilderPickVisualMediaRequest(photo);
            var list = await PickMultipleVisualMediaForResult.Default.Launch(pickVisualMediaRequest);
            if (list.IsEmpty)
            {
                return null;
            }

            var uris = list.Cast<Android.Net.Uri>().ToList();
            var fileResults = uris.Select(it => new FileResult(FileSystemUtils.EnsurePhysicalPath(it)));
            return fileResults;
        }

        private static async Task<List<FileResult>?> PlatformPickAsync33Below(bool photo, bool allowMultiple = false)
        {
            var intent = new Intent(Intent.ActionGetContent);
            intent.SetType(photo ? FileMimeTypes.ImageAll : FileMimeTypes.VideoAll);
            intent.PutExtra(Intent.ExtraAllowMultiple, allowMultiple);

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

                await IntermediateActivity.StartAsync(intent, PlatformUtils.requestCodeMediaPicker, onResult: OnResult);

                return resultList;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
        }
    }

    public class PickMultipleVisualMediaForResult : ActivityResultContractForResult<PickMultipleVisualMedia, JavaList>
    {
        private static readonly Lazy<PickMultipleVisualMediaForResult> _default = new(new PickMultipleVisualMediaForResult());

        public static PickMultipleVisualMediaForResult Default => _default.Value;
    }

    public class PickVisualMediaForResult : ActivityResultContractForResult<PickVisualMedia, Android.Net.Uri>
    {
        private static readonly Lazy<PickVisualMediaForResult> _default = new(new PickVisualMediaForResult());

        public static PickVisualMediaForResult Default => _default.Value;
    }
}

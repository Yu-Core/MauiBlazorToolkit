using Foundation;
using MobileCoreServices;
using PhotosUI;
using System.Runtime.Versioning;
using UIKit;

namespace MauiBlazorToolkit.Essentials
{
    [SupportedOSPlatform("iOS")]
    public sealed partial class MediaFilePickerImplementation
    {
        public static Task<IEnumerable<FileResult>?> PlatformPickMultiplePhotoAsync()
             => PlatformPickMultipAsync(true);

        public static Task<IEnumerable<FileResult>?> PlatformPickMultipleVideoAsync()
             => PlatformPickMultipAsync(false);

        public static Task<FileResult?> PlatformPickPhotoAsync()
            => PlatformPickAsync(true);

        public static Task<FileResult?> PlatformPickVideoAsync()
            => PlatformPickAsync(false);

        static async Task<FileResult?> PlatformPickAsync(bool photo)
        {
            var fileResults = await PlatformPickMultipAsync(photo, 1);
            if (fileResults is null || !fileResults.Any())
            {
                return null;
            }

            return fileResults.FirstOrDefault();
        }

        static async Task<IEnumerable<FileResult>?> PlatformPickMultipAsync(bool photo, int selectionLimit = 100)
        {
            if (OperatingSystem.IsIOSVersionAtLeast(14))
            {
                return await PlatformPickMultipAsync14OrGreater(photo, selectionLimit);
            }
            else
            {
                FileResult? fileResult;
                if (photo)
                {
                    fileResult = await MediaPicker.Default.PickPhotoAsync();
                }
                else
                {
                    fileResult = await MediaPicker.Default.PickVideoAsync();
                }

                if (fileResult is null)
                {
                    return null;
                }

                return [fileResult];
            }
        }

#nullable disable
        static UIViewController pickerRef;

        [SupportedOSPlatform("iOS14.0")]
        static async Task<IEnumerable<FileResult>> PlatformPickMultipAsync14OrGreater(bool photo, int selectionLimit)
        {
            try
            {
                var tcs = new TaskCompletionSource<IEnumerable<FileResult>>(TaskCreationOptions.RunContinuationsAsynchronously);

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    var config = new PHPickerConfiguration();
                    config.PreferredAssetRepresentationMode = PHPickerConfigurationAssetRepresentationMode.Current;
                    config.SelectionLimit = selectionLimit;

                    config.Filter = photo
                            ? PHPickerFilter.ImagesFilter
                            : PHPickerFilter.VideosFilter;

                    pickerRef = new PHPickerViewController(config)
                    {
                        Delegate = new PHPickerDelegate(tcs)
                    };

                    var vc = WindowStateManager.Default.GetCurrentUIViewController() ?? throw new NullReferenceException("The current view controller can not be detected.");
                    ConfigureController(pickerRef, tcs);

                    vc.PresentViewController(pickerRef, true, null);
                });

                return await tcs.Task.ConfigureAwait(false);
            }
            finally
            {
                pickerRef?.Dispose();
                pickerRef = null;
            }
        }

        static void ConfigureController(UIViewController controller, TaskCompletionSource<IEnumerable<FileResult>> tcs)
        {
            if (controller.PresentationController != null)
                controller.PresentationController.Delegate = new PresentatControllerDelegate(tcs);
        }

        [SupportedOSPlatform("iOS14.0")]
        class PHPickerDelegate : PHPickerViewControllerDelegate
        {
            readonly TaskCompletionSource<IEnumerable<FileResult>?> tcs;

            internal PHPickerDelegate(TaskCompletionSource<IEnumerable<FileResult>?> tcs)
                => this.tcs = tcs;

            public override async void DidFinishPicking(PHPickerViewController picker, PHPickerResult[] results)
            {
                picker.DismissViewController(true, null);
                tcs?.TrySetResult(results?.Length > 0 ? await ConvertPickerResults(results) : null);
            }

            static async Task<IEnumerable<FileResult>> ConvertPickerResults(PHPickerResult[] pickerResults)
            {
                var fileResults = new List<FileResult>();
                foreach (var item in pickerResults)
                {
                    var provider = item.ItemProvider;
                    if (provider != null && provider.RegisteredTypeIdentifiers?.Length > 0)
                    {
                        var fileResult = await ConvertNSItemProvider(provider);
                        fileResults.Add(fileResult);
                    }
                }

                return fileResults;
            }

            static async Task<FileResult> ConvertNSItemProvider(NSItemProvider provider)
            {
                var identifiers = provider.RegisteredTypeIdentifiers;
                var identifier = GetIdentifier(identifiers);

                var tcs = new TaskCompletionSource<FileResult>();
                provider.LoadFileRepresentation(identifier, (url, error) =>
                {
                    if (error != null)
                    {
                        tcs.TrySetException(new NSErrorException(error));
                        return;
                    }

                    var doc = new UIDocument(url);
                    var sourceFileName = doc.FileUrl.Path;
                    var filename = Path.GetFileName(sourceFileName);
                    var destFileName = GetTempFilePath(FileSystem.Current.CacheDirectory, filename);
                    File.Move(sourceFileName, destFileName);
                    var fileResult = new FileResult(destFileName);
                    tcs.SetResult(fileResult);
                });

                return await tcs.Task;
            }

            static string GetIdentifier(string[] identifiers)
            {
                if (!(identifiers?.Length > 0))
                    return null;
                if (identifiers.Any(i => i.StartsWith(UTType.LivePhoto)) && identifiers.Contains(UTType.JPEG))
                    return identifiers.FirstOrDefault(i => i == UTType.JPEG);
                if (identifiers.Contains(UTType.QuickTimeMovie))
                    return identifiers.FirstOrDefault(i => i == UTType.QuickTimeMovie);
                return identifiers.FirstOrDefault();
            }

            const string EssentialsFolderHash = "0d061080e23e4287ad67e535755df5f3";

            static string GetTempFilePath(string root, string fileName)
            {
                var rootDic = Path.Combine(root, EssentialsFolderHash);
                Directory.CreateDirectory(rootDic);
                var tempDic = Path.Combine(rootDic, Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(tempDic);
                var tempFilePath = Path.Combine(tempDic, fileName);
                return tempFilePath;
            }
        }

        class PresentatControllerDelegate : UIAdaptivePresentationControllerDelegate
        {
            readonly TaskCompletionSource<IEnumerable<FileResult>> tcs;

            internal PresentatControllerDelegate(TaskCompletionSource<IEnumerable<FileResult>> tcs)
                => this.tcs = tcs;

            public override void DidDismiss(UIPresentationController presentationController)
                => tcs?.TrySetResult(null);

            protected override void Dispose(bool disposing)
            {
                tcs?.TrySetResult(null);
                base.Dispose(disposing);
            }
        }
    }
}

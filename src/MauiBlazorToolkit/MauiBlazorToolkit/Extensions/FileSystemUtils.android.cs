#nullable disable
using Android.Provider;
using System.Reflection;
using AndroidUri = Android.Net.Uri;

namespace MauiBlazorToolkit.Extensions
{
    public static class FileSystemUtils
    {
        static readonly Type fileSystemUtilsType = typeof(FileSystem).Assembly.GetType("Microsoft.Maui.Storage.FileSystemUtils") ?? throw new Exception("FileSystemUtils type not found.");
        static readonly FieldInfo UriSchemeFileField = fileSystemUtilsType.GetField("UriSchemeFile", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static) ?? throw new Exception("Field UriSchemeFileField does not exist");
        static readonly string UriSchemeFile = UriSchemeFileField.GetValue(null) as string;
        static readonly MethodInfo ResolveDocumentPathMethod = fileSystemUtilsType.GetMethod("ResolveDocumentPath", BindingFlags.NonPublic | BindingFlags.Static) ?? throw new Exception("ResolveDocumentPath method not found.");
        static readonly MethodInfo CacheContentFileMethod = fileSystemUtilsType.GetMethod("CacheContentFile", BindingFlags.NonPublic | BindingFlags.Static) ?? throw new Exception("CacheContentFile method not found.");

        public static string EnsurePhysicalPath(AndroidUri uri)
        {
            // if this is a file, use that
            if (uri.Scheme.Equals(UriSchemeFile, StringComparison.OrdinalIgnoreCase))
                return uri.Path;

            // try resolve using the content provider
            var absolute = ResolvePhysicalPath(uri);
            if (!string.IsNullOrWhiteSpace(absolute) && Path.IsPathRooted(absolute))
                return absolute;

            // fall back to just copying it
            var cached = CacheContentFile(uri);
            if (!string.IsNullOrWhiteSpace(cached) && Path.IsPathRooted(cached))
                return cached;

            throw new FileNotFoundException($"Unable to resolve absolute path or retrieve contents of URI '{uri}'.");
        }

        static string ResolvePhysicalPath(AndroidUri uri, bool requireExtendedAccess = true)
        {
            if (uri.Scheme.Equals(UriSchemeFile, StringComparison.OrdinalIgnoreCase))
            {
                // if it is a file, then return directly

                var resolved = uri.Path;
                if (File.Exists(resolved))
                    return resolved;
            }
            else if (!requireExtendedAccess || !OperatingSystem.IsAndroidVersionAtLeast(29))
            {
                // if this is on an older OS version, or we just need it now

                if (OperatingSystem.IsAndroidVersionAtLeast(19) && DocumentsContract.IsDocumentUri(Android.App.Application.Context, uri))
                {
                    var resolved = ResolveDocumentPath(uri);
                    if (File.Exists(resolved))
                        return resolved;
                }
            }

            return null;
        }

        static string ResolveDocumentPath(AndroidUri uri)
        {
            return ResolveDocumentPathMethod.Invoke(null, [uri]) as string;
        }

        static string CacheContentFile(AndroidUri uri)
        {
            return CacheContentFileMethod.Invoke(null, [uri]) as string;
        }
    }
}

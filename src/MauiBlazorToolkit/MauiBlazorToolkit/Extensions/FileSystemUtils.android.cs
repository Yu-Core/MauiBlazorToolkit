using System.Reflection;

#nullable disable
namespace MauiBlazorToolkit.Extensions
{
    public static class FileSystemUtils
    {
        static readonly Type fileSystemUtilsType = typeof(FileSystem).Assembly.GetType("Microsoft.Maui.Storage.FileSystemUtils") ?? throw new Exception("FileSystemUtils type not found.");
        static readonly MethodInfo EnsurePhysicalPathMethod = fileSystemUtilsType.GetMethod("EnsurePhysicalPath", BindingFlags.Public | BindingFlags.Static) ?? throw new Exception("EnsurePhysicalPath method not found.");

        public static string EnsurePhysicalPath(Android.Net.Uri uri)
        {
            return EnsurePhysicalPathMethod.Invoke(null, [uri, true]) as string;
        }
    }
}

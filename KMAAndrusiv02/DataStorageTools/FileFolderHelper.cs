using System;
using System.IO;

namespace KMAAndrusiv02.DataStorageTools
{
    internal static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string AppFolderPath =
            Path.Combine(AppDataPath, "AndrusivCSharpKMA");

        internal static readonly string StorageFilePath =
            Path.Combine(AppFolderPath, "PersonStorage.cskma");

        internal static bool CreateFolderAndCheckFileExistence(string filePath)
        {
            var file = new FileInfo(filePath);
            return file.CreateFolderAndCheckFileExistence();
        }

        internal static bool CreateFolderAndCheckFileExistence(this FileInfo file)
        {
            if (file.Directory != null && !file.Directory.Exists)
            {
                file.Directory.Create();
            }
            return file.Exists;
        }
    }
}

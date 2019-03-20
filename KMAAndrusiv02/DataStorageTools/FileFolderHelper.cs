﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal static bool CreateFolderAndCheckFileExistance(string filePath)
        {
            var file = new FileInfo(filePath);
            return file.CreateFolderAndCheckFileExistance();
        }

        internal static bool CreateFolderAndCheckFileExistance(this FileInfo file)
        {
            if (!file.Directory.Exists)
            {
                file.Directory.Create();
            }
            return file.Exists;
        }
    }
}

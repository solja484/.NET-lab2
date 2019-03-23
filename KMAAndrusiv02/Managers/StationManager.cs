using System;
using System.Windows;
using KMAAndrusiv02.DataStorageTools;

namespace KMAAndrusiv02.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentUser { get; set; }

        internal static IDataStorage DataStorage { get; private set; }

        internal static void Initialize(IDataStorage dataStorage)
        {
            DataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("Shut down");
            Environment.Exit(1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KMAAndrusiv02.DataStorageTools;

namespace KMAAndrusiv02
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
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
using System.ComponentModel;
using System.Windows;

namespace KMAAndrusiv02
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}

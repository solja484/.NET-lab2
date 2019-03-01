
namespace KMAAndrusiv02.NavigationTools
{
    internal enum ViewType
    {
        Input,
        Results
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}

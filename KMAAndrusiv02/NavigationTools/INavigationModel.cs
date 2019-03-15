
namespace KMAAndrusiv02.NavigationTools
{
    internal enum ViewType
    {
        Input,
        Results
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}

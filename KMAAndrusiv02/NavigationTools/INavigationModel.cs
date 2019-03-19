
namespace KMAAndrusiv02.NavigationTools
{
    internal enum ViewType
    {
        Input,
        Results,
        List
    }

    internal interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}

using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    /// <summary>
    /// Interaction logic for PersonListView.xaml
    /// </summary>
    public partial class PersonListView : INavigatable
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }

        public void TriggerPropertyChanged(string s)
        {
            ((BaseViewModel)DataContext).OnPropertyChanged(s);
        }
    }
}

using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    /// Interaction logic for AuthorizeControl.xaml
    /// </summary>
    public partial class PersonControl : INavigatable
    {
        public PersonControl()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }

        public void TriggerPropertyChanged(string s)
        {
            ((BaseViewModel)DataContext).OnPropertyChanged(s);
        }
    }
}

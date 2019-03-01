using KMAAndrusiv02.NavigationTools;
using System.Windows.Controls;

namespace KMAAndrusiv02
{
    /// <summary>
    /// Interaction logic for AuthorizeControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl, INavigatable
    {
        public PersonControl()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
}

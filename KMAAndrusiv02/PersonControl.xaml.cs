using KMAAndrusiv02.NavigationTools;
using System.Windows.Controls;

namespace KMAAndrusiv02
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
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

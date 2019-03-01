using KMAAndrusiv02.NavigationTools;
using System.Windows.Controls;

namespace KMAAndrusiv02
{
    /// <summary>
    /// Interaction logic for ResultsControl.xaml
    /// </summary>
    public partial class ResultsControl : UserControl, INavigatable
    {
        public ResultsControl()
        {
            InitializeComponent();
            DataContext = new ResultsViewModel();
        }
    }
}
